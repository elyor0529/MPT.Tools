
namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel
{
    /// <summary>
    /// Represents the Plane Element in the application.
    /// </summary>
    public interface IPlaneElement:
        ICountable, IListableNames, IObservableTransformationMatrix, IObservableLocalAxes, IObservableObject, IObservablePoints,
        IObservableSection, IObservableMaterialTemperature,
        IObservableLoadGravity, IObservableLoadPorePressure, IObservableLoadRotate, IObservableLoadStrain, IObservableLoadSurfacePressure, IObservableLoadTemperature, IObservableLoadUniform
    {
    }
}
