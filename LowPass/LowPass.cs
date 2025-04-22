using SPodLib.Wav;
using SPodLib.Buffer;
using SPodLib.Audio;
using SPodLib.EffectImplementation;
using SPodLib.Effect;
using SPodLib.Parser;

namespace LowPass
{
    public partial class LowPass : Form
    {
        private RingBuffer _buffer1;
        private RingBuffer _buffer2;

        private FileStream? _file;
        private WavReader _wavReader;

        private EffectProcessor _effectProcessor;
        private FIRFilter _fir;
        private IIRFilter _iir;

        private AudioPlayer _player;
        private CancellationTokenSource? _playerTask;

        private bool _play;

        public LowPass()
        {
            InitializeComponent();

            _buffer1 = new RingBuffer(1000);
            _buffer2 = new RingBuffer(1000);
            _wavReader = new WavReader(_buffer1);

            _fir = FilterParser.ParseFIR("fir1.fcf");
            //_fir = FilterParser.ParseFIR("fir2.fcf");
            //_fir = FilterParser.ParseFIR("fir3.fcf");

            _iir = FilterParser.ParseIIR("iir1.fcf", true);
            //_iir = FilterParser.ParseIIR("iir1.fcf", true);
            //_iir = FilterParser.ParseIIR("iir1.fcf", true);

            ChainEffect filters = new ChainEffect();
            filters.Add(_fir);
            filters.Add(_iir);

            _effectProcessor = new EffectProcessor(filters, _buffer1, _buffer2);

            _player = new AudioPlayer(_buffer2);

            _wavReader.Next += _effectProcessor.Process;
            _player.OnRead += _wavReader.Read;

            _wavReader.OnEnd += End;
        }

        private void ChooseFile(object sender, EventArgs e)
        {
            _player.Stop();
            _playerTask?.Cancel();
            _playerTask?.Dispose();
            _player.Reset();

            _fir.Reset();
            _iir.Reset();

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

            _wavReader.Next += _effectProcessor.Process;
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
            _fir.Reset();
            _iir.Reset();
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
                _fir.Reset();
                _iir.Reset();
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
                _fir.Reset();
                _iir.Reset();
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
            if (Filter.Checked)
            {
                if (FIR.Checked)
                {
                    _iir.Disable();
                    _fir.Reset();
                    _fir.Enable();
                }
                else
                {
                    _fir.Disable();
                    _iir.Reset();
                    _iir.Enable();
                }
            }
            else
            {
                _fir.Disable();
                _iir.Disable();
            }
        }
    }
}
