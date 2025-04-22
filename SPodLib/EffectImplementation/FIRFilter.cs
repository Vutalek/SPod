using SPodLib.AudioSample;
using SPodLib.Effect;

namespace SPodLib.EffectImplementation
{
    public class FIRFilter : Switchable, IEffect
    {
        private SampleMemory _uhistory;
        private double[] _coefs;
        private double _gain = 0; //dB

        public FIRFilter(double[] coefs)
        {
            _coefs = coefs;

            _uhistory = new SampleMemory(coefs.Length);
        }

        public void ChangeGain(double gain)
        {
            _gain = gain;
        }

        public Queue<Sample> Apply(Queue<Sample> samples)
        {
            if (IsEnabled())
            {
                int size = samples.Count;
                Queue<Sample> result = new Queue<Sample>(size);
                for (int i = 0; i < size; i++)
                {
                    Sample sample = samples.Dequeue();
                    _uhistory.Add(sample.Values()[0], sample.Values()[1]);
                    double xR = _uhistory[0][0] * _coefs[0];
                    double xL = _uhistory[0][1] * _coefs[0];
                    for (int j = 1; j < _coefs.Length; j++)
                    {
                        xR += _uhistory[j][0] * _coefs[j];
                        xL += _uhistory[j][1] * _coefs[j];
                    }
                    xR *= Math.Pow(10.0, _gain / 20.0);
                    xL *= Math.Pow(10.0, _gain / 20.0);
                    result.Enqueue(new Sample(Clip(xR), Clip(xL)));
                }
                return result;
            }
            else return samples;
        }

        public void Reset()
        {
            _uhistory.Clear();
        }

        private Int32 Clip(double value)
        {
            return Convert.ToInt32(Math.Max(Math.Min(value, Int32.MaxValue), Int32.MinValue));
        }
    }
}
