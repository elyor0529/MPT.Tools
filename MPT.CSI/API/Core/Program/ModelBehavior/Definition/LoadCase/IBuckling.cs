namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Represents the buckling load case in the application.
    /// </summary>
    public interface IBuckling:
        ISetLoadCase, IInitialLoadCase
    {
        /// <summary>
        /// This function retrieves various parameters for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing buckling load case.</param>
        /// <param name="numberOfBucklingModes">The number of buckling modes requested.</param>
        /// <param name="eigenvalueConvergenceTolerance">The relative convergence tolerance for eigenvalues.</param>
        void GetParameters(string name,
            ref int numberOfBucklingModes,
            ref double eigenvalueConvergenceTolerance);


        /// <summary>
        /// This function sets various parameters for the specified buckling load case.
        /// </summary>
        /// <param name="name">The name of an existing buckling load case.</param>
        /// <param name="numberOfBucklingModes">The number of buckling modes requested.</param>
        /// <param name="eigenvalueConvergenceTolerance">The relative convergence tolerance for eigenvalues.</param>
        void SetParameters(string name,
            int numberOfBucklingModes,
            double eigenvalueConvergenceTolerance);
    }
}
