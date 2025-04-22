using SPodLib.AudioSample;

namespace SPodLib.EffectImplementation
{
    public class Section
    {
        private SampleMemory _uhistory;
        private SampleMemory _xhistory;
        private double[] _b;
        private double[] _a;
        private double _scale;

        public Section(double[] b, double[] a, double scale)
        {
            _b = b;
            _a = a;

            _scale = scale;

            _uhistory = new SampleMemory(3);
            _xhistory = new SampleMemory(2);
        }

        public double[] Apply(double[] sample)
        {
            _uhistory.Add(sample[0], sample[1]);
            double xR = _uhistory[0][0] * _b[0] * _scale;
            double xL = _uhistory[0][1] * _b[0] * _scale;

            xR -= _xhistory[0][0] * _a[1];
            xL -= _xhistory[0][1] * _a[1];

            xR -= _xhistory[1][0] * _a[2];
            xL -= _xhistory[1][1] * _a[2];

            xR += _uhistory[1][0] * _b[1] * _scale;
            xL += _uhistory[1][1] * _b[1] * _scale;

            xR += _uhistory[2][0] * _b[2] * _scale;
            xL += _uhistory[2][1] * _b[2] * _scale;

            _xhistory.Add(xR, xL);
            return [ xR, xL ];
        }

        public void Reset()
        {
            _uhistory.Clear();
            _xhistory.Clear();
        }
    }
}
