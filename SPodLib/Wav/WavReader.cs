using SPodLib.AudioSample;
using SPodLib.Buffer;

namespace SPodLib.Wav
{
    public class WavReader
    {
        public event Action? OnEnd;
        public event Action? Next;

        public WavInfo Meta;

        private Stream? _inStream;
        private SampleBuffer _outStream;

        public WavReader(SampleBuffer output)
        {
            Meta = new WavInfo();

            _outStream = output;
        }

        public void SetSource(Stream source)
        {
            _inStream = source;

            byte[] buffer = new byte[44];
            _inStream.Read(buffer, 0, 44);

            Meta.AudioFormat = BitConverter.ToInt16([buffer[20], buffer[21]]);
            Meta.NumChannels = BitConverter.ToInt16([buffer[22], buffer[23]]);
            if (Meta.NumChannels == 1)
                Sample.SetStereo(false);
            else if (Meta.NumChannels == 2)
                Sample.SetStereo(true);
            Meta.SampleRate = BitConverter.ToInt32([buffer[24], buffer[25], buffer[26], buffer[27]]);
            Meta.ByteRate = BitConverter.ToInt32([buffer[28], buffer[29], buffer[30], buffer[31]]);
            Meta.BlockAlign = BitConverter.ToInt16([buffer[32], buffer[33]]);
            Meta.BitsPerSample = BitConverter.ToInt16([buffer[34], buffer[35]]);
            Sample.SetResolution((Resolution)Meta.BitsPerSample);
        }

        public void Read()
        {
            if (_inStream is not null && _outStream.CanWrite())
            {
                byte[] buffer = new byte[_outStream.AtomSize * Meta.BlockAlign];
                int count = _inStream.Read(buffer, 0, _outStream.AtomSize * Meta.BlockAlign);
                if (count == 0)
                {
                    _inStream.Seek(44, SeekOrigin.Begin);
                    OnEnd?.Invoke();
                    return;
                }
                
                Queue<Sample> samples = new Queue<Sample>(_outStream.AtomSize);
                byte[] temp = new byte[Meta.BlockAlign];
                for (int i = 0; i < _outStream.AtomSize; i++)
                {
                    Array.Copy(buffer, Meta.BlockAlign * i, temp, 0, Meta.BlockAlign);
                    samples.Enqueue(new Sample(temp));
                }
                _outStream.Write(samples);
            }
            Next?.Invoke();
        }

        public void Reset()
        {
            if (_inStream is not null)
                _inStream.Seek(44, SeekOrigin.Begin);
        }
    }
}
