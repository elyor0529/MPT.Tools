using NPoint = System.Windows.Point;

namespace MPT.Geometry.Point
{
    /// <summary>
    /// Represents the difference between points I (first) and J (second) in two-dimensional space.
    /// </summary>
    public struct Offset
    {
        /// <summary>
        /// Gets or sets the first coordinate value of this Point structure.
        /// </summary>
        public NPoint I { get; set; }

        /// <summary>
        /// Gets or sets the second coordinate value of this Point structure.
        /// </summary>
        public NPoint J { get; set; }

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
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public Offset(NPoint i, NPoint j)
        {
            I = i;
            J = j;
        }

    }
}
