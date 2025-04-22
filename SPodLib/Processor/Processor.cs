using SPodLib.Buffer;

namespace SPodLib.Processor
{
    public abstract class Processor
    {
        public event Action? OnRead;
        public event Action? Next;

        protected SampleBuffer _inStream;
        protected SampleBuffer _outStream;

        public Processor(SampleBuffer inStream, SampleBuffer outStream)
        {
            _inStream = inStream;
            _outStream = outStream;
        }
        
        protected void NotifyRead()
        {
            OnRead?.Invoke();
        }

        protected void NotifyNext()
        {
            Next?.Invoke();
        }
        public abstract void Process();
    }
}
