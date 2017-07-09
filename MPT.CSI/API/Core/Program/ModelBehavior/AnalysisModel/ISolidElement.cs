
namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel
{
    /// <summary>
    /// Represents the Solid Element in the application.
    /// </summary>
    public interface ISolidElement :
        ICountable, IListableNames, IObservableTransformationMatrix, IObservableLocalAxes, IObservableObject, IObservablePoints,
        IObservableSection, IObservableMaterialTemperature,
        
        IObservableLoadGravity, 
        IObservableLoadPorePressure, 
        IObservableLoadStrain, 
        IObservableLoadSurfacePressure, 
        IObservableLoadTemperature
    {
    }
}
