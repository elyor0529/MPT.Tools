
namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// Represents the Plane Element in the application.
    /// </summary>
    public interface IPlaneElement:
        ICountable, IListableNames, IObservableTransformationMatrix, IObservableLocalAxes, IObservableObject, IObservablePoints,
        IObservableSection, IObservableMaterialTemperature,
        
        IObservableLoadGravity, 
        IObservableLoadPorePressure, 
        IObservableLoadRotate, 
        IObservableLoadStrain, 
        IObservableLoadSurfacePressure, 
        IObservableLoadTemperature, 
        IObservableLoadUniform
    {
    }
#endif
}
