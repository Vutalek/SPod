using SPodLib.AudioSample;
using SPodLib.Buffer;
using SPodLib.Wav;

namespace UnitTests
{
    [TestClass]
    public class WavTest
    {
        [TestMethod]
        public void MetadataTest()
        {
            WavReader wav = new WavReader(null);
            wav.SetSource(File.Open("../../../TestSounds/load3.wav", FileMode.Open));
            Console.WriteLine(wav.Meta.AudioFormat);
            Console.WriteLine(wav.Meta.NumChannels);
            Console.WriteLine(wav.Meta.SampleRate);
            Console.WriteLine(wav.Meta.ByteRate);
            Console.WriteLine(wav.Meta.BlockAlign);
            Console.WriteLine(wav.Meta.BitsPerSample);
        }
        [TestMethod]
        public void ReadTest()
        {
            LinearBuffer buffer = new LinearBuffer(10);
            WavReader wav = new WavReader(buffer);
            wav.SetSource(File.Open("../../../TestSounds/half-life-crowbar.wav", FileMode.Open));
            for (int i = 0; i < 10; i++)
            {
                wav.Read();
                foreach (Sample sample in buffer.Read())
                    Console.WriteLine(sample.Values()[0]);
                Console.WriteLine("asd");
            }
        }
    }
}
