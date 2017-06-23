
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Values indicating if the load case has been automatically created.
    /// </summary>
    public enum eAutoCreatedCase
    {
        /// <summary>
        /// Not automatically created.
        /// </summary>
        NotAutomaticallyCreated = 0,

        /// <summary>
        /// Automatically created by the bridge construction scheduler.
        /// </summary>
        AutomaticallyCreated = 1
    }
}
