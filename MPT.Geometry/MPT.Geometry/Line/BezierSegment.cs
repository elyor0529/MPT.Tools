using NPoint = System.Windows.Point;

namespace MPT.Geometry.Line
{
    /// <summary>
    /// Segment that describes a Bezier curve between two points in a plane.
    /// </summary>
    public class BezierSegment : IPathSegment
    {
        /// <summary>
        /// First coordinate value.
        /// </summary>
        public NPoint I { get; set; }

        /// <summary>
        /// Second coordinate value.
        /// </summary>
        public NPoint J { get; set; }
    }
}
