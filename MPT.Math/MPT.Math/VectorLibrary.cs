using NMath = System.Math;
using NVector = System.Windows.Vector;
using NVector3D = System.Windows.Media.Media3D.Vector3D;

using Num = MPT.Math.Numbers;

namespace MPT.Math
{
    /// <summary>
    /// Contains static methods for common vector operations.
    /// </summary>
    public static class VectorLibrary
    {
        #region 2D Vectors
        /// <summary>
        /// True: Segments are parallel, on the same line, oriented in the same direction.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool IsCollinearSameDirection(this NVector vector1, NVector vector2, double tolerance = Num.ZeroTolerance)
        {
            return (ConcavityCollinearity(vector1, vector2).IsEqualTo(1, tolerance));
        }

        /// <summary>
        /// Vectors form a concave angle.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool IsConcave(this NVector vector1, NVector vector2, double tolerance = Num.ZeroTolerance)
        {
            return (ConcavityCollinearity(vector1, vector2).IsGreaterThan(0, tolerance));
        }

        /// <summary>
        /// Vectors form a 90 degree angle.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool IsOrthogonal(this NVector vector1, NVector vector2, double tolerance = Num.ZeroTolerance)
        {
            return (ConcavityCollinearity(vector1, vector2).IsEqualTo(0, tolerance));
        }

        /// <summary>
        /// Vectors form a convex angle.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool IsConvex(this NVector vector1, NVector vector2, double tolerance = Num.ZeroTolerance)
        {
            return (ConcavityCollinearity(vector1, vector2).IsLessThan(0, tolerance));
        }

        /// <summary>
        ///  True: Segments are parallel, on the same line, oriented in the opposite direction.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool IsCollinearOppositeDirection(this NVector vector1, NVector vector2, double tolerance = Num.ZeroTolerance)
        {
            return (ConcavityCollinearity(vector1, vector2).IsEqualTo(-1, tolerance));
        }



        /// <summary>
        /// True: The concave side of the vector is inside the shape.
        /// This is determined by the direction of the vector.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool IsConcaveInside(this NVector vector1, NVector vector2, double tolerance = Num.ZeroTolerance)
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
        public static bool IsConvexInside(this NVector vector1, NVector vector2, double tolerance = Num.ZeroTolerance)
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
        public static double ConcavityCollinearity(this NVector vector1, NVector vector2)
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
            return NMath.Acos(ConcavityCollinearity(vector1, vector2));
        }

        /// <summary>
        /// Returns the angle [radians] of the vector from the x-axis, counter clockwise.
        /// </summary>
        /// <param name="vector1"></param>
        /// <returns></returns>
        public static double Angle(this NVector vector1)
        {
            return NMath.Atan(vector1.Y/vector1.X);
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
        #endregion

    }
}
