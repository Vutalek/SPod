using SPodLib.AudioSample;

namespace SPodLib.Buffer
{
    public abstract class SampleBuffer
    {
        protected int _capacity;
        public int Capacity { get { return _capacity; } }

        protected int _atomSize;
        public int AtomSize { get { return _atomSize; } }

        protected int _writePos;
        protected int _readPos;

        public abstract bool CanWrite();
        public abstract void Write(Queue<Sample> samples);
        public abstract bool CanRead();
        public abstract Queue<Sample> Read();
    }
}
