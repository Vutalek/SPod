using SPodLib.AudioSample;

namespace SPodLib.Effect
{
    /// <summary>
    /// Interfacae for effects.
    /// </summary>
    public interface IEffect
    {
        /// <summary>
        /// Apply effect to samples.
        /// </summary>
        /// <param name="samples">Input samples.</param>
        /// <returns>Output samples.</returns>
        Queue<Sample> Apply(Queue<Sample> samples);
    }
}
