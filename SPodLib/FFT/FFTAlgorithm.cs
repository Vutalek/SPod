namespace SPodLib.FFT
{
    public static class FFTAlgorithm
    {
        public static double[] FFT(double[] samples)
        {
            ComplexNumber[] input = new ComplexNumber[samples.Length];
            for (int i = 0; i < samples.Length; i++)
                input[i] = new ComplexNumber(samples[i]);

            ComplexNumber[] complexOutput = FFT(input);

            double[] output = new double[samples.Length];
            for (int i = 0; i < samples.Length; i++)
                output[i] = complexOutput[i].Length();
            return output;
        }
        private static ComplexNumber[] FFT(ComplexNumber[] samples)
        {
            if (samples.Length == 1)
            {
                return samples;
            }

            int size = samples.Length;

            ComplexNumber[] even = new ComplexNumber[size / 2];
            ComplexNumber[] odd = new ComplexNumber[size / 2];

            for (int i = 0; i < size; i++)
            {
                if (i % 2 == 0)
                    even[i / 2] = samples[i];
                else odd[i / 2] = samples[i];
            }

            even = FFT(even);
            odd = FFT(odd);

            ComplexNumber[] exponents = new ComplexNumber[size];
            for (int i = 0; i < size; i++)
                exponents[i] = new ComplexNumber(0, -2 * Math.PI * i / size);

            ComplexNumber[] firstHalf = new ComplexNumber[size / 2];
            ComplexNumber[] secondHalf = new ComplexNumber[size / 2];

            for (int i = 0; i < size / 2; i++)
            {
                firstHalf[i] = even[i] + exponents[i] * odd[i];
                secondHalf[i] = even[i] + exponents[i + size / 2] * odd[i];
            }

            ComplexNumber[] result = new ComplexNumber[size];
            firstHalf.CopyTo(result, 0);
            secondHalf.CopyTo(result, size / 2);
            return result;
        }
    }
}
