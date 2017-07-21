namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Load case uses time step procedures.
    /// </summary>
    public interface ITimeStep
    {
        /// <summary>
        /// This function retrieves the time step data for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing time history load casee.</param>
        /// <param name="numberOfOutputSteps">The number of output time steps.</param>
        /// <param name="timeStepSize">The output time step size.</param>
        void GetTimeStep(string name,
            ref int numberOfOutputSteps,
            ref double timeStepSize);


        /// <summary>
        /// This function sets the time step data for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing time history load casee.</param>
        /// <param name="numberOfOutputSteps">The number of output time steps.</param>
        /// <param name="timeStepSize">The output time step size.</param>
        void SetTimeStep(string name,
            int numberOfOutputSteps,
            double timeStepSize);
    }
}