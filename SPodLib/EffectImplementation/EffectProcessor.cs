using SPodLib.Buffer;
using SPodLib.Effect;
using SPodLib.Processor;
using SPodLib.AudioSample;

namespace SPodLib.EffectImplementation
{
    public class EffectProcessor : Processor.Processor
    {
        private IEffect _effect;

        public EffectProcessor(IEffect effect, SampleBuffer input, SampleBuffer output) : base(input, output)
        {
            _effect = effect;
        }

        public override void Process()
        {
            NotifyRead();
            if (_inStream.CanRead() && _outStream.CanWrite())
            {
                Queue<Sample> input = _inStream.Read();
                Queue<Sample> processed = _effect.Apply(input);
                _outStream.Write(processed);
            }
            NotifyNext();
        }
    }
}
