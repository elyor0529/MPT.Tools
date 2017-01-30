using NPoint = System.Windows.Point;
using NVector = System.Windows.Vector;


namespace MPT.Geometry.Line
{
    /// <summary>
    /// Represents a vector in 2D space.
    /// </summary>
    public class Vector
    {
        #region Properties
        private NVector _vector;

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


        protected NPoint _location;
        /// <summary>
        /// Gets the location of this vector in Euclidean space.
        /// </summary>
        public NPoint Location => _location;
        #endregion


        #region Inherit Methods
        // https://msdn.microsoft.com/en-us/library/system.windows.vector(v=vs.110).aspx


        #endregion

        #region New Methods

       
   


        #endregion

    }
}
