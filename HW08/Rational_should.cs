using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.RationalNumbers
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
    }



    [TestFixture]
    public class Rational_should
    {
        public void Equal(int numerator, int denominator, Rational b)
        {
            Assert.False(b.IsNan);
            Assert.AreEqual(numerator, b.Numerator);
            Assert.AreEqual(denominator, b.Denominator);
        }

        [Test]
        public void InitializeSimpleRatioCorrectly()
        {
            Equal(1, 2, new Rational(1, 2));
        }

        [Test]
        public void InitializeWitoutDenomerator()
        {
            Equal(4, 1, new Rational(4));
        }

        [Test]
        public void InitializeWithZeroDenomerator()
        {
            Assert.True(new Rational(2, 0).IsNan);
        }

        public void BeCorrectWithZeroNumerator()
        {
            Equal(0, 1, new Rational(0, 5));
        }

        [Test]
        public void InitializeAndReduce1()
        {
            Equal(1, 2, new Rational(2, 4));
        }

        [Test]
        public void InitializeAndReduce2()
        {
            Equal(-1, 2, new Rational(-2, 4));
        }

        [Test]
        public void InitializeAndReduce3()
        {
            Equal(-1, 2, new Rational(2, -4));
        }

        [Test]
        public void InitializeAndReduce4()
        {
            Equal(1, 2, new Rational(-2, -4));
        }

        [Test]
        public void Sum()
        {
            Equal(1, 2, new Rational(1, 4) + new Rational(1, 4));
        }

        [Test]
        public void SumWithNan()
        {
            Assert.True((new Rational(1, 2) + new Rational(1, 0)).IsNan);
            Assert.True((new Rational(1, 0) + new Rational(1, 2)).IsNan);
        }

        [Test]
        public void Subtract()
        {
            Equal(1, 4, new Rational(1, 2) - new Rational(1, 4));
        }

        [Test]
        public void SubtractWithNan()
        {
            Assert.True((new Rational(1, 2) - new Rational(1, 0)).IsNan);
            Assert.True((new Rational(1, 0) - new Rational(1, 2)).IsNan);
        }


        [Test]
        public void Multiply()
        {
            Equal(-1, 4, new Rational(-1, 2) * new Rational(1, 2));
        }

        [Test]
        public void MultiplyWithNan()
        {
            Assert.True((new Rational(1, 2) * new Rational(1, 0)).IsNan);
            Assert.True((new Rational(1, 0) * new Rational(1, 2)).IsNan);
        }


        [Test]
        public void Divide()
        {
            Equal(-1, 2, new Rational(1,4) / new Rational(-1,2));
        }

        [Test]
        public void DivideWithNan()
        {
            Assert.True((new Rational(1, 2) / new Rational(1, 0)).IsNan);
            Assert.True((new Rational(1, 0)/ new Rational(1, 2)).IsNan);
        }

        [Test]
        public void DivideToZero()
        {
            Assert.True((new Rational(1, 2) / new Rational(0, 5)).IsNan);
        }

        [Test]
        public void ConvertToDouble()
        {
            double v = new Rational(1, 2);
            Assert.AreEqual(0.5, v, 1e-7);
        }

        [Test]
        public void ConvertFromInt()
        {
            Rational r = 5;
            Equal(5, 1, r);
        }

        [Test]
        public void ExplicitlyConvertToInt()
        {
            int a = (int)new Rational(2, 1);
            Assert.AreEqual(2, a);
        }

       
    }
}
