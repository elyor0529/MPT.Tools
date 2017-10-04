#if BUILD_ETABS2015 || BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Column splice options available in the application.
    /// </summary>
    public enum eColumnSpliceOption
    {
        /// <summary>
        /// From story data (default).
        /// </summary>
        FromStoryData = 1,

        /// <summary>
        /// The no splice.
        /// </summary>
        NoSplice = 2,

        /// <summary>
        /// The splice at height above story at bottom of the column.
        /// </summary>
        SpliceAtHeightAboveStoryAtBottomOfColumn = 3
    }
}
#endif