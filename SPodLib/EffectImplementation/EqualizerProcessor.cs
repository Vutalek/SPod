using SPodLib.AudioSample;
using SPodLib.Buffer;
using SPodLib.Parser;

namespace SPodLib.EffectImplementation
{
    public enum FilterType
    {
        FIR,
        IIR
    }

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

                Queue<Sample> toSum = new Queue<Sample>();
                for (int i = 0; i < _bands; i++)
                {
                    Queue<Sample> qin = new Queue<Sample>(1);
                    qin.Enqueue(input);
                    Queue<Sample> result = new Queue<Sample>(1);
                    result = _firs[i].Apply(qin);
                    result = _iirs[i].Apply(result);
                    toSum.Enqueue(result.Dequeue());
                }

                Sample res = new Sample();
                for (int i = 0; i < _bands; i++)
                {
                    Sample temp = new Sample();
                    temp = toSum.Dequeue();
                    res = res + temp;
                }
                output.Enqueue(res);
                _outStream.Write(output);
            }
            NotifyNext();
        }
    }
}
