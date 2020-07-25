using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ClassMembers
{
    delegate double Function(double x);

    class DelegateExample
    {
        static double Square(double x)
        {
            return x * x;
        }

        static double[] Apply(double[] a, Function f)
        {
            double[] results = new double[a.Length];
            for(int i = 0; i != a.Length; i++)
            {
                results[i] = f(a[i]);
            }

            return results;
        }

        static string DoubleArrayToString(double[] a)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var i in a)
            {
                sb.Append($"{i} ");
            }
            return sb.ToString().Trim();
        }

        public static void Usage()
        {
            double[] a = { 0.0, 0.5, 1.0 };
            double[] squares = Apply(a, Square);
            double[] sines = Apply(a, Math.Sin);
            Multiplier multiplier = new Multiplier(2);
            double[] doubles = Apply(a, multiplier.Multiply);
            
            Console.WriteLine(DoubleArrayToString(a));
            Console.WriteLine(DoubleArrayToString(squares));
            Console.WriteLine(DoubleArrayToString(sines));
            Console.WriteLine(DoubleArrayToString(doubles));
        }
    }

    class Multiplier
    {
        double factor;

        public Multiplier(double factor)
        {
            this.factor = factor;
        }

        public double Multiply(double x)
        {
            return this.factor * x;
        }
    }
}
