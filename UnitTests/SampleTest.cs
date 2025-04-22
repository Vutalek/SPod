using SPodLib.AudioSample;

namespace UnitTests
{
    [TestClass]
    public class SampleTest
    {
        static Sample sample1;
        static Sample sample2;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            Sample.SetResolution(Resolution.Bit16);
            Sample.SetStereo(false);
            sample1 = new Sample([34, 1]);
            sample2 = new Sample([129, 2]);
        }
        [TestMethod]
        public void Addition()
        {
            Sample sum = sample1 + sample2;
            Sample answer = new Sample([163, 3]);
            Assert.IsTrue(sum == answer);
        }

        [TestMethod]
        public void Subtraction()
        {
            Sample subt = sample1 - sample2;
            Sample answer = new Sample([161, 254]);
            Assert.IsTrue(subt == answer);
        }

        [TestMethod]
        public void Multiplication()
        {
            // Obviously overflowed
            Sample mult = new Sample((sample1 * sample2).Bytes());
            Sample answer = new Sample([255, 127]);
            Assert.IsTrue(mult == answer);
        }

        [TestMethod]
        public void Scaling()
        {
            Sample scaled = sample1 * 2.5;
            Sample answer = new Sample([213, 2]);
            Assert.IsTrue(scaled == answer);
        }

        [TestMethod]
        public void MakingByteArrayFromSamplesList()
        {
            List<Sample> samples = new List<Sample> { new Sample(1), new Sample(2), new Sample(3) };
            byte[] buffer = new byte[samples.Count * 2];
            for (int i = 0; i < samples.Count; i++)
                Array.Copy(samples[i].Bytes(), 0, buffer, 2 * i, 2);
            for (int i = 0; i < buffer.Length; i++)
                Console.WriteLine(buffer[i]);
        }
    }
}