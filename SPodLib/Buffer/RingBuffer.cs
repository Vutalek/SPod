using SPodLib.AudioSample;

namespace SPodLib.Buffer
{
    public class RingBuffer : SampleBuffer
    {
        List<Sample> _buffer;
        int _size;

        public RingBuffer(int capacity)
        {
            _capacity = capacity;
            _atomSize = 1;

            _buffer = new List<Sample>(capacity);
            for (int i = 0; i < _capacity; i++)
                _buffer.Add(new Sample());

            _writePos = 0;
            _readPos = 0;

            _size = 0;
        }

        public override bool CanWrite()
        {
            return _size != _capacity;
        }

        public override void Write(Queue<Sample> samples)
        {
            int len = samples.Count;
            for (int i = 0; i < len; i++)
            {
                _buffer[_writePos] = samples.Dequeue();
                _writePos = (_writePos + 1) % _capacity;
                _size++;
                if (_size == _capacity) break;
            }
        }

        public override bool CanRead()
        {
            return _size != 0;
        }

        public override Queue<Sample> Read()
        {
            Queue<Sample> result = new Queue<Sample>(_atomSize);
            result.Enqueue(_buffer[_readPos]);
            _readPos = (_readPos + 1) % _capacity;
            _size--;
            return result;
        }
    }
}
