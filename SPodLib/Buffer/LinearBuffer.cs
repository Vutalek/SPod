using SPodLib.AudioSample;

namespace SPodLib.Buffer
{
    public class LinearBuffer : SampleBuffer
    {
        Queue<Sample>[] _buffers;

        public LinearBuffer(int capacity)
        {
            if (capacity % 2 != 0)
                capacity++;
            _capacity = capacity;
            _atomSize = capacity / 2;

            _buffers = new Queue<Sample>[2];
            _writePos = 0;
            _readPos = 1;

            _buffers[_writePos] = new Queue<Sample>(_atomSize);
            _buffers[_readPos] = new Queue<Sample>(_atomSize);
        }

        public override bool CanWrite()
        {
            return _buffers[_writePos].Count == 0;
        }

        public override void Write(Queue<Sample> samples)
        {
            for (int i = 0; i < _atomSize; i++)
                _buffers[_writePos].Enqueue(samples.Dequeue());

            if (_buffers[_readPos].Count == 0)
            {
                for (int i = 0; i < _atomSize; i++)
                    _buffers[_readPos].Enqueue(_buffers[_writePos].Dequeue());
            }
        }

        public override bool CanRead()
        {
            return _buffers[_readPos].Count != 0;
        }

        public override Queue<Sample> Read()
        {
            Queue<Sample> result = new Queue<Sample>(_atomSize);
            for (int i = 0; i < _atomSize; i++)
                result.Enqueue(_buffers[_readPos].Dequeue());

            if (_buffers[_writePos].Count != 0)
            {
                for (int i = 0; i < _atomSize; i++)
                    _buffers[_readPos].Enqueue(_buffers[_writePos].Dequeue());
            }
            return result;
        }
    }
}
