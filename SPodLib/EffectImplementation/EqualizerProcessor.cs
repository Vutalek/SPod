using SPodLib.AudioSample;
using SPodLib.Buffer;
using SPodLib.Parser;
using System.Collections.Concurrent;

namespace SPodLib.EffectImplementation
{
    /// <summary>
    /// Enumeration of filter types.
    /// </summary>
    public enum FilterType
    {
        FIR,
        IIR
    }

    /// <summary>
    /// Processor for equalizer.
    /// </summary>
    public class EqualizerProcessor : Processor.Processor
    {
        private int _bands;
        private List<FIRFilter> _firs;
        private List<IIRFilter> _iirs;

        public EqualizerProcessor(int bands, SampleBuffer input, SampleBuffer output) : base(input, output)
        {
            _bands = bands;
            _firs = new List<FIRFilter>(bands);
            for (int i = 0; i < _bands; i++)
                _firs.Add(new FIRFilter([]));
            _iirs = new List<IIRFilter>(bands);
            for (int i = 0; i < _bands; i++)
                _iirs.Add(new IIRFilter(new List<Section>(){ }, 0.0));
        }

        /// <summary>
        /// Adds band to equalizer.
        /// </summary>
        /// <param name="band">index of band.</param>
        /// <param name="path">path to *.fcf file with filter coefficients.</param>
        /// <param name="type"></param>
        /// <param name="skip_last_coef"></param>
        public void AddBand(int band, string path, FilterType type, bool skip_last_coef = false)
        {
            switch(type)
            {
                case FilterType.FIR:
                    FIRFilter fir = FilterParser.ParseFIR(path);
                    _firs[band] = fir;
                    fir.Enable();
                    break;
                case FilterType.IIR:
                    IIRFilter iir = FilterParser.ParseIIR(path, skip_last_coef);
                    _iirs[band] = iir;
                    break;
            }
        }

        /// <summary>
        /// Switching between FIR and IIR.
        /// </summary>
        /// <param name="type"></param>
        public void ChangeType(FilterType type)
        {
            switch (type)
            {
                case FilterType.FIR:
                    foreach (FIRFilter fir in _firs)
                    {
                        fir.Reset();
                        fir.Enable();
                    }
                    foreach (IIRFilter iir in _iirs)
                        iir.Disable();
                    break;
                case FilterType.IIR:
                    foreach (FIRFilter fir in _firs)
                        fir.Disable();
                    foreach (IIRFilter iir in _iirs)
                    {
                        iir.Reset();
                        iir.Enable();
                    }
                    break;
            }
        }

        public void ChangeGain(int band, double value)
        {
            _firs[band].ChangeGain(value);
            _iirs[band].ChangeGain(value);
        }

        /// <summary>
        /// Clear filters memory.
        /// </summary>
        public void Reset()
        {
            foreach (FIRFilter fir in _firs) fir.Reset();
            foreach (IIRFilter iir in _iirs) iir.Reset();
        }

        /// <summary>
        /// DO NOT USE IT WITH LINEAR OR OTHER THAN RING BUFFERS!!!!
        /// </summary>
        public override void Process()
        {
            NotifyRead();
            if (_inStream.CanRead() && _outStream.CanWrite())
            {
                Sample input = _inStream.Read().Dequeue();
                Queue<Sample> output = new Queue<Sample>(1);

                List<Sample> toSum = new List<Sample>(_bands);
                for (int i = 0; i < _bands; i++)
                {
                    Sample result = _firs[i].ApplySingle(input);
                    result = _iirs[i].ApplySingle(result);
                    toSum.Add(result);
                }

                Sample res = new Sample();
                for (int i = 0; i < _bands; i++)
                    res = res + toSum[i];
                output.Enqueue(res);
                _outStream.Write(output);
            }
            NotifyNext();
        }
    }
}
