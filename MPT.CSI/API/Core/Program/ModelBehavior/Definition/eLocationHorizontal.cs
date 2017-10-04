
#if BUILD_CSiBridgev18 || BUILD_CSiBridgev19
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Location reference by horizontal position.
    /// Used in SectioCut.Get/SetResultsSide.
    /// </summary>
    public enum eLocationHorizontal
    {
        /// <summary>
        /// Right.
        /// </summary>
        Right = 1,

        /// <summary>
        /// Left.
        /// </summary>
        Left = 2
    }
}
#endif