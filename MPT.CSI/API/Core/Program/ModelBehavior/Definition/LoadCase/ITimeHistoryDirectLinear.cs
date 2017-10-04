namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// Represents the linear time history load case in the application.
    /// </summary>
    public interface ITimeHistoryDirectLinear :
        ISetLoadCase, IInitialLoadCase, ILoadTimeHistory, IDampingProportional, ITimeStep, ITimeIntegration
    {
    }
#else
    /// <summary>
    /// Represents the linear time history load case in the application.
    /// </summary>
    public interface ITimeHistoryDirectLinear :
        ILoadTimeHistory
    {
    }
#endif

}
