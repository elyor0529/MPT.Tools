#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Edit
{
    /// <summary>
    /// Offset types used for areas in the application.
    /// </summary>
    public enum eAreaOffsetType
    {
        /// <summary>
        /// Offset all area edges.
        /// </summary>
        AllEdges = 0,

        /// <summary>
        /// Offset selected area edges only.
        /// </summary>
        SelectedEdges = 1,

        /// <summary>
        /// Offset selected points of selected areas only.
        /// </summary>
        SelectedPoints = 2
    }
}
#endif