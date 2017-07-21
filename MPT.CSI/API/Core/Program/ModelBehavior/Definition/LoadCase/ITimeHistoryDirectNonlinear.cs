namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Represents the nonlinear time history load case in the application.
    /// </summary>
    public interface ITimeHistoryDirectNonlinear:
        ITimeHistoryDirectLinear, IMassSource, IGeometricNonlinearity, INLTHSolutionControlParameters
    {
        
    }
}
