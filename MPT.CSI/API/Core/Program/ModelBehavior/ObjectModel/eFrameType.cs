#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Frame type available in the application.
    /// </summary>
    public enum eFrameType
    {
        /// <summary>
        /// Straight frame.
        /// </summary>
        Straight = 1,

        /// <summary>
        /// Curved frame.
        /// </summary>
        Curved = 2
    }
}
#endif