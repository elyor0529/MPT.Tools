namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// Represents the nonlinear time history load case in the application.
    /// </summary>
    public interface ITimeHistoryDirectNonlinear:
        ITimeHistoryDirectLinear, IMassSource, IGeometricNonlinearity, INLTHSolutionControlParameters
    {
        
    }
#else
    /// <summary>
    /// Represents the nonlinear time history load case in the application.
    /// </summary>
    public interface ITimeHistoryDirectNonlinear :
        ITimeHistoryDirectLinear
    {

    }
#endif
}
