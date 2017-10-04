#if BUILD_CSiBridgev18 || BUILD_CSiBridgev19 || BUILD_ETABS2015 || BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Location reference by vertical position.
    /// Used in SectioCut.Get/SetResultsSide.
    /// </summary>
    public enum eLocationVertical
    {
        /// <summary>
        /// Top.
        /// </summary>
        Top = 1,

        /// <summary>
        /// Bottom.
        /// </summary>
        Bottom = 2
    }
}
#endif