namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Represents the Ritz modal load case in the application.
    /// </summary>
    public interface IModalRitz: IModal
    {
        /// <summary>
        /// This function retrieves the load data for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing modal Ritz load case.</param>
        /// <param name="numberOfLoads">The number of loads assigned to the specified analysis case.</param>
        /// <param name="loadTypes">The load types.</param>
        /// <param name="loadNames">This is an array that includes the name of each load assigned to the load case.
        /// If <paramref name="loadTypes"/> = <see cref="eLoadTypeModal.Load"/>, this item is the name of a defined load pattern.
        /// If <paramref name="loadTypes"/> = <see cref="eLoadTypeModal.Accel"/>, this item is UX, UY, UZ, RX, RY or RZ, indicating the direction of the load.
        /// If <paramref name="loadTypes"/> = <see cref="eLoadTypeModal.Link"/>, this item is not used.</param>
        /// <param name="maxNumberGenerationCycles">The maximum number generation cycles to be performed for the specified Ritz starting vector. 
        /// A value of 0 means there is no limit on the number of cycles.</param>
        /// <param name="targetDynamicParticipationRatio">The target dynamic participation ratio.</param>
        void GetLoads(string name,
            ref int numberOfLoads,
            ref eLoadTypeModal[] loadTypes,
            ref string[] loadNames,
            ref int[] maxNumberGenerationCycles,
            ref double[] targetDynamicParticipationRatio);

        /// <summary>
        /// This function sets the load data for the specified analysis case.
        /// </summary>
        /// <param name="name">The name of an existing modal Ritz load case.</param>
        /// <param name="numberOfLoads">The number of loads assigned to the specified analysis case.</param>
        /// <param name="loadTypes">The load types.</param>
        /// <param name="loadNames">This is an array that includes the name of each load assigned to the load case.
        /// If <paramref name="loadTypes"/> = <see cref="eLoadTypeModal.Load"/>, this item is the name of a defined load pattern.
        /// If <paramref name="loadTypes"/> = <see cref="eLoadTypeModal.Accel"/>, this item is UX, UY, UZ, RX, RY or RZ, indicating the direction of the load.
        /// If <paramref name="loadTypes"/> = <see cref="eLoadTypeModal.Link"/>, this item is not used.</param>
        /// <param name="maxNumberGenerationCycles">The maximum number generation cycles to be performed for the specified Ritz starting vector. 
        /// A value of 0 means there is no limit on the number of cycles.</param>
        /// <param name="targetDynamicParticipationRatio">The target dynamic participation ratio.</param>
        void SetLoads(string name,
            int numberOfLoads,
            eLoadTypeModal[] loadTypes,
            string[] loadNames,
            int[] maxNumberGenerationCycles,
            double[] targetDynamicParticipationRatio);
    }
}
