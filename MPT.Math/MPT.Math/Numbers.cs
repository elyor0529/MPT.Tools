using System;

using NMath = System.Math;

namespace MPT.Math
{
    /// <summary>
    /// Contains static methods dealing generically with numbers. 
    /// Many methods are extensions to the numerical classes, so they can be used directly on a number.
    /// </summary>
    public static class Numbers
    {
        /// <summary>
        /// Default zero tolerance for operations.
        /// </summary>
        public const double ZeroTolerance = 1E-20;



        /// <summary>
        /// Value is greater than 0.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsPositive(this int value)
        {
            return (value > 0);
        }

        /// <summary>
        /// Value is greater than the zero-tolerance.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static bool IsPositive(this double value, double tolerance = ZeroTolerance)
        {
            if (value.IsZero(tolerance)) { return false; }
            return (value > NMath.Abs(tolerance));
        }

        /// <summary>
        /// Value is less than zero.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNegative(this int value)
        {
            return (value < 0);
        }

        /// <summary>
        /// Value is less than the zero-tolerance.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static bool IsNegative(this double value, double tolerance = ZeroTolerance)
        {
            if (value.IsZero(tolerance)) { return false; }
            return (value < NMath.Abs(tolerance));
        }

        /// <summary>
        /// Value is within the absolute value of the zero-tolerance.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static bool IsZero(this double value, double tolerance = ZeroTolerance)
        {
            return (NMath.Abs(value) < NMath.Abs(tolerance));
        }

        /// <summary>
        /// Value is equal to the provided value within the absolute value of the zero-tolerance.
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static bool IsEqualTo(this double value1, double value2, double tolerance = ZeroTolerance)
        {
            return AreEqual(value1, value2, tolerance);
        }

        /// <summary>
        /// Value is greater than the provided value, within the absolute value of the zero-tolerance.
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static bool IsGreaterThan(this double value1, double value2, double tolerance = ZeroTolerance)
        {
            return ((value1 - value2) > NMath.Abs(tolerance));
        }

        /// <summary>
        /// Value is less than the provided value, within the absolute value of the zero-tolerance.
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static bool IsLessThan(this double value1, double value2, double tolerance = ZeroTolerance)
        {
            if (value1.IsEqualTo(value2, tolerance)) { return false; }
            return ((value1 - value2) < NMath.Abs(tolerance));
        }

        /// <summary>
        /// Values are equal within the absolute value of the zero-tolerance.
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static bool AreEqual(double value1, double value2, double tolerance = ZeroTolerance)
        {
            if (double.IsPositiveInfinity(value1) && double.IsPositiveInfinity(value2)) { return true; }
            if (double.IsNegativeInfinity(value1) && double.IsNegativeInfinity(value2)) { return true; }
            return (NMath.Abs(value1 - value2) < NMath.Abs(tolerance));
        }

        /// <summary>
        /// Value is an odd number.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsOdd(this int value)
        {
            return (value%2 != 0);
        }

        /// <summary>
        /// Value is an even number.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEven(this int value)
        {
            return !IsOdd(value);
        }

        /// <summary>
        /// A whole number greater than 1, whose only two whole-number factors are 1 and itself. 
        /// Uses the 'Sieve of Eratosthenes', which is very efficient for solving small primes (i.e. &lt; 10,000,000,000).
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsPrime(this int value)
        {
            value = NMath.Abs(value);
            if (value == 0)
            {
                return false;
            }
            if (value == 1)
            {
                return false;
            }
            if (value == 2)
            {
                return true;
            }
            if (value == 3)
            {
                return true;
            }
            if (IsEven(value)) /* For all > 2*/
            {
                return false;
            }
            if (value == 5)
            {
                return true;
            }
            if (LastDigit(value) == 5) /* For all > 5*/
            {
                return false;
            }

            double limit = NMath.Sqrt(value);

            for (int i = 3; i <= limit; i += 2)
            {
                if (value%i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// A whole number that can be divided evenly by numbers other than 1 or itself.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsComposite(this int value)
        {
            if (value == 0)
            {
                return false;
            }
            if (value == 1)
            {
                return false;
            }
            return !IsPrime(value);
        }




        /// <summary>
        /// Returns the last digit without sign of the value provided.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int LastDigit(this int value)
        {
            return NMath.Abs((value%10));
        }

        /// <summary>
        /// The product of an integer and all the integers below it; e.g., factorial four ( 4! ) is equal to 24.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Factorial(this int value)
        {
            if (value == 0)
            {
                return 0;
            }
            int result = 1;
            for (int i = 1; i <= value; i++)
            {
                result *= i;
            }
            return result;
        }

        /// <summary>
        /// Returns the value squared..
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Squared(this int value)
        {
            return (value*value);
        }

        /// <summary>
        /// Returns the value squared.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double Squared(this double value)
        {
            return (value * value);
        }

        /// <summary>
        /// Returns the value cubed.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Cubed(this int value)
        {
            return (value * value * value);
        }

        /// <summary>
        /// Returns the value cubed.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double Cubed(this double value)
        {
            return (value * value * value);
        }

        /// <summary>
        /// Returns the value raised to the power provided.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public static double Pow(this int value, int power)
        {
            if (value == 0 && power.IsNegative())
            {
                throw new DivideByZeroException($"{value}^{power} results in a division by zero, which is undefined.");
            }
            return NMath.Pow(value, power);
        }

        /// <summary>
        /// Returns the value raised to the power provided.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public static double Pow(this double value, double power)
        {
            if (value == 0 && power.IsNegative(0))
            {
                throw new DivideByZeroException($"{value}^{power} results in a division by zero, which is undefined.");
            }
            return NMath.Pow(value, power);
        }
    }
}

