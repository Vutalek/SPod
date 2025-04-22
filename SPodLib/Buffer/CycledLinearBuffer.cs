using SPodLib.AudioSample;
using System.Drawing;

namespace SPodLib.Buffer
{
    public class CycledLinearBuffer : SampleBuffer
    {
        private Queue<Sample> _firstHalf;
        private Queue<Sample> _secondHalf;

        public CycledLinearBuffer(int capacity)
        {
            if (capacity % 2 != 0)
                capacity++;
            _capacity = capacity;
            _atomSize = capacity / 2;

            _writePos = 0;
            _readPos = 0;

            _firstHalf = new Queue<Sample>(_atomSize);
            _secondHalf = new Queue<Sample>(_atomSize);
        }

        public override bool CanWrite()
        {
            bool result = false;
            switch (_writePos)
            {
                case 0:
                    result = _firstHalf.Count == 0;
                    break;
                case 1:
                    result = _secondHalf.Count == 0;
                    break;
            }
            return result;
        }

        public override void Write(Queue<Sample> samples)
        {
            int size = samples.Count;
            switch (_writePos)
            {
                case 0:
                    for (int i = 0; i < size; i++)
                        _firstHalf.Enqueue(samples.Dequeue());
                    _writePos = 1;
                    break;
                case 1:
                    for (int i = 0; i < size; i++)
                        _secondHalf.Enqueue(samples.Dequeue());
                    _writePos = 0;
                    break;
            }
        }

        public override bool CanRead()
        {
            bool result = false;
            switch (_readPos)
            {
                case 0:
                    result = _firstHalf.Count > 0;
                    break;
                case 1:
                    result = _secondHalf.Count > 0;
                    break;
            }
            return result;
        }

        public override Queue<Sample> Read()
        {
            Queue<Sample> result = new Queue<Sample>(_atomSize);
            switch (_readPos)
            {
                case 0:
                    for (int i = 0; i < _atomSize; i++)
                        result.Enqueue(_firstHalf.Dequeue());
                    _readPos = 1;
                    break;
                case 1:
                    for (int i = 0; i < _atomSize; i++)
                        result.Enqueue(_secondHalf.Dequeue());
                    _readPos = 0;
                    break;
            }
            return result;
        }
    }
}
