using SPodLib.AudioSample;
using SPodLib.Buffer;

namespace UnitTests
{
    [TestClass]
    public class RingBufferTest
    {
        [TestMethod]
        public void TestBuffer()
        {
            CycledLinearBuffer rb = new CycledLinearBuffer(3);
            rb.Write(new List<Sample> { new Sample(10), new Sample(10), new Sample(10) });
            rb.Write(new List<Sample> { new Sample(20), new Sample(20), new Sample(20) });
            foreach(Sample sample in rb.Read())
                Console.WriteLine(sample.Values()[0]);
            foreach (Sample sample in rb.Read())
                Console.WriteLine(sample.Values()[0]);
        }

        [TestMethod]
        public void LinearBufferTest()
        {
            LinearBuffer lb = new LinearBuffer(6);
            Queue<Sample> q1 = new Queue<Sample>(3);
            q1.Enqueue(new Sample(10));
            q1.Enqueue(new Sample(20));
            q1.Enqueue(new Sample(30));

            Queue<Sample> q2 = new Queue<Sample>(3);
            q2.Enqueue(new Sample(15));
            q2.Enqueue(new Sample(25));
            q2.Enqueue(new Sample(35));

            lb.Write(q1);
            lb.Write(q2);

            Queue<Sample> q3 = lb.Read();
            foreach (Sample s in q3)
                Console.WriteLine(s.Values()[0]);
            Queue<Sample> q4 = lb.Read();
            foreach (Sample s in q4)
                Console.WriteLine(s.Values()[0]);
        }
    }
}
