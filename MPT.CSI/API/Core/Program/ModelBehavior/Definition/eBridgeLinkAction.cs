
#if BUILD_CSiBridgev18 || BUILD_CSiBridgev19
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Actions available for bridge links in the application.
    /// </summary>
    public enum eBridgeLinkAction
    {
        /// <summary>
        /// Update linked model.
        /// </summary>
        Update = 1,

        /// <summary>
        /// Clear all from linked model.
        /// </summary>
        Clear = 2,

        /// <summary>
        /// Convert to unlinked model.
        /// </summary>
        Convert = 3
    }
}
#endif
