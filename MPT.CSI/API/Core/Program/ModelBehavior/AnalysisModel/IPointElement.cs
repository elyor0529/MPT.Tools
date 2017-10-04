
namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel
{
    /// <summary>
    /// Represents the Point Element in the application.
    /// </summary>
    public interface IPointElement:
        ICountable, IListableNames, IObservableTransformationMatrix, IObservableLocalAxes, IObservableObject,
        IObservableCoordinates, IObservableConnectivity, IObservablePattern,
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        IObservableMerge, 
#endif
        IObservableConstraint, 
        IObservableRestraint, 
        IObservablePointSpring,
        
        // Loads
        IObservableLoadForce, ICountableLoadForce,
        IObservableLoadDisplacement, ICountableLoadDisplacement
    {
    }
}
