using SPodLib.Wav;
using SPodLib.Buffer;
using SPodLib.Audio;

namespace CycledLin
{
    public partial class CycledLin : Form
    {
        private CycledLinearBuffer _buffer;

        private FileStream? _file;
        private WavReader _wavReader;

        private AudioPlayer _player;

        private bool _play;

        public CycledLin()
        {
            InitializeComponent();

            _buffer = new CycledLinearBuffer(5000);
            _wavReader = new WavReader(_buffer);
            _player = new AudioPlayer(_buffer);

            _player.OnRead += _wavReader.Read;
            _wavReader.OnEnd += End;
        }

        private void ChooseFile(object sender, EventArgs e)
        {
            if (Choosing.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = Choosing.FileName;
            fileName.Text = filename;

            _file = File.Open(filename, FileMode.Open);
            _wavReader.SetSource(_file);
            _player.SetAudio(_wavReader.Meta);

            _player.Play();
            _play = true;
            _player.PlayTask().Start();
            playButton.BackColor = Color.LightGreen;
            playButton.Text = "Pause";
        }

        private void End()
        {
            _player.Stop();
            playButton.BackColor = Color.White;
            playButton.Text = "Play";
            _play = false;
        }

        private void PlayButton(object sender, EventArgs e)
        {
            if (_play)
            {
                _player.Pause();
                playButton.BackColor = Color.PaleVioletRed;
                playButton.Text = "Play";
                _play = false;
            }
            else
            {
                _player.Play();
                playButton.BackColor = Color.LightGreen;
                playButton.Text = "Pause";
                _play = true;
            }
        }

        private void StopButton(object sender, EventArgs e)
        {
            if (_player is not null)
            {
                _player.Stop();
                _wavReader.Reset();
                playButton.BackColor = Color.White;
                playButton.Text = "Play";
                _play = false;
            }
        }

        private void RestartButton(object sender, EventArgs e)
        {
            if (_player is not null)
            {
                _player.Restart();
                _wavReader.Reset();
                playButton.BackColor = Color.LightGreen;
                playButton.Text = "Pause";
                _play = true;
            }
        }

        private void VolumeChanged(object sender, EventArgs e)
        {
            volumeLevel.Text = $"{volume.Value}%";
            _player.SetVolume(volume.Value / 100.0);
        }
    }
}
