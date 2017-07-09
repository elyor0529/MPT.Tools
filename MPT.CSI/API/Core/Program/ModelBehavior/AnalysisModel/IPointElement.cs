
namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel
{
    /// <summary>
    /// Represents the Point Element in the application.
    /// </summary>
    public interface IPointElement:
        ICountable, IListableNames, IObservableTransformationMatrix, IObservableLocalAxes, IObservableObject,
        IObservableCoordinates, IObservableConnectivity, IObservableMerge, IObservablePattern,

        IObservableConstraint, 
        IObservableRestraint, 
        IObservablePointSpring,
        
        // Loads
        IObservableLoadForce, ICountableLoadForce,
        IObservableLoadDisplacement, ICountableLoadDisplacement
    {
    }
}
