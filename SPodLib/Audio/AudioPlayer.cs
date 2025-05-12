using SPodLib.AudioSample;
using SPodLib.Buffer;
using SPodLib.Wav;

namespace SPodLib.Audio
{
    /// <summary>
    /// Class representing audio player.
    /// </summary>
    public class AudioPlayer
    {
        /// <summary>
        /// Event that will be triggered on read. Must contain actions to prepare data in buffers.
        /// </summary>
        public event Action? OnRead;

        private WavInfo _meta;

        private AudioChannel? _channel;
        /// <summary>
        /// AudioChannel object.
        /// </summary>
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

        ~AudioPlayer()
        {
            Reset();
        }

        /// <summary>
        /// Sets the audio for playback.
        /// </summary>
        /// <param name="wav">WavInfo object describing input.</param>
        public void SetAudio(WavInfo wav)
        {
            _meta = wav;
            _channel = new AudioChannel(wav.NumChannels, wav.BitsPerSample, wav.SampleRate);
        }

        /// <summary>
        /// Main starting point of player.
        /// Starts new Task in which it is reading and writing to channel in a loop.
        /// </summary>
        /// <returns>CancellationTokenSource for stopping Task.</returns>
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

        /// <summary>
        /// Change volume.
        /// </summary>
        /// <param name="volume">
        /// Volume of a channel. Must be between 0 and 1.
        /// </param>
        public void SetVolume(double volume)
        {
            if (_channel is null) return;

            _channel.SetVolume(volume);
        }

        /// <summary>
        /// Start playing.
        /// </summary>
        public void Play()
        {
            if (_channel is null) return;

            _playing = true;
            _channel.Play();
        }

        /// <summary>
        /// Stop playing (stop and resart).
        /// </summary>
        public void Stop()
        {
            if (_channel is null) return;

            _playing = false;
            while (_channel.IsActive())
                continue;
            _channel.Stop();
        }

        /// <summary>
        /// Pause player.
        /// </summary>
        public void Pause()
        {
            if (_channel is null) return;

            _playing = false;
            _channel.Pause();
        }

        /// <summary>
        /// Restart playing.
        /// </summary>
        public void Restart()
        {
            if (_channel is null) return;

            _playing = true;
            _channel.Restart();
        }

        /// <summary>
        /// Free resources.
        /// </summary>
        public void Reset()
        {
            _channel?.Reset();
            OnRead = null;
        }
    }
}
