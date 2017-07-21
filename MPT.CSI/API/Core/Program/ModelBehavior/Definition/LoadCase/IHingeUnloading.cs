namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Load case handles hinge unloading.
    /// </summary>
    public interface IHingeUnloading
    {
        /// <summary>
        /// This function retrieves the hinge unloading option for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing analysis case.</param>
        /// <param name="hingeUnloadingType">Type of hinge unloading for the selected load case.</param>
        void GetHingeUnloading(string name,
            ref eHingeUnloadingType hingeUnloadingType);

        /// <summary>
        /// This function sets the hinge unloading option for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing analysis case.</param>
        /// <param name="hingeUnloadingType">Type of hinge unloading for the selected load case.</param>
        void SetHingeUnloading(string name,
            eHingeUnloadingType hingeUnloadingType);
    }
}