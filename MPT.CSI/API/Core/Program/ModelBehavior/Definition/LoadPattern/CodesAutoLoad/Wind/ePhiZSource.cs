#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.CodesAutoLoad.Wind
{
    /// <summary>
    /// Phi Z source for Chinese code.
    /// </summary>
    public enum ePhiZSource
    {
        /// <summary>
        /// Modal analysis.
        /// </summary>
        ModalAnalysis = 0,

        /// <summary>
        /// Z/H ratio.
        /// </summary>
        ZHRatio = 1
    }
}
#endif
