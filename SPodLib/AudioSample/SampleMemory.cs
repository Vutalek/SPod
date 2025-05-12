using System.Drawing;

namespace SPodLib.AudioSample
{
    /// <summary>
    /// Class representing Sample sequence.
    /// </summary>
    public class SampleMemory
    {
        private int _size;
        private List<double> _historyR = new List<double>();
        private List<double> _historyL = new List<double>();
        public SampleMemory(int size)
        {
            _size = size;
            for (int i = 0; i < size; i++)
                _historyR.Add(0);
            for (int i = 0; i < size; i++)
                _historyL.Add(0);
        }

        public double[] this[int i]
        {
            get
            {
                return [_historyR[_size - 1 - i], _historyL[_size - 1 - i]];
            }
        }

        /// <summary>
        /// Add the sample by values.
        /// </summary>
        /// <param name="valueR"></param>
        /// <param name="valueL"></param>
        public void Add(double valueR, double valueL)
        {
            _historyR.Add(valueR);
            _historyR.RemoveAt(0);

            _historyL.Add(valueL);
            _historyL.RemoveAt(0);
        }

        /// <summary>
        /// Clears the sequence.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < _size; i++)
            {
                _historyR[i] = 0;
                _historyL[i] = 0;
            }
        }
    }
}
