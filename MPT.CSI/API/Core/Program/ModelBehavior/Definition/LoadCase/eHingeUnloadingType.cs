namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Hinge unloading types available in the application.
    /// </summary>
    public enum eHingeUnloadingType
    {
        /// <summary>
        /// Unload entire structure.
        /// </summary>
        UnloadEntireStructure = 1,

        /// <summary>
        /// Apply local redistribution.
        /// </summary>
        ApplyLocalRedistribution = 2,

        /// <summary>
        /// Restart using secant stif.
        /// </summary>
        RestartUsingSecantStiffness = 3
    }
}