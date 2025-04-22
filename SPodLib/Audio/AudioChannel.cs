using ManagedBass;
using System.Security.Cryptography;

namespace SPodLib.Audio
{
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

        public void Reset()
        {
            Bass.StreamFree(_channel);
            Bass.Free();
        }

        public void Play()
        {
            Bass.ChannelPlay(_channel);
        }

        public void Pause()
        {
            Bass.ChannelPause(_channel);
        }

        public void Stop()
        {
            Bass.ChannelStop(_channel);
            Bass.ChannelSetPosition(_channel, 0);
        }

        public void Restart()
        {
            Bass.ChannelStop(_channel);
            Bass.ChannelPlay(_channel, true);
        }

        public void SetVolume(double volume)
        {
            Bass.ChannelSetAttribute(_channel, ChannelAttribute.Volume, volume);
        }

        public int Available()
        {
            return Bass.ChannelGetData(_channel, 0, (int)DataFlags.Available);
        }

        public double PlaybackLength()
        {
            return Bass.ChannelGetAttribute(_channel, ChannelAttribute.Buffer);
        }

        public void Put(byte[] buffer, int length)
        {
            Bass.StreamPutData(_channel, buffer, length);
        }

        public bool IsActive()
        {
            return Bass.ChannelIsActive(_channel) == PlaybackState.Playing;
        }

        public byte[] FFT()
        {
            byte[] buffer = new byte[1024];
            Bass.ChannelGetData(_channel, buffer, (int)DataFlags.FFT2048);
            return buffer;
        }
    }
}
