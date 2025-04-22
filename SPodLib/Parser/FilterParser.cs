using SPodLib.EffectImplementation;
using System.Globalization;

namespace SPodLib.Parser
{
    public static class FilterParser
    {
        public static FIRFilter ParseFIR(string path)
        {
            StreamReader sr = new StreamReader(path);
            for (int i = 0; i < 8; i++)
                sr.ReadLine();
            int length = Convert.ToInt32(sr.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries)[4]);
            double[] result = new double[length];
            for (int i = 0; i < 5; i++)
                sr.ReadLine();
            for (int i = 0; i < length; i++)
                result[i] = Convert.ToDouble(sr.ReadLine()!.Trim(), CultureInfo.InvariantCulture);
            sr.Dispose();
            sr.Close();
            return new FIRFilter(result);
        }

        public static IIRFilter ParseIIR(string path, bool last_coef = false)
        {
            StreamReader sr = new StreamReader(path);
            for (int i = 0; i < 8; i++)
                sr.ReadLine();
            int length = Convert.ToInt32(sr.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries)[5]);
            for (int i = 0; i < 5; i++)
                sr.ReadLine();
            double[,] sosMatrix = new double[length, 6];
            for (int i = 0; i < length; i++)
            {
                string[] parsed_coefs = sr.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < 6; j++)
                    sosMatrix[i, j] = Convert.ToDouble(parsed_coefs[j], CultureInfo.InvariantCulture);
            }
            for (int i = 0; i < 2; i++)
                sr.ReadLine();
            double[] scales = new double[length];
            for (int i = 0; i < length; i++)
                scales[i] = Convert.ToDouble(sr.ReadLine()!.Trim(), CultureInfo.InvariantCulture);
            double coefGain = 1;
            if (!last_coef)
                coefGain = Convert.ToDouble(sr.ReadLine()!.Trim(), CultureInfo.InvariantCulture);
            List<Section> sections = new List<Section>(length);
            for (int i = 0; i < length; i++)
            {
                double[] b = new double[3];
                for (int j = 0; j < 3; j++)
                    b[j] = sosMatrix[i, j];
                double[] a = new double[3];
                for (int j = 0; j < 3; j++)
                    a[j] = sosMatrix[i, j + 3];
                sections.Add(new Section(b, a, scales[i]));
            }
            sr.Dispose();
            sr.Close();
            return new IIRFilter(sections, coefGain);
        }
    }
}
