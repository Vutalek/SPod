using SPodLib.Wav;
using SPodLib.Buffer;
using SPodLib.Audio;
using SPodLib.EffectImplementation;

namespace SPod
{
    public partial class SPod : Form
    {
        private RingBuffer _buffer1;
        private RingBuffer _buffer2;

        private FileStream? _file;
        private WavReader _wavReader;

        private EqualizerProcessor _equalizer;

        private AudioPlayer _player;
        private CancellationTokenSource? _playerTask;

        private bool _play;

        public SPod()
        {
            InitializeComponent();

            _buffer1 = new RingBuffer(4000);
            _buffer2 = new RingBuffer(4000);
            _wavReader = new WavReader(_buffer1);

            _equalizer = new EqualizerProcessor(6, _buffer1, _buffer2);
            for (int i = 0; i < 6; i++)
            {
                _equalizer.AddBand(i, "filters/fir" + (i + 1) + ".fcf", FilterType.FIR);
                _equalizer.AddBand(i, "filters/iir" + (i + 1) + ".fcf", FilterType.IIR, true);
            }

            _player = new AudioPlayer(_buffer2);

            _wavReader.Next += _equalizer.Process;
            _player.OnRead += _wavReader.Read;

            _wavReader.OnEnd += End;
        }

        private void ChooseFile(object sender, EventArgs e)
        {
            _player.Stop();
            _playerTask?.Cancel();
            _playerTask?.Dispose();
            _player.Reset();

            _equalizer.Reset();

            _file?.Dispose();
            _file?.Close();

            if (Choosing.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = Choosing.FileName;
            fileName.Text = filename;

            _file = File.Open(filename, FileMode.Open);
            _wavReader = new WavReader(_buffer1);
            _player = new AudioPlayer(_buffer2);
            _wavReader.SetSource(_file);
            _player.SetAudio(_wavReader.Meta);

            _wavReader.Next += _equalizer.Process;
            _player.OnRead += _wavReader.Read;

            _wavReader.OnEnd += End;

            _player.Play();
            _play = true;
            _playerTask = _player.PlayTask();

            playButton.BackColor = Color.LightGreen;
            playButton.Text = "Pause";
        }

        private void End()
        {
            _player.Stop();
            _equalizer.Reset();
            _play = false;
            playButton.Invoke((MethodInvoker)delegate
            {
                playButton.BackColor = Color.White;
                playButton.Text = "Play";
            });
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
                _equalizer.Reset();
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
                _equalizer.Reset();
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

        private void FilterChanged(object sender, EventArgs e)
        {
            if (FIR.Checked)
                _equalizer.ChangeType(FilterType.FIR);
            else
                _equalizer.ChangeType(FilterType.IIR);
        }

        private void gainChanged(object sender, EventArgs e)
        {
            var gain = (TrackBar)sender;
            int band = Convert.ToInt32(gain.Name[4]) - 48 - 1;
            _equalizer.ChangeGain(band, gain.Value);
        }
    }
}
