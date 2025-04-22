using SPodLib.AudioSample;
using SPodLib.Effect;

namespace SPodLib.EffectImplementation
{
    public class IIRFilter : Switchable, IEffect
    {
        private List<Section> _sections;
        private double _coef_gain;
        private double _gain = 0; //dB

        public IIRFilter(List<Section> sections, double coef_gain)
        {
            _sections = sections;   
            _coef_gain = coef_gain;
        }

        public void ChangeGain(double gain)
        {
            _gain = gain;
        }

        public Queue<Sample> Apply(Queue<Sample> samples)
        {
            if (IsEnabled())
            {
                Queue<Sample> result = new Queue<Sample>(samples.Count);
                foreach (Sample sample in samples)
                {
                    double[] temp_double = [sample.Values()[0], sample.Values()[1]];
                    foreach (Section s in _sections)
                        temp_double = s.Apply(temp_double);
                    
                    temp_double[0] *= _coef_gain;
                    temp_double[0] *= Math.Pow(10.0, _gain / 20.0);
                    temp_double[1] *= _coef_gain;
                    temp_double[1] *= Math.Pow(10.0, _gain / 20.0);
                    result.Enqueue(new Sample(Clip(temp_double[0]), Clip(temp_double[1])));
                }
                return result;
            }
            else return samples;
        }

        public void Reset()
        {
            foreach (Section s in _sections)
                s.Reset();
        }

        private Int32 Clip(double value)
        {
            return Convert.ToInt32(Math.Max(Math.Min(value, Int32.MaxValue), Int32.MinValue));
        }
    }
}
