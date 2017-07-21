namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Represents the linear modal time history load case in the application.
    /// </summary>
    public interface ITimeHistoryModalLinear:
        ISetLoadCase, ILoadTimeHistory, IDampingModal, ITimeStep, IModalCase
    {

        /// <summary>
        /// This function retrieves the motion type for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing linear modal history analysis case.</param>
        /// <param name="motionType">The time history motion type.</param>
        void GetMotionType(string name,
            ref eMotionType motionType);

        /// <summary>
        /// This function sets the motion type for the specified analysis case.
        /// </summary>
        /// <param name="name">The name of an existing linear modal history analysis case.</param>
        /// <param name="motionType">The time history motion type.</param>
        void SetMotionType(string name,
            eMotionType motionType);
    }
}
