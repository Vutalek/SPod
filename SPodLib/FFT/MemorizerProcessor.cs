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
            return _samples;
        }

        public override void Process()
        {
            NotifyRead();
            if (_inStream.CanRead() && _outStream.CanWrite())
            {
                Sample input = _inStream.Read().Dequeue();
                Queue<Sample> output = new Queue<Sample>(1);

                _samples.RemoveAt(0);
                _samples.Add(input);

                output.Enqueue(input);
                _outStream.Write(output);
            }
            NotifyNext();
        }
    }
}
