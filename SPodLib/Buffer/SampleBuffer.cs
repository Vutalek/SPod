using SPodLib.AudioSample;

namespace SPodLib.Buffer
{
    /// <summary>
    /// Abstract class representing buffer.
    /// </summary>
    public abstract class SampleBuffer
    {
        protected int _capacity;
        /// <summary>
        /// Maximum capacity of buffer in number of samples.
        /// </summary>
        public int Capacity { get { return _capacity; } }

        protected int _atomSize;
        /// <summary>
        /// Amount of samples that will be returned by read/write operations.
        /// </summary>
        public int AtomSize { get { return _atomSize; } }

        protected int _writePos;
        protected int _readPos;

        /// <summary>
        /// Check if channel is free to write.
        /// </summary>
        /// <returns>true if can write.</returns>
        public abstract bool CanWrite();
        /// <summary>
        /// Write operation.
        /// </summary>
        /// <param name="samples">Queue with AtomSize samples inside.</param>
        public abstract void Write(Queue<Sample> samples);
        /// <summary>
        /// Check if channel has something to read.
        /// </summary>
        /// <returns>true if can read.</returns>
        public abstract bool CanRead();
        /// <summary>
        /// Read operation.
        /// </summary>
        /// <returns>Queue with AtomSize samples inside.</returns>
        public abstract Queue<Sample> Read();
    }
}
