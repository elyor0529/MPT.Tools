using System;

using NMath = System.Math;
using NVector = System.Windows.Vector;
using NVector3D = System.Windows.Media.Media3D.Vector3D;

using Num = MPT.Math.Numbers;

namespace MPT.Math
{
    /// <summary>
    /// Library of methods related to vectors.
    /// </summary>
    public class Vector : IEquatable<Vector>
    {
        #region Properties
        private static NVector _vector;

        /// <summary>
        /// Tolerance to use in all calculations with double types.
        /// </summary>
        public double Tolerance { get; set; } = Num.ZeroTolerance;

        /// <summary>
        /// Length of this vector.
        /// </summary>
        public double Magnitude => _vector.Length;

        /// <summary>
        /// Gets the square of the length of this vector.
        /// </summary>
        public double MagnitudeSquared => _vector.LengthSquared;

        /// <summary>
        /// Gets the x-component of this vector.
        /// </summary>
        public double Xcomponent => _vector.X;

        /// <summary>
        /// Gets the y-component of this vector.
        /// </summary>
        public double Ycomponent => _vector.Y;

        protected Point _location;
        /// <summary>
        /// Gets the location of this vector in Euclidean space.
        /// </summary>
        public Point Location => _location;
        #endregion

        /// <summary>
        /// Initializes the class with a vector structure.
        /// </summary>
        /// <param name="vector"></param>
        public Vector(NVector vector)
        {
            _vector = vector;
        }

        /// <summary>
        /// Initializes the class with a vector structure and a point coinciding with the location of the vector.
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="location"></param>
        public Vector(NVector vector, Point location)
        {
            _vector = vector;
            _location = location;
        }

        public Vector(double x, double y)
        {
            _vector = new NVector(x, y);
        }

        #region Inherit Methods
        // https://msdn.microsoft.com/en-us/library/system.windows.vector(v=vs.110).aspx


        #endregion

        #region New Methods

        #endregion

        /// <summary>
        /// True: Segments are parallel, on the same line, oriented in the same direction.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public bool IsColinearSameDirection(NVector vector)
        {
            return _vector.IsCollinearSameDirection(vector, Tolerance);
        }

        /// <summary>
        /// Vectors form a concave angle.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public bool IsConcave(NVector vector)
        {
            return _vector.IsConcave(vector);
        }

        /// <summary>
        /// Vectors form a 90 degree angle.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public bool IsOrthogonal(NVector vector)
        {
            return _vector.IsOrthogonal(vector, Tolerance);
        }

        /// <summary>
        /// Vectors form a convex angle.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public bool IsConvex(NVector vector)
        {
            return _vector.IsConvex(vector, Tolerance);
        }

        /// <summary>
        ///  True: Segments are parallel, on the same line, oriented in the opposite direction.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public bool IsColinearOppositeDirection(NVector vector)
        {
            return _vector.IsCollinearOppositeDirection(vector, Tolerance);
        }



        /// <summary>
        /// True: The concave side of the vector is inside the shape.
        /// This is determined by the direction of the vector.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public bool ConcaveInside(NVector vector)
        {
            return _vector.IsConcaveInside(vector, Tolerance);
        }

        /// <summary>
        /// True: The convex side of the vector is inside the shape.
        /// This is determined by the direction of the vector.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public bool ConvexInside(NVector vector)
        {
            return _vector.IsConvexInside(vector, Tolerance);
        }





        /// <summary>
        /// Returns a value indicating the concavity of the vectors. 
        /// 1 = Pointing the same way. 
        /// &gt; 0 = Concave. 
        /// 0 = Orthogonal. 
        /// &lt; 0 = Convex. 
        /// -1 = Pointing the exact opposite way.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public double ConcavityColinearity(NVector vector)
        {
            return _vector.ConcavityCollinearity(vector);
        }

        /// <summary>
        /// Dot product of two vectors.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public double Dot(NVector vector)
        {
            return _vector.Dot(vector);
        }

        /// <summary>
        /// Cross-product of two vectors.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public double Cross(NVector vector)
        {
            return _vector.Cross(vector);
        }

        /// <summary>
        /// Returns the angle [radians] of a vector from the origin axis (x, positive, +ccw).
        /// </summary>
        /// <returns></returns>
        public double Angle()
        {
            return NMath.Atan(_vector.Y/_vector.X);
        }

        /// <summary>
        /// Returns the angle [radians] between the two vectors.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public double Angle(NVector vector)
        {
            return _vector.Angle(vector);
        }

        /// <summary>
        /// Returns the area between two vectors.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public double Area(NVector vector)
        {
            return _vector.Area(vector);
        }

        #region Operators & Equals


        public bool Equals(Vector other)
        {
            return (NMath.Abs(Xcomponent - other.Xcomponent) < Tolerance) &&
                   (NMath.Abs(Ycomponent - other.Ycomponent) < Tolerance);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector) { return Equals((Vector)obj); }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Xcomponent.GetHashCode() ^ Ycomponent.GetHashCode();
        }


        public static bool operator ==(Vector a, Vector b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Vector a, Vector b)
        {
            return !a.Equals(b);
        }
        

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.Xcomponent + b.Xcomponent, a.Ycomponent + b.Ycomponent);
        }
        
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.Xcomponent - b.Xcomponent, a.Ycomponent - b.Ycomponent);
        }
        

        public static Vector operator *(Vector a, double b)
        {
            return new Vector(a.Xcomponent * b, a.Ycomponent * b);
        }

        public static Vector operator /(Vector a, double b)
        {
            return new Vector(a.Xcomponent / b, a.Ycomponent / b);
        }

        
        #endregion
    }
}
