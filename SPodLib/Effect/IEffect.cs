using SPodLib.AudioSample;

namespace SPodLib.Effect
{
    public interface IEffect
    {
        Queue<Sample> Apply(Queue<Sample> samples);
    }
}
