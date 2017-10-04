namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// Represents the nonlinear modal time history load case in the application.
    /// </summary>
    public interface ITimeHistoryModalNonlinear:
        ISetLoadCase, IInitialLoadCase, ILoadTimeHistory, IDampingModal, ITimeStep, IModalCase, INLMTHSolutionControlParameters
    {
    }
#else
    /// <summary>
    /// Represents the nonlinear modal time history load case in the application.
    /// </summary>
    public interface ITimeHistoryModalNonlinear :
        ILoadTimeHistory
    {
    }
#endif
}
