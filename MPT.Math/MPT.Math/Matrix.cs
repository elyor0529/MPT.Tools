using System;

namespace MPT.Math
{
    public static class Matrix
    {
        /// <summary>
        /// Returns the cross product/determinant of the points. 
        /// x1*y2-x2*y1
        /// </summary>
        /// <param name="point1">First point.</param>
        /// <param name="point2">Second point.</param>
        /// <returns></returns>
        public static double CrossProduct(this Point point1, Point point2)
        {
            return (point1.X * point2.Y - point2.X * point1.Y);
        }


        public static double GetDeterminant()
        {
            throw new NotImplementedException();
        }
    }
}
