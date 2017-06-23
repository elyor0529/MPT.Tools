
using MPT.CSI.API.Core.Helpers;

namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel
{
    /// <summary>
    /// Represents the Line Element in the application.
    /// </summary>
    public interface ILineElement:
        IObservableFrame,
        ICountable, IListableNames, IObservableTransformationMatrix, IObservableLocalAxes, 
        IObservableModifiers, IObservableObject, IObservablePoints, IObservableReleases,
        IObservableSection, IObservableMaterialOverwrite, IObservableMaterialTemperature, IObservableTensionCompressionLimits,
        
        IObservableLoadDeformation, 
        IObservableLoadDistributed, 
        IObservableLoadGravity, 
        IObservableLoadPoint, 
        IObservableLoadStrain, 
        IObservableLoadTargetForce, 
        IObservableLoadTemperature
    {
        
    }
}
