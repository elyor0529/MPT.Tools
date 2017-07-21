namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Load case considers target force parameters in the load application.
    /// </summary>
    public interface ITargetForceParameters
    {
        /// <summary>
        /// This function retrieves the target force iteration parameters for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing analysis case.</param>
        /// <param name="convergenceTolerance">The relative convergence tolerance for target force iteration.</param>
        /// <param name="maxIterations">The maximum iterations per stage for target force iteration.</param>
        /// <param name="accelerationFactor">The acceleration factor.</param>
        /// <param name="continueIfNoConvergence">True: Analysis is continued when there is no convergence in the target force iteration</param>
        void GetTargetForceParameters(string name,
            ref double convergenceTolerance,
            ref int maxIterations,
            ref double accelerationFactor,
            ref bool continueIfNoConvergence);

        /// <summary>
        /// This function sets the target force iteration parameters for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing analysis case.</param>
        /// <param name="convergenceTolerance">The relative convergence tolerance for target force iteration.</param>
        /// <param name="maxIterations">The maximum iterations per stage for target force iteration.</param>
        /// <param name="accelerationFactor">The acceleration factor.</param>
        /// <param name="continueIfNoConvergence">True: Analysis is continued when there is no convergence in the target force iteration</param>
        void SetTargetForceParameters(string name,
            double convergenceTolerance,
            int maxIterations,
            double accelerationFactor,
            bool continueIfNoConvergence);
    }
}