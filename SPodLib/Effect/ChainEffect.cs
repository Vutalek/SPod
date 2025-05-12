using SPodLib.AudioSample;

namespace SPodLib.Effect
{
    /// <summary>
    /// Class representing chain of IEffect objects.
    /// </summary>
    public class ChainEffect : IEffect
    {
        private List<IEffect> effects = new List<IEffect>();

        /// <summary>
        /// Add effect to chain.
        /// </summary>
        /// <param name="effect"></param>
        public void Add(IEffect effect)
        {
            effects.Add(effect);
        }

        /// <summary>
        /// Remove effect from chain.
        /// </summary>
        /// <param name="effect"></param>
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
