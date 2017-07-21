namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Represents the linear time history load case in the application.
    /// </summary>
    public interface ITimeHistoryDirectLinear :
        ISetLoadCase, IInitialLoadCase, ILoadTimeHistory, IDampingProportional, ITimeStep, ITimeIntegration
    {
    }
}
