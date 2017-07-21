namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Represents the nonlinear modal time history load case in the application.
    /// </summary>
    public interface ITimeHistoryModalNonlinear:
        ISetLoadCase, IInitialLoadCase, ILoadTimeHistory, IDampingModal, ITimeStep, IModalCase, INLMTHSolutionControlParameters
    {
    }
}
