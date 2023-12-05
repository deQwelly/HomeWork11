using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11_2_.Classes
{
    [DeveloperInfo("Леша", "05.12.2023")]
    public class Rational
    {
        public readonly long numerator;
        public readonly long denominator;

        public Rational(long numerator, long denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public override bool Equals(object o)
        {
            if (o is Rational)
            {
                Rational r = (Rational)o;
                if ((numerator == r.numerator) && (denominator == r.denominator))
                {
                    return true;
                }
            }
            else if (decimal.TryParse(o.ToString(), out decimal o1))
            {
                if ((decimal)numerator / (decimal)denominator == o1)
                {
                    return true;
                }
            }
            return false;
        }

        /*
        public override bool Equals(object o)
        {
            if (o is Rational)
            {
                Rational number = (Rational)o;
                if ((numerator == number.numerator) && (denominator == number.denominator))
                {
                    return true;
                }
            }
            return false;
        }
        */

        public static bool operator ==(Rational a, object b)
        {
            if (a.Equals(b))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Rational a, object b)
        {
            if (a.Equals(b))
            {
                return false;
            }
            return true;
        }

        public static bool operator <(Rational a, object b)
        {
            decimal temp = (decimal)a.numerator / (decimal)a.denominator;
            if (b is Rational)
            {
                Rational r = (Rational)b;
                if (temp < ((decimal)r.numerator / (decimal)r.denominator))
                {
                    return true;
                }
            }
            else if (decimal.TryParse(b.ToString(), out decimal r))
            {
                if (temp < r)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator >(Rational a, object b)
        {
            decimal temp = (decimal)a.numerator / (decimal)a.denominator;
            if (b is Rational)
            {
                Rational r = (Rational)b;
                if (temp > ((decimal)r.numerator / (decimal)r.denominator))
                {
                    return true;
                }
            }
            else if (decimal.TryParse(b.ToString(), out decimal r))
            {
                if (temp > r)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator <=(Rational a, object b)
        {
            decimal temp = (decimal)a.numerator / (decimal)a.denominator;
            if (b is Rational)
            {
                Rational r = (Rational)b;
                if (temp <= ((decimal)r.numerator / (decimal)r.denominator))
                {
                    return true;
                }
            }
            else if (decimal.TryParse(b.ToString(), out decimal r))
            {
                if (temp <= r)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator >=(Rational a, object b)
        {
            decimal temp = (decimal)a.numerator / (decimal)a.denominator;
            if (b is Rational)
            {
                Rational r = (Rational)b;
                if (temp >= ((decimal)r.numerator / (decimal)r.denominator))
                {
                    return true;
                }
            }
            else if (decimal.TryParse(b.ToString(), out decimal r))
            {
                if (temp >= r)
                {
                    return true;
                }
            }
            return false;
        }

        public static Rational operator +(Rational a, Rational b)
        {
            if (a.denominator == b.denominator)
            {
                return new Rational(a.numerator + b.numerator, a.denominator);
            }
            return new Rational(a.numerator * b.denominator + b.numerator * a.denominator, a.denominator * b.denominator);
        }

        public static Rational operator -(Rational a, Rational b)
        {
            if (a.denominator == b.denominator)
            {
                return new Rational(a.numerator - b.numerator, a.denominator);
            }
            return new Rational((a.numerator * b.denominator) - (b.numerator * a.denominator), a.denominator * b.denominator);
        }

        public static Rational operator++(Rational a)
        {
            return (a + new Rational(1, 1));
        }

        public static Rational operator --(Rational a)
        {
            return (a - new Rational(1, 1));
        }

        public static Rational operator *(Rational a, Rational b)
        {
            return new Rational(a.numerator * b.numerator, a.denominator * b.denominator);
        }

        public static Rational operator /(Rational a, Rational b)
        {
            return new Rational(a.numerator * b.denominator, a.denominator * b.numerator);
        }

        public static Rational operator %(Rational a, Rational b)
        {
            return null;
        }

        public override string ToString()
        {
            return $"{numerator} / {denominator}";
        }

        public static explicit operator int(Rational a)
        {
            return (int)a.numerator / (int)a.denominator;
        }

        public static explicit operator float(Rational a)
        {
            return (float)a.numerator / (float)a.denominator;
        }
    }
}
