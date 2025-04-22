using SPodLib.AudioSample;

namespace SPodLib.Effect
{
    public class ChainEffect : IEffect
    {
        private List<IEffect> effects = new List<IEffect>();

        public void Add(IEffect effect)
        {
            effects.Add(effect);
        }

        public void Remove(IEffect effect)
        {
            effects.Remove(effect);
        }

        public Queue<Sample> Apply(Queue<Sample> samples)
        {
            Queue<Sample> result = samples;
            foreach (IEffect effect in effects)
                result = effect.Apply(result);
            return result;
        }
    }
}
