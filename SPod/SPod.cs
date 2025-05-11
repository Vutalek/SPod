using SPodLib.Wav;
using SPodLib.Buffer;
using SPodLib.Audio;
using SPodLib.EffectImplementation;
using SPodLib.FFT;
using SPodLib.AudioSample;
using System.Windows.Forms.DataVisualization.Charting;
using SPodLib.Effect;
using System.Text.Json;

namespace SPod
{
    public partial class SPod : Form
    {
        private RingBuffer _buffer1;
        private RingBuffer _buffer2;
        private RingBuffer _buffer3;

        private FileStream? _file;
        private WavReader _wavReader;

        private Delay _delay;
        private Envelop _envelop;
        private ChainEffect _chainEffect;
        private EffectProcessor _effectProcessor;

        private EqualizerProcessor _equalizer;

        private AudioPlayer _player;
        private CancellationTokenSource? _playerTask;

        private int _fftSize = 256;
        private int _bufferSize = 4000;
        private int _numBands = 6;

        private bool _play;

        public SPod()
        {
            InitializeComponent();

            _buffer1 = new RingBuffer(_bufferSize);
            _buffer2 = new RingBuffer(_bufferSize);
            _buffer3 = new RingBuffer(_bufferSize);
            _wavReader = new WavReader(_buffer1);

            _delay = new Delay(1024, 0.8);
            _envelop = new Envelop(4096);
            _chainEffect = new ChainEffect();
            _chainEffect.Add(_envelop);
            _chainEffect.Add(_delay);
            _effectProcessor = new EffectProcessor(_chainEffect, _buffer1, _buffer2);

            _equalizer = new EqualizerProcessor(_numBands, _buffer2, _buffer3);
            for (int i = 0; i < _numBands; i++)
            {
                _equalizer.AddBand(i, "filters/fir" + (i + 1) + ".fcf", FilterType.FIR);
                _equalizer.AddBand(i, "filters/iir" + (i + 1) + ".fcf", FilterType.IIR, true);
            }

            _player = new AudioPlayer(_buffer3);

            _wavReader.Next += _effectProcessor.Process;
            _effectProcessor.Next += _equalizer.Process;
            _player.OnRead += _wavReader.Read;

            _wavReader.OnEnd += End;

            LoadSettings();

            InputViz.ChartAreas.Clear();
            InputViz.ChartAreas.Add(new ChartArea());
            InputViz.ChartAreas[0].AxisX.Minimum = 0;
            InputViz.ChartAreas[0].AxisX.Maximum = _fftSize - 1;
            InputViz.ChartAreas[0].AxisY.Minimum = 0;
            InputViz.ChartAreas[0].AxisY.Maximum = 1;

            OutputViz.ChartAreas.Clear();
            OutputViz.ChartAreas.Add(new ChartArea());
            OutputViz.ChartAreas[0].AxisX.Minimum = 0;
            OutputViz.ChartAreas[0].AxisX.Maximum = _fftSize - 1;
            OutputViz.ChartAreas[0].AxisY.Minimum = 0;
            OutputViz.ChartAreas[0].AxisY.Maximum = 1;

            StartVizualizer();
        }

        private void LoadSettings()
        {
            if (File.Exists("settings.json"))
            {
                FileStream fs = new FileStream("settings.json", FileMode.Open);
                SaveState state = JsonSerializer.Deserialize<SaveState>(fs)!;
                fs.Close();

                volumeLevel.Text = $"{state.Volume}%";
                _player.SetVolume(state.Volume / 100.0);
                volume.Value = state.Volume;

                if (state.IsFir)
                {
                    _equalizer.ChangeType(FilterType.FIR);
                    FIR.Checked = true;
                }
                else
                {
                    _equalizer.ChangeType(FilterType.IIR);
                    IIR.Checked = false;
                }

                _equalizer.ChangeGain(0, state.Gain1);
                gain1.Value = state.Gain1;
                _equalizer.ChangeGain(1, state.Gain2);
                gain2.Value = state.Gain2;
                _equalizer.ChangeGain(2, state.Gain3);
                gain3.Value = state.Gain3;
                _equalizer.ChangeGain(3, state.Gain4);
                gain4.Value = state.Gain4;
                _equalizer.ChangeGain(4, state.Gain5);
                gain5.Value = state.Gain5;
                _equalizer.ChangeGain(5, state.Gain6);
                gain6.Value = state.Gain6;

                if (state.Delay)
                {
                    _delay.Enable();
                    delayDepth.Enabled = false;
                    delayCheck.Checked = true;
                }
                else
                {
                    _delay.Disable();
                    delayDepth.Enabled = true;
                    delayCheck.Checked = false;
                }

                _delay.ChangeDepth(state.DelayDepth);
                delayDepth.Value = state.DelayDepth;

                _delay.ChangeLevel(state.DelayLevel / 100.0);
                delayLevel.Value = state.DelayLevel;


                if (state.Envelop)
                {
                    _envelop.Enable();
                    envelopSize.Enabled = false;
                    envelopCheck.Checked = true;
                }
                else
                {
                    _envelop.Disable();
                    envelopSize.Enabled = true;
                    envelopCheck.Checked = false;
                }


                _envelop.SetSize(state.EnvelopSize);
                envelopSize.Value = state.EnvelopSize;

                _envelop.ChangeSinDepth(1 - state.EnvelopSin / 100.0);
                envelopSinus.Value = state.EnvelopSin;
                _envelop.ChangeTriagDepth(1 - state.EnvelopTriag / 100.0);
                envelopTriangle.Value = state.EnvelopTriag;
                _envelop.ChangeRectDepth(1 - state.EnvelopRect / 100.0);
                envelopRect.Value = state.EnvelopRect;
            }
            else return;
        }

        private void SaveSettings(object sender, FormClosingEventArgs e)
        {
            SaveState current = new SaveState();
            current.Volume = volume.Value;

            current.IsFir = FIR.Checked;
            current.Gain1 = gain1.Value;
            current.Gain2 = gain2.Value;
            current.Gain3 = gain3.Value;
            current.Gain4 = gain4.Value;
            current.Gain5 = gain5.Value;
            current.Gain6 = gain6.Value;

            current.Delay = delayCheck.Checked;
            current.DelayDepth = delayDepth.Value;
            current.DelayLevel = delayLevel.Value;

            current.Envelop = envelopCheck.Checked;
            current.EnvelopSize = envelopSize.Value;
            current.EnvelopSin = envelopSinus.Value;
            current.EnvelopTriag = envelopTriangle.Value;
            current.EnvelopRect = envelopRect.Value;

            string json = JsonSerializer.Serialize(current);
            File.WriteAllText("settings.json", json);
        }

        private void StartVizualizer()
        {
            Task viz = new Task(() =>
            {
                while (true)
                {
                    Thread.Sleep(50);

                    Series[] fft = PrepareFFT();

                    InputViz.Invoke(() =>
                    {
                        InputViz.Series.Clear();
                        InputViz.Series.Add(fft[0]);
                    });

                    OutputViz.Invoke(() =>
                    {
                        OutputViz.Series.Clear();
                        OutputViz.Series.Add(fft[1]);
                    });
                }
            });
            viz.Start();
        }

        private Series[] PrepareFFT()
        {
            Series inp = new Series();
            inp.ChartType = SeriesChartType.Line;
            inp.BorderWidth = 2;
            inp.BorderDashStyle = ChartDashStyle.Solid;

            Series outp = new Series();
            outp.ChartType = SeriesChartType.Line;
            outp.BorderWidth = 2;
            outp.BorderDashStyle = ChartDashStyle.Solid;

            List<Sample> samplesInp = _buffer1.Buffer;
            List<Sample> samplesOutp = _buffer3.Buffer;

            double[] doubleSamplesInp = new double[_fftSize];
            double[] doubleSamplesOutp = new double[_fftSize];
            for (int i = 0; i < _fftSize; i++)
            {
                doubleSamplesInp[i] = samplesInp[i].Values()[0];
                doubleSamplesOutp[i] = samplesOutp[i].Values()[0];
            }

            double[] fftInp = FFTAlgorithm.FFT(doubleSamplesInp);
            double[] fftOutp = FFTAlgorithm.FFT(doubleSamplesOutp);

            double minInp = fftInp.Min();
            double scaleInp = fftInp.Max() - minInp + 0.0001;

            double minOutp = fftOutp.Min();
            double scaleOutp = fftOutp.Max() - minOutp + 0.0001;

            for (int i = 0; i < _fftSize; i++)
            {
                inp.Points.AddXY(i, (fftInp[i] - minInp) / scaleInp);
                outp.Points.AddXY(i, (fftOutp[i] - minOutp) / scaleOutp);
            }

            return [inp, outp];
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
            _player = new AudioPlayer(_buffer3);
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
            else _equalizer.ChangeType(FilterType.IIR);
        }

        private void gainChanged(object sender, EventArgs e)
        {
            TrackBar gain = (TrackBar)sender;
            int band = Convert.ToInt32(gain.Name[4]) - 48 - 1;
            _equalizer.ChangeGain(band, gain.Value);
        }

        private void DelayChecked(object sender, EventArgs e)
        {
            if (delayCheck.Checked)
            {
                _delay.Enable();
                delayDepth.Enabled = false;
            }
            else
            {
                _delay.Disable();
                delayDepth.Enabled = true;
            }
        }

        private void DelayDepthChanged(object sender, EventArgs e)
        {
            _delay.ChangeDepth(delayDepth.Value);
        }

        private void DelayLevelChanged(object sender, EventArgs e)
        {
            _delay.ChangeLevel(delayLevel.Value / 100.0);
        }

        private void EnvelopChecked(object sender, EventArgs e)
        {
            if (envelopCheck.Checked)
            {
                _envelop.Enable();
                envelopSize.Enabled = false;
            }
            else
            {
                _envelop.Disable();
                envelopSize.Enabled = true;
            }
        }

        private void EnvelopSizeChanged(object sender, EventArgs e)
        {
            _envelop.SetSize(envelopSize.Value);
        }

        private void EnvelopSinDepthChanged(object sender, EventArgs e)
        {
            _envelop.ChangeSinDepth(1 - envelopSinus.Value / 100.0);
        }

        private void EnvelopTriagDepthChanged(object sender, EventArgs e)
        {
            _envelop.ChangeTriagDepth(1 - envelopTriangle.Value / 100.0);
        }

        private void EnvelopRectDepthChanged(object sender, EventArgs e)
        {
            _envelop.ChangeRectDepth(1 - envelopRect.Value / 100.0);
        }
    }
}
