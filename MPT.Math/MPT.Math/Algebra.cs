
using System;
using System.Windows;
using NMath = System.Math;

using Num = MPT.Math.Numbers;

namespace MPT.Math
{
    /// <summary>
    /// Contains static methods for common algebraic operations.
    /// </summary>
    public static class Algebra
    {       
        /// <summary>
        /// Performs the square root of the sum of the squares of the provided values.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static double SRSS(params double[] values)
        {
            double sumOfSquares = 0;
            foreach (double value in values)
            {
                sumOfSquares += value.Squared();
            }

            return NMath.Sqrt(sumOfSquares);
        }


       
    }
}
