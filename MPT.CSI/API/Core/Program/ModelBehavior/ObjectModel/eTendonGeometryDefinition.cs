#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Tendon definition used in the program for defining tendon geometry.
    /// </summary>
    public enum eTendonGeometryDefinition
    {
        /// <summary>
        /// Start of tendon.
        /// </summary>
        StartOfTendon = 1,

        /// <summary>
        /// The segment preceding the point is linear.
        /// </summary>
        SegmentPrecedingPointIsLinear = 2,

        /// <summary>
        /// The specified point is the end of a parabola.
        /// </summary>
        ParabolaEndPoint = 6,

        /// <summary>
        /// The specified point is an intermediate point on a parabola.
        /// </summary>
        ParabolaIntermediatePoint = 7,

        /// <summary>
        /// The specified point is the end of a circle.
        /// </summary>
        CircleEndPoint = 8,

        /// <summary>
        /// The specified point is an intermediate point on a circle.
        /// </summary>
        CircleIntermediatePoint = 9
    }
}
#endif