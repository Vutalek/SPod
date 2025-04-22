using SPodLib.AudioSample;
using SPodLib.EffectImplementation;
using SPodLib.Parser;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IIRFilter a = FilterParser.ParseIIR("untitledf.fcf");
        }
    }
}
