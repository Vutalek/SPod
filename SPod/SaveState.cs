namespace SPod
{
    internal class SaveState
    {
        public int Volume { get; set; }

        public bool IsFir { get; set; }
        public int Gain1 { get; set; }
        public int Gain2 { get; set; }
        public int Gain3 { get; set; }
        public int Gain4 { get; set; }
        public int Gain5 { get; set; }
        public int Gain6 { get; set; }

        public bool Delay { get; set; }
        public int DelayDepth { get; set; }
        public int DelayLevel { get; set; }

        public bool Envelop { get; set; }
        public int EnvelopSize { get; set; }
        public int EnvelopSin { get; set; }
        public int EnvelopTriag { get; set; }
        public int EnvelopRect { get; set; }
    }
}
