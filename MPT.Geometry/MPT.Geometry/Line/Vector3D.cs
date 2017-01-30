using NVector3D = System.Windows.Media.Media3D.Vector3D;

namespace MPT.Geometry.Line
{
    /// <summary>
    /// Represents a vector in 3D space.
    /// </summary>
    public class Vector3D
    {
        #region Properties
        protected NVector3D _vector;

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

        /// <summary>
        /// Gets the z-component of this vector.
        /// </summary>
        public double Zcomponent => _vector.Z;


        protected NVector3D _location;
        /// <summary>
        /// Gets the location of this vector in Euclidean space.
        /// </summary>
        public NVector3D Location => _location;
        #endregion


        #region Inherit Methods
        // https://msdn.microsoft.com/en-us/library/system.windows.media.media3d.vector3d(v=vs.110).aspx


        #endregion

        #region New Methods





        #endregion
    }
}
