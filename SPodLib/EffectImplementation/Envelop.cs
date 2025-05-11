using SPodLib.AudioSample;
using SPodLib.Effect;

namespace SPodLib.EffectImplementation
{
    public class Envelop : Switchable, IEffect
    {
        private int _size;

        private double[] _sin;
        private double _sinDepth;

        private double[] _triag;
        private double _triagDepth;

        private double[] _rect;
        private double _rectDepth;

        private int _currentPosition = 0;

        public Envelop(int size) : base()
        {
            _sinDepth = 0.0;
            _triagDepth = 1.0;
            _rectDepth = 1.0;

            _sin = new double[_size];
            _triag = new double[_size];
            _rect = new double[_size];
            SetSize(size);
        }

        public void SetSize(int size)
        {
            _size = size;
            _sin = new double[_size];
            _triag = new double[_size];
            _rect = new double[_size];
            GeneratePatterns();
        }

        private void GeneratePatterns()
        {
            for(int i = 0; i < _size; i++)
            {
                _sin[i] = (1.0 - _sinDepth) / 2.0 * Math.Sin(2 * Math.PI * i / _size) + (1.0 + _sinDepth) / 2.0;
                if (i < _size / 2)
                {
                    _triag[i] = (2.0 * (1.0 - _triagDepth) / _size) * i + _triagDepth;
                    _rect[i] = 1.0;
                }
                else
                {
                    _triag[i] = (-2.0 * (1.0 - _triagDepth) / _size) * i + (2.0 - _triagDepth);
                    _rect[i] = _rectDepth;
                }
            }
        }

        public void ChangeSinDepth(double depth)
        {
            _sinDepth = depth;
            GeneratePatterns();
        }

        public void ChangeTriagDepth(double depth)
        {
            _triagDepth = depth;
            GeneratePatterns();
        }

        public void ChangeRectDepth(double depth)
        {
            _rectDepth = depth;
            GeneratePatterns();
        }

        public Queue<Sample> Apply(Queue<Sample> samples)
        {
            if (IsEnabled())
            {
                Queue<Sample> result = new Queue<Sample>(samples.Count);
                foreach (Sample sample in samples)
                {
                    Sample enveloped = sample *
                        (
                            _sin[_currentPosition] *
                            _triag[_currentPosition] *
                            _rect[_currentPosition]
                        );
                    result.Enqueue(enveloped);
                    _currentPosition = (_currentPosition + 1) % _size;
                }
                return result;
            }
            else return samples;
        }
    }
}
