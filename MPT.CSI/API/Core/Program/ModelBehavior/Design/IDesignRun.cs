namespace MPT.CSI.API.Core.Program.ModelBehavior.Design
{
    /// <summary>
    /// Implements a design interface for running and checking the status of design operations.
    /// </summary>
    public interface IDesignRun
    {

        /// <summary>
        /// Starts the frame design.
        /// </summary>
        void StartDesign();

        /// <summary>
        /// True: Design results are available.
        /// </summary>
        /// <returns><c>true</c> if design results are available, <c>false</c> otherwise.</returns>
        bool ResultsAreAvailable();
    }
}