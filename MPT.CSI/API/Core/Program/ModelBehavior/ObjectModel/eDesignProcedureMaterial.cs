namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Design procedure types by material available in the application.
    /// </summary>
    public enum eDesignProcedureType
    {
        /// <summary>
        /// STeel design.
        /// </summary>
        Steel = 1,

        /// <summary>
        /// Concrete design.
        /// </summary>
        Concrete = 2,

        /// <summary>
        /// Aluminum design.
        /// </summary>
        Aluminum = 7,

        /// <summary>
        /// Cold formed steel design.
        /// </summary>
        ColdFormed = 8,

        /// <summary>
        /// No design.
        /// </summary>
        NoDesign = 9
    }
}