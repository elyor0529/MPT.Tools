using System.Windows.Media.Media3D;

namespace MPT.Geometry.Point
{
    /// <summary>
    /// Represents the difference between 3D points I (first) and J (second) in three-dimensional space.
    /// </summary>
    public struct OffSet3D
    {
        /// <summary>
        /// Gets or sets the first coordinate value of this Point structure.
        /// </summary>
        public Point3D I { get; set; }

        /// <summary>
        /// Gets or sets the second coordinate value of this Point structure.
        /// </summary>
        public Point3D J { get; set; }

        /// <summary>
        /// Xj - Xi.
        /// </summary>
        /// <returns></returns>
        public double X()
        {
            return (J.X - I.X);
        }

        /// <summary>
        /// Yj - Yi.
        /// </summary>
        /// <returns></returns>
        public double Y()
        {
            return (J.Y - I.Y);
        }

        /// <summary>
        /// Zj - Zi.
        /// </summary>
        /// <returns></returns>
        public double Z()
        {
            return (J.Z - I.Z);
        }
    }
}
