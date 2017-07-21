using System.ComponentModel;

namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Analysis status states of a load case.
    /// </summary>
    public enum eCaseStatus
    {
        /// <summary>
        /// Not run.
        /// </summary>
        [Description("Not Run")]
        NotRun = 1,

        /// <summary>
        /// Could not start.
        /// </summary>
        [Description("Could Not Start")]
        CouldNotStart = 2,

        /// <summary>
        /// Not finished.
        /// </summary>
        [Description("Not Finished")]
        NotFinished = 3,

        /// <summary>
        /// Finished.
        /// </summary>
        [Description("Finished")]
        Finished = 4    
    }
}
