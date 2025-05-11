using SPodLib.AudioSample;
using SPodLib.Buffer;

namespace SPodLib.FFT
{
    public class MemorizerProcessor : Processor.Processor
    {
        int _size;
        List<Sample> _samples; 

        public MemorizerProcessor(int size, SampleBuffer input, SampleBuffer output) : base(input, output)
        {
            _size = size;
            _samples = new List<Sample>(size);
            for (int i = 0; i < size; i++)
                _samples.Add(new Sample());
        }

        public List<Sample> ReadSamples()
        {
            List<Sample> output = new List<Sample>(_size);
            for (int i = 0; i < _size; i++)
                output.Add(_samples[i]);
            return output;
        }

        public override void Process()
        {
            NotifyRead();
            if (_inStream.CanRead() && _outStream.CanWrite())
            {
                Sample input = _inStream.Read().Dequeue();
                Queue<Sample> output = new Queue<Sample>(1);

                _samples.Add(input);
                _samples.RemoveAt(0);

                output.Enqueue(input);
                _outStream.Write(output);
            }
            NotifyNext();
        }
    }
}
