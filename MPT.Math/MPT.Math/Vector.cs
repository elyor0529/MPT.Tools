using System.Windows;

using NMath = System.Math;
using NVector = System.Windows.Vector;
using NVector3D = System.Windows.Media.Media3D.Vector3D;

using Num = MPT.Math.Numbers;

namespace MPT.Math
{
    /// <summary>
    /// Library of methods related to vectors.
    /// </summary>
    public static class Vector
    {
        /// <summary>
        /// True: Segments are parallel, on the same line, oriented in the same direction.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool IsColinearSameDirection(NVector vector1, NVector vector2, double tolerance = Num.ZeroTolerance)
        {
            return (ConcavityColinearity(vector1, vector2).IsEqualTo(1, tolerance));
        }

        /// <summary>
        /// Vectors form a concave angle.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool IsConcave(NVector vector1, NVector vector2, double tolerance = Num.ZeroTolerance)
        {
            return (ConcavityColinearity(vector1, vector2).IsGreaterThan(0, tolerance));
        }

        /// <summary>
        /// Vectors form a 90 degree angle.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool IsOrthogonal(NVector vector1, NVector vector2, double tolerance = Num.ZeroTolerance)
        {
            return (ConcavityColinearity(vector1, vector2).IsEqualTo(0, tolerance));
        }

        /// <summary>
        /// Vectors form a convex angle.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool IsConvex(NVector vector1, NVector vector2, double tolerance = Num.ZeroTolerance)
        {
            return (ConcavityColinearity(vector1, vector2).IsLessThan(0, tolerance));
        }

        /// <summary>
        ///  True: Segments are parallel, on the same line, oriented in the opposite direction.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool IsColinearOppositeDirection(NVector vector1, NVector vector2, double tolerance = Num.ZeroTolerance)
        {
            return (ConcavityColinearity(vector1, vector2).IsEqualTo(-1, tolerance));
        }



        /// <summary>
        /// True: The concave side of the vector is inside the shape.
        /// This is determined by the direction of the vector.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool ConcaveInside(NVector vector1, NVector vector2, double tolerance = Num.ZeroTolerance)
        {
            return (vector1.Area(vector2).IsGreaterThan(0, tolerance));
        }

        /// <summary>
        /// True: The convex side of the vector is inside the shape.
        /// This is determined by the direction of the vector.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool ConvexInside(NVector vector1, NVector vector2, double tolerance = Num.ZeroTolerance)
        {
            return (vector1.Area(vector2).IsLessThan(0, tolerance));
        }





        /// <summary>
        /// Returns a value indicating the concavity of the vectors. 
        /// 1 = Pointing the same way. 
        /// &gt; 0 = Concave. 
        /// 0 = Orthogonal. 
        /// &lt; 0 = Convex. 
        /// -1 = Pointing the exact opposite way.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static double ConcavityColinearity(NVector vector1, NVector vector2)
        {
            return (vector1.Dot(vector2) / (vector1.Length * vector2.Length));
        }

        /// <summary>
        /// Dot product of two vectors.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static double Dot(this NVector vector1, NVector vector2)
        {
            return NVector.Multiply(vector1, vector2);
        }

        /// <summary>
        /// Cross-product of two vectors.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static double Cross(this NVector vector1, NVector vector2)
        {
            return NVector.CrossProduct(vector1, vector2);
        }

        /// <summary>
        /// Returns the angle [radians] between the two vectors.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static double Angle(this NVector vector1, NVector vector2)
        {
            return NMath.Acos(ConcavityColinearity(vector1, vector2));
        }

        /// <summary>
        /// Returns the area between two vectors.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static double Area(this NVector vector1, NVector vector2)
        {
            return (0.5 * (vector1.Cross(vector2)));
        }







        /// <summary>
        /// X-coordinate of a horizontal line intersecting the line described by the points provided.
        /// </summary>
        /// <param name="y">Y-coordinate of the horizontal line.</param>
        /// <param name="x1">X-coordinate of first point.</param>
        /// <param name="y1">Y-coordinate of first point.</param>
        /// <param name="x2">X-coordinate of second point.</param>
        /// <param name="y2">Y-coordinate of second point.</param>
        /// <returns></returns>
        public static double IntersectionX(double y, double x1, double y1, double x2, double y2)
        {
            return ((((y - y1)*(x2 - x1))/(y2 - y1)) + x1);
        }

        /// <summary>
        /// X-coordinate of a horizontal line intersecting the line described by the points provided.
        /// </summary>
        /// <param name="y">Y-coordinate of the horizontal line.</param>
        /// <param name="I">First point.</param>
        /// <param name="J">Second point.</param>
        /// <returns></returns>
        public static double IntersectionX(double y, Point I, Point J)
        {
            return IntersectionX(y, I.X, I.Y, J.X, J.Y);
        }
    }
}
