using SPodLib.Buffer;

namespace SPodLib.Processor
{
    /// <summary>
    /// Abstract class representing Processor for a chain of processors.
    /// </summary>
    public abstract class Processor
    {
        /// <summary>
        /// Event that triggers on reading.
        /// </summary>
        public event Action? OnRead;
        /// <summary>
        /// Event that triggers before ending processing (represent next processor).
        /// </summary>
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
        /// <summary>
        /// Process procedure.
        /// </summary>
        public abstract void Process();
    }
}
