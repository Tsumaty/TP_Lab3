// using System.Globalization;

namespace TP_Lab3
{
    internal class Calculations : Exception
    {
        internal static double Func1(double x)
        {
            return Math.Sin(-x * x);
        }

        internal static double Func2(double x)
        {
            if (x == 0.0)
            {
                throw new Exception("Error in func2! Division by zero!");
            }
            double num = 1.0 / Math.Pow(x, 3.0) - 1.0;
            if (num < 0)
            {
                throw new Exception("Error in func2! Negative number under the root!");
            }
            return -Math.Sqrt(num);
        }

        internal static double Func3(double x)
        {
            if (x <= 0.0)
            {
                throw new Exception("Error in func3! Negative number or zero in the logarithm!");
            }
            else if (x == 1.0)
            {
                throw new Exception("Error in func3! Division by zero!");
            }
            return Math.Exp(-Math.Sin(5.0 / Math.Log(x)));
        }

        internal static double Func4(double x)
        {
            if (x == 0.0)
            {
                throw new Exception("Error in func4! Division by zero!");
            }
            double sum = 0.0;
            for (int j = 1; j <= 1000000; j++)
                sum += 1.0 / x + Math.Sqrt(j);
            return sum;
        }

        internal static double Func(double x)
        {
            /*try
            {*/
            double f3 = Func3(x);
            double f4 = Func4(x);
            double f2 = Func2(x);
            double f1 = Func1(x);
            return f1 + f2 + f3 + f4;
            /*}
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }*/
        }
    }
}
