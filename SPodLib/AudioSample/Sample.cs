namespace SPodLib.AudioSample
{
    /// <summary>
    /// Class representing samples. Wraps byte operations inside.
    /// </summary>
    public class Sample
    {
        private static int _resolution = 16;
        private static int _maxValue = (int)Math.Pow(2, 15) - 1;
        private static int _minValue = -((int)Math.Pow(2, 15) - 1);
        private static bool _stereo = false;

        private int _sampleR;
        private int _sampleL;

        private byte[] ExtendSample(byte[] sample)
        {
            byte[] zeros = new byte[4 - _resolution / 8];
            if (sample[sample.Length - 1] >= 128)
                Array.Fill<byte>(zeros, 255);
            else Array.Fill<byte>(zeros, 0);

            byte[] extended = new byte[4];
            sample.CopyTo(extended, 0);
            zeros.CopyTo(extended, sample.Length);
            return extended;
        }

        /// <summary>
        /// Creates new sample.
        /// </summary>
        /// <param name="sample">Sample must be in little endian byte order.</param>
        public Sample(byte[] sample)
        {
            if (_stereo)
            {
                _sampleR = BitConverter.ToInt32(ExtendSample(sample.Take(sample.Length / 2).ToArray()));
                _sampleL = BitConverter.ToInt32(ExtendSample(sample.Skip(sample.Length / 2).ToArray()));
            }
            else
            {
                byte[] extended = ExtendSample(sample);
                _sampleR = BitConverter.ToInt32(extended);
                _sampleL = BitConverter.ToInt32(extended);
            }
        }

        public Sample(int sampleR = 0, int sampleL = 0)
        {
            _sampleR = sampleR;
            _sampleL = sampleL;
        }

        /// <summary>
        /// Sets global resolution for all samples.
        /// </summary>
        /// <param name="bits"></param>
        public static void SetResolution(Resolution bits)
        {
            _resolution = (int)bits;
            _maxValue = (int)Math.Pow(2, _resolution - 1) - 1;
            _minValue = -((int)Math.Pow(2, _resolution - 1) - 1);
        }

        /// <summary>
        /// Sets stereo mode.
        /// </summary>
        /// <param name="stereo">true if must me stereo.</param>
        public static void SetStereo(bool stereo)
        {
            _stereo = stereo;
        }

        /// <summary>
        /// Checks if Sample in stereo mode.
        /// </summary>
        /// <returns>true if stereo.</returns>
        public static bool IsStereo()
        {
            return _stereo;
        }

        /// <summary>
        /// </summary>
        /// <returns>Gets the byte representation of sample.</returns>
        public byte[] Bytes()
        {
            int limitedR = Math.Max(Math.Min(_sampleR, _maxValue), _minValue);
            int limitedL = Math.Max(Math.Min(_sampleL, _maxValue), _minValue);
            if (_stereo)
            {
                byte[] R = BitConverter.GetBytes(limitedR).Take(_resolution / 8).ToArray();
                byte[] L = BitConverter.GetBytes(limitedL).Take(_resolution / 8).ToArray();
                byte[] sample = new byte[R.Length + L.Length];
                R.CopyTo(sample, 0);
                L.CopyTo(sample, R.Length);
                return sample;
            }
            else
            {
                return BitConverter.GetBytes(limitedR).Take(_resolution / 8).ToArray();
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>Gets the value representation of sample (first element is right channel,
        /// second element is left channel).</returns>
        public int[] Values()
        {
            return [_sampleR, _sampleL];
        }

        public static bool operator ==(Sample left, Sample right)
        {
            if (left._sampleR == right._sampleR && left._sampleL == right._sampleL)
                return true;
            else return false;
        }

        public static bool operator !=(Sample left, Sample right)
        {
            if (left._sampleR == right._sampleR && left._sampleL == right._sampleL)
                return false;
            else return true;
        }

        public static bool operator <(Sample left, Sample right)
        {
            if (left._sampleR < right._sampleR && left._sampleL < right._sampleL)
                return true;
            else return false;
        }

        public static bool operator >(Sample left, Sample right)
        {
            if (left._sampleR > right._sampleR && left._sampleL > right._sampleL)
                return true;
            else return false;
        }

        public static bool operator <=(Sample left, Sample right)
        {
            if (left._sampleR <= right._sampleR && left._sampleL <= right._sampleL)
                return true;
            else return false;
        }

        public static bool operator >=(Sample left, Sample right)
        {
            if (left._sampleR >= right._sampleR && left._sampleL >= right._sampleL)
                return true;
            else return false;
        }

        public static Sample operator +(Sample left, Sample right)
        {
            int sampleR = left._sampleR + right._sampleR;
            int sampleL = left._sampleL + right._sampleL;
            return new Sample(sampleR, sampleL);
        }

        public static Sample operator +(Sample sample, int offset)
        {
            int sampleR = sample._sampleR + offset;
            int sampleL = sample._sampleL + offset;
            return new Sample(sampleR, sampleL);
        }

        public static Sample operator +(int offset, Sample sample)
        {
            return sample + offset;
        }

        public static Sample operator -(Sample sample)
        {
            return new Sample(-sample._sampleR, -sample._sampleL);
        }

        public static Sample operator -(Sample left, Sample right)
        {
            int sampleR = left._sampleR - right._sampleR;
            int sampleL = left._sampleL - right._sampleL;
            return new Sample(sampleR, sampleL);
        }

        public static Sample operator -(Sample sample, int offset)
        {
            int sampleR = sample._sampleR - offset;
            int sampleL = sample._sampleL - offset;
            return new Sample(sampleR, sampleL);
        }

        public static Sample operator -(int offset, Sample sample)
        {
            int sampleR = offset - sample._sampleR;
            int sampleL = offset - sample._sampleL;
            return new Sample(sampleR, sampleL);
        }

        public static Sample operator *(Sample left, Sample right)
        {
            int sampleR = left._sampleR * right._sampleR;
            int sampleL = left._sampleL * right._sampleL;
            return new Sample(sampleR, sampleL);
        }

        public static Sample operator *(double scale, Sample sample)
        {
            int sampleR = (int)(scale * sample._sampleR);
            int sampleL = (int)(scale * sample._sampleL);
            return new Sample(sampleR, sampleL);
        }

        public static Sample operator *(Sample sample, double scale)
        {
            return scale * sample;
        }

        public static Sample operator *(decimal scale, Sample sample)
        {
            int sampleR = (int)(scale * sample._sampleR);
            int sampleL = (int)(scale * sample._sampleL);
            return new Sample(sampleR, sampleL);
        }

        public static Sample operator *(Sample sample, decimal scale)
        {
            return scale * sample;
        }

        public static Sample operator /(Sample left, Sample right)
        {
            int sampleR = left._sampleR / right._sampleR;
            int sampleL = left._sampleL / right._sampleL;
            return new Sample(sampleR, sampleL);
        }

        public static Sample operator /(Sample sample, double scale)
        {
            int sampleR = (int)(sample._sampleR / scale);
            int sampleL = (int)(sample._sampleL / scale);
            return new Sample(sampleR, sampleL);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            return Equals((Sample)obj);
        }

        public bool Equals(Sample sample)
        {
            return sample is not null && this == sample;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_sampleR, _sampleL);
        }
    }
}
