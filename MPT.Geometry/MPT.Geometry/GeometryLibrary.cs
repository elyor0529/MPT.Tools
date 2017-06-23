
using NPoint = System.Windows.Point;
using NVector = System.Windows.Vector;


using MPT.Math;
using Num = MPT.Math.Numbers;

using MPT.Geometry.Line;
using MPT.Geometry.Point;

namespace MPT.Geometry
{
    /// <summary>
    /// Library of operations related to the geometry framework.
    /// </summary>
    public static class GeometryLibrary
    {
        /// <summary>
        /// Default zero tolerance for operations.
        /// </summary>
        public const double ZeroTolerance = Num.ZeroTolerance;

        #region Vector-Derived
        /// <summary>
        /// True: Segments are parallel, on the same line, oriented in the same direction.
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool IsColinearSameDirection(LineSegment line1, LineSegment line2, double tolerance = ZeroTolerance)
        {
            return (line1.ToVector().IsColinearSameDirection(line2.ToVector(), tolerance));
        }

        /// <summary>
        /// Vectors form a concave angle.
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool IsConcave(LineSegment line1, LineSegment line2, double tolerance = ZeroTolerance)
        {
            return (line1.ToVector().IsConcave(line2.ToVector(), tolerance));
        }

        /// <summary>
        /// Vectors form a 90 degree angle.
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool IsOrthogonal(LineSegment line1, LineSegment line2, double tolerance = ZeroTolerance)
        {
            return (line1.ToVector().IsOrthogonal(line2.ToVector(), tolerance));
        }

        /// <summary>
        /// Vectors form a convex angle.
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool IsConvex(LineSegment line1, LineSegment line2, double tolerance = ZeroTolerance)
        {
            return (line1.ToVector().IsConvex(line2.ToVector(), tolerance));
        }

        /// <summary>
        ///  True: Segments are parallel, on the same line, oriented in the opposite direction.
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool IsColinearOppositeDirection(LineSegment line1, LineSegment line2, double tolerance = ZeroTolerance)
        {
            return (line1.ToVector().IsColinearOppositeDirection(line2.ToVector(), tolerance));
        }



        /// <summary>
        /// True: The concave side of the vector is inside the shape.
        /// This is determined by the direction of the vector.
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool ConcaveInside(LineSegment line1, LineSegment line2, double tolerance = ZeroTolerance)
        {
            return (line1.ToVector().ConcaveInside(line2.ToVector(), tolerance));
        }

        /// <summary>
        /// True: The convex side of the vector is inside the shape.
        /// This is determined by the direction of the vector.
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <param name="tolerance">Tolerance by which a double is considered to be zero or equal.</param>
        /// <returns></returns>
        public static bool ConvexInside(LineSegment line1, LineSegment line2, double tolerance = ZeroTolerance)
        {
            return (line1.ToVector().ConvexInside(line2.ToVector(), tolerance));
        }





        /// <summary>
        /// Returns a value indicating the concavity of the vectors. 
        /// 1 = Pointing the same way. 
        /// &gt; 0 = Concave. 
        /// 0 = Orthogonal. 
        /// &lt; 0 = Convex. 
        /// -1 = Pointing the exact opposite way.
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <returns></returns>
        public static double ConcavityColinearity(LineSegment line1, LineSegment line2)
        {
            return (line1.ToVector().ConcavityColinearity(line2.ToVector()));
        }

        /// <summary>
        /// Dot product of two vectors.
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <returns></returns>
        public static double Dot(LineSegment line1, LineSegment line2)
        {
            return (line1.ToVector().Dot(line2.ToVector()));
        }

        /// <summary>
        /// Cross-product of two vectors.
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <returns></returns>
        public static double Cross(LineSegment line1, LineSegment line2)
        {
            return (line1.ToVector().Cross(line2.ToVector()));
        }

        /// <summary>
        /// Returns the angle [radians] between the two vectors.
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <returns></returns>
        public static double Angle(LineSegment line1, LineSegment line2)
        {
            return (line1.ToVector().Angle(line2.ToVector()));
        }

        /// <summary>
        /// Returns the area between two vectors.
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <returns></returns>
        public static double Area(LineSegment line1, LineSegment line2)
        {
            return (line1.ToVector().Area(line2.ToVector()));
        }

        /// <summary>
        /// Returns the tangent vector to the supplied points.
        /// </summary>
        /// <param name="i">First point.</param>
        /// <param name="j">Second point.</param>
        /// <returns></returns>
        public static Vector TangentVector(NPoint i, NPoint j)
        {
            return new Vector(new NVector((j.X - i.X), (j.Y - i.Y)));
        }

        /// <summary>
        /// Returns a normal vector to a line connecting two points.
        /// </summary>
        /// <param name="i">First point.</param>
        /// <param name="j">Second point.</param>
        /// <returns></returns>
        public static Vector NormalVector(NPoint i, NPoint j)
        {
            Offset delta = new Offset(i, j);
            return new Vector(
                        new LineSegment(
                                new NPoint(-delta.Y(), delta.X()),
                                new NPoint(delta.Y(), -delta.X())).ToVector());
        }
        #endregion


    }
}
