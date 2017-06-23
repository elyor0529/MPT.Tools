
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Types of Steady State functions available in the application.
    /// </summary>
    public enum eFunctionSteadyStateType
    {
        /// <summary>
        /// Function is read from an external file.
        /// </summary>
        FromFile = 0,

        /// <summary>
        /// User-defined function.
        /// </summary>
        User = 1
    }
}
