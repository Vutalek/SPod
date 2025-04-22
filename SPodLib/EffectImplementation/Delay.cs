using SPodLib.AudioSample;
using SPodLib.Effect;

namespace SPodLib.EffectImplementation
{
    public class Delay : Switchable, IEffect
    {
        private int _depth;
        private Queue<Sample> _history;
        private double _level;

        public Delay(int depth, double level) : base()
        {
            _depth = depth;
            _level = level;
            _history = new Queue<Sample>(depth);
            Reset();
        }

        public void ChangeLevel(float level)
        {
            _level = level;
        }

        public void ChangeDepth(int depth)
        {
            int old = _depth;
            _depth = depth;
            if (depth > old)
            {
                for (int i = 0; i < depth - old; i++)
                {
                    _history.Enqueue(new Sample());
                }
            }
            else if (depth < old)
            {
                for (int i = 0; i < old - depth; i++)
                {
                    _history.Dequeue();
                }
            }
        }

        public void Reset()
        {
            _history.Clear();
            for (int i = 0; i < _depth; i++)
            {
                _history.Enqueue(new Sample());
            }
        }

        public Queue<Sample> Apply(Queue<Sample> samples)
        {
            if (IsEnabled())
            {
                Queue<Sample> result = new Queue<Sample>(samples.Count);
                foreach (Sample sample in samples)
                {
                    _history.Enqueue(sample);
                    Sample delayed = sample + _level * _history.Dequeue();
                    result.Enqueue(delayed);
                }
                return result;
            }
            else return samples;
        }
    }
}
