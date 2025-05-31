namespace SPodLib.FFT
{
    /// <summary>
    /// Internal class for complex number operations.
    /// </summary>
    internal class ComplexNumber
    {
        private double _a;
        private double _b;

        public ComplexNumber(double a, double b = 0.0)
        {
            _a = a;
            _b = b;
        }

        public double Length()
        {
            return Math.Sqrt(Math.Pow(_a, 2) + Math.Pow(_b, 2));
        }

        public static ComplexNumber operator + (ComplexNumber left, ComplexNumber right)
        {
            double newa = left._a + right._a;
            double newb = left._b + right._b;
            return new ComplexNumber(newa, newb);
        }

        public static ComplexNumber operator * (ComplexNumber left, ComplexNumber right)
        {
            double newa = (left._a * right._a) - (left._b * right._b);
            double newb = (left._a * right._b) + (left._b * right._a);
            return new ComplexNumber(newa, newb);
        }

        public static ComplexNumber Exp(ComplexNumber num)
        {
            double a = Math.Cos(num._b);
            double b = Math.Sin(num._b);
            return new ComplexNumber(a, b);
        }
    }
}
