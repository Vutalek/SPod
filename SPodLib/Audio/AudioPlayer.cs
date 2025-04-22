using SPodLib.AudioSample;
using SPodLib.Buffer;
using SPodLib.Wav;

namespace SPodLib.Audio
{
    public class AudioPlayer
    {
        public Action? OnRead;

        private WavInfo _meta;

        private AudioChannel? _channel;
        public AudioChannel? Channel
        {
            get { return _channel; }
        }

        private SampleBuffer _input;

        private bool _playing = false;

        public AudioPlayer(SampleBuffer input)
        {
            _meta = new WavInfo();

            _input = input;
        }

        public AudioPlayer(SampleBuffer input, WavInfo wav)
        {
            _input = input;
            _meta = wav;
            _channel = new AudioChannel(wav.NumChannels, wav.BitsPerSample, wav.SampleRate);
        }

        public void SetAudio(WavInfo wav)
        {
            _meta = wav;
            _channel = new AudioChannel(wav.NumChannels, wav.BitsPerSample, wav.SampleRate);
        }

        public CancellationTokenSource PlayTask()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task play = new Task(() =>
            {
                if (_channel is null) return;

                while (true)
                {
                    if (!_playing) Thread.Sleep(250);
                    else
                    {
                        OnRead?.Invoke();
                        bool a = _input.CanRead();
                        int b = _channel.Available();
                        if (50000 - _channel.Available() >= _input.AtomSize && _input.CanRead())
                        {
                            Queue<Sample> samples = _input.Read();
                            byte[] buffer = new byte[samples.Count * _meta.BlockAlign];
                            for (int i = 0; i < _input.AtomSize; i++)
                                Array.Copy(samples.Dequeue().Bytes(), 0, buffer, _meta.BlockAlign * i, _meta.BlockAlign);
                            _channel.Put(buffer, _input.AtomSize * _meta.BlockAlign);
                        }
                    }
                }
            }, token);
            play.Start();

            return cancelTokenSource;
        }

        public void SetVolume(double volume)
        {
            if (_channel is null) return;

            _channel.SetVolume(volume);
        }

        public void Play()
        {
            if (_channel is null) return;

            _playing = true;
            _channel.Play();
        }
        public void Stop()
        {
            if (_channel is null) return;

            _playing = false;
            while (_channel.IsActive())
                continue;
            _channel.Stop();
        }

        public void Pause()
        {
            if (_channel is null) return;

            _playing = false;
            _channel.Pause();
        }

        public void Restart()
        {
            if (_channel is null) return;

            _playing = true;
            _channel.Restart();
        }

        public void Reset()
        {
            _channel?.Reset();
            OnRead = null;
        }
    }
}
