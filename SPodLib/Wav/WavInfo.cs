namespace SPodLib.Wav
{
    /// <summary>
    /// Wav metadata.
    /// </summary>
    public record WavInfo
    {
        public short AudioFormat;
        public short NumChannels;
        public int SampleRate;
        public int ByteRate;
        public short BlockAlign;
        public short BitsPerSample;
    }
}
