using System.Windows.Forms;
using ManagedBass;

namespace PlayTest
{
    public partial class Play : Form
    {
        private int _channel;
        private bool play = false;

        public Play()
        {
            InitializeComponent();

            Bass.Init(-1, 44100, DeviceInitFlags.Default);
            _channel = 0;
        }

        ~Play()
        {
            Bass.Free();
        }

        private void ChooseFile(object sender, EventArgs e)
        {
            if (Choosing.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = Choosing.FileName;
            fileName.Text = filename;

            Bass.StreamFree(_channel);
            _channel = Bass.CreateStream(filename, 0L, 0L, BassFlags.Default);
        }
        private void PlayButton(object sender, EventArgs e)
        {
            if (_channel != 0)
            {
                if (play)
                {
                    Bass.ChannelPause(_channel);
                    playButton.BackColor = Color.PaleVioletRed;
                    playButton.Text = "Play";
                    play = false;
                }
                else
                {
                    Bass.ChannelPlay(_channel, false);
                    playButton.BackColor = Color.LightGreen;
                    playButton.Text = "Pause";
                    play = true;
                }
            }
        }

        private void StopButton(object sender, EventArgs e)
        {
            if (_channel != 0)
            {
                Bass.ChannelStop(_channel);
                Bass.ChannelSetPosition(_channel, 0);
                playButton.BackColor = Color.White;
                playButton.Text = "Play";
                play = false;
            }
        }

        private void RestartButton(object sender, EventArgs e)
        {
            if (_channel != 0)
            {
                Bass.ChannelPlay(_channel, true);
                playButton.BackColor = Color.LightGreen;
                playButton.Text = "Pause";
                play = true;
            }
        }
    }
}
