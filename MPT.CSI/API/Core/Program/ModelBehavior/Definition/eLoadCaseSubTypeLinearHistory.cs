#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Load case subtypes available in the program for linear modal time history load cases.
    /// </summary>
    public enum eLoadCaseSubTypeLinearHistory
    {
        /// <summary>
        /// Transient linear modal time history.
        /// </summary>
        Transient = 1,

        /// <summary>
        /// Periodic linear modal time history.
        /// </summary>
        Periodic = 2
    }
}
#endif
