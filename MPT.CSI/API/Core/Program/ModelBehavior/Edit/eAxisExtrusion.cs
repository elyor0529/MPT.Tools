#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Edit
{
    /// <summary>
    /// Axis of extrusion used in extruding objects.
    /// </summary>
    public enum eAxisExtrusion
    {
        /// <summary>
        /// The x axis
        /// </summary>
        XAxis = 0,

        /// <summary>
        /// The y axis
        /// </summary>
        YAxis = 1,

        /// <summary>
        /// The z axis.
        /// </summary>
        ZAxis = 2
    }
}
#endif