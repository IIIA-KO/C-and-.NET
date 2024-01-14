using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8
{
    internal class Rational
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        private void GCD()
        {
            int a = Math.Abs(Numerator), b = Math.Abs(Denominator);
            a = (a != 0) ? a : 1;
            while (a != b)
            {
                if (a > b) a -= b;
                else b -= a;
            }
            Numerator = Numerator / a;
            Denominator = Denominator / a;
            if (Denominator < 0)
            {
                Numerator *= -1;
                Denominator *= -1;
            }
        }
        public Rational(int n, int d)
        {
            if (d == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.", nameof(d));
            }
            Numerator = n;
            Denominator = d;
            GCD();
        }
        public Rational(int n)
        {
            Denominator = n;
            Denominator = 1;
        }

        public void Print()
        {
            Console.Write(Numerator);
            if (Denominator != 1) Console.WriteLine($" / {Denominator}");
        }

        public static Rational operator +(Rational a, Rational b)
        {
            return new Rational(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }
        public static Rational operator -(Rational a, Rational b)
        {
            return new Rational(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }
        public static Rational operator *(Rational a, Rational b)
        {
            return new Rational(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }
        public static Rational operator /(Rational a, Rational b)
        {
            if (b.Numerator == 0)
            {
                throw new DivideByZeroException();
            }
            return new Rational(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static bool operator ==(Rational a, Rational b)
        {
            return a.Numerator == b.Numerator && a.Denominator == b.Denominator;
        }
        public static bool operator !=(Rational a, Rational b)
        {
            return a.Numerator != b.Numerator || a.Denominator != b.Denominator;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Rational r)
                return this == r;
            else
                throw new ArgumentException();
        }
    }
}
