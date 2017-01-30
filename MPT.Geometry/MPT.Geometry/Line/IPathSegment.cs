using NPoint = System.Windows.Point;

namespace MPT.Geometry.Line
{
    /// <summary>
    /// Interface for any segment along a path lying in a plane.
    /// </summary>
    public interface IPathSegment
    {
        /// <summary>
        /// First coordinate value.
        /// </summary>
        NPoint I { get; set; }

        /// <summary>
        /// Second coordinate value.
        /// </summary>
        NPoint J { get; set; }
    }
}
