
namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel
{
    /// <summary>
    /// Represents the Line Element in the application.
    /// </summary>
    public interface ILineElement:
        IObservableInsertionPoint, IObservableOffset,
        ICountable, IListableNames, IObservableTransformationMatrix, IObservableLocalAxes, 
        IObservableModifiers, IObservableObject, IObservablePoints, IObservableReleases,
        IObservableSection, IObservableMaterialOverwrite, IObservableTensionCompressionLimits,
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        IObservablePDeltaForces,
        IObservableMaterialTemperature, 

        IObservableLoadDeformation, 
        IObservableLoadGravity, 
        IObservableLoadStrain, 
        IObservableLoadTargetForce,
#endif
        IObservableLoadDistributed, 
        IObservableLoadPoint, 
        IObservableLoadTemperature
    {

    }
}
