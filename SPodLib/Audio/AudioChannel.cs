using ManagedBass;

namespace SPodLib.Audio
{
    /// <summary>
    /// Wrap-class for Bass Channel.
    /// </summary>
    public class AudioChannel
    {
        private int _channel;
        
        public AudioChannel(int numChannels, int bitsPerSample, int sampleRate)
        {
            DeviceInitFlags deviceFlags;
            BassFlags channelFlags;
            if (numChannels == 1)
                deviceFlags = DeviceInitFlags.Mono;
            else
                deviceFlags = DeviceInitFlags.Stereo;
            if (bitsPerSample == 8)
            {
                deviceFlags |= DeviceInitFlags.Byte;
                channelFlags = BassFlags.Byte;
            }
            else
            {
                deviceFlags |= DeviceInitFlags.Bits16;
                channelFlags = BassFlags.Default;
            }

            Bass.Init(-1, sampleRate, deviceFlags);
            _channel = Bass.CreateStream(sampleRate, numChannels, channelFlags, StreamProcedureType.Push);
        }

        ~AudioChannel()
        {
            Reset();
        }

        /// <summary>
        /// Free resources of Bass.
        /// </summary>
        public void Reset()
        {
            Bass.StreamFree(_channel);
            Bass.Free();
        }

        /// <summary>
        /// Play channel.
        /// </summary>
        public void Play()
        {
            Bass.ChannelPlay(_channel);
        }

        /// <summary>
        /// Pause channel.
        /// </summary>
        public void Pause()
        {
            Bass.ChannelPause(_channel);
        }

        /// <summary>
        /// Stop channel (stop and restart).
        /// </summary>
        public void Stop()
        {
            Bass.ChannelStop(_channel);
            Bass.ChannelSetPosition(_channel, 0);
        }

        /// <summary>
        /// Restart audio without stopping.
        /// </summary>
        public void Restart()
        {
            Bass.ChannelStop(_channel);
            Bass.ChannelPlay(_channel, true);
        }

        /// <summary>
        /// Change volume.
        /// </summary>
        /// <param name="volume">
        /// Volume of a channel. Must be between 0 and 1.
        /// </param>
        public void SetVolume(double volume)
        {
            Bass.ChannelSetAttribute(_channel, ChannelAttribute.Volume, volume);
        }

        /// <summary>
        /// Check availability of channel.
        /// </summary>
        /// <returns>Current number of samples in channel buffer.</returns>
        public int Available()
        {
            return Bass.ChannelGetData(_channel, 0, (int)DataFlags.Available);
        }

        /// <summary>
        /// Method to put data in channels buffer for playing.
        /// </summary>
        /// <param name="buffer">Data to put.</param>
        /// <param name="length">Length of data.</param>
        public void Put(byte[] buffer, int length)
        {
            Bass.StreamPutData(_channel, buffer, length);
        }

        /// <summary>
        /// Check if channel is active (not stalled).
        /// </summary>
        /// <returns>Returns true if channel is playing and false otherwise</returns>
        public bool IsActive()
        {
            return Bass.ChannelIsActive(_channel) == PlaybackState.Playing;
        }
    }
}
