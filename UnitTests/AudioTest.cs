using SPodLib.Audio;
using SPodLib.AudioSample;
using SPodLib.Buffer;
using SPodLib.EffectImplementation;
using SPodLib.Wav;

namespace UnitTests
{
    [TestClass]
    public class AudioTest
    {
        [TestMethod]
        public void SystemTest()
        {
            Sample.SetStereo(false);
            Sample.SetResolution(Resolution.Bit16);
            int size = 10000;
            LinearBuffer buffer1 = new LinearBuffer(size);

            WavReader wav = new WavReader(buffer1);
            wav.SetSource(File.Open("../../../../UnitTests/TestSounds/half-life-health-charger-sound.wav", FileMode.Open));

            AudioPlayer player = new AudioPlayer(buffer1, wav.Meta);

            wav.OnEnd += () => Console.WriteLine("Ended");
            wav.OnEnd += player.Stop;
            player.OnRead += wav.Read;

            Task tsk = new Task(player.Play);
            tsk.Start();
            Thread.Sleep(10000);
        }
    }
}
