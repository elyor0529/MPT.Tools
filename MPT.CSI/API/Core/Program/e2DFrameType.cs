#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program
{
    /// <summary>
    /// 2D frame template types available in the application.
    /// </summary>
    public enum e2DFrameType
    {
        /// <summary>
        /// Portal frame.
        /// </summary>
        PortalFrame = 0,

        /// <summary>
        /// Concentric braced frame.
        /// </summary>
        ConcentricBraced = 1,

        /// <summary>
        /// Eccentric braced frame.
        /// </summary>
        EccentricBraced = 2
    }
}
#endif