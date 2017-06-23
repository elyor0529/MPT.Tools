
namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel
{
    /// <summary>
    /// Represents the Area Element in the application.
    /// </summary>
    public interface IAreaElement:
        IObservableArea,
        ICountable, IListableNames, IObservableTransformationMatrix, IObservableLocalAxes, IObservableModifiers, IObservableObject, IObservablePoints,
        IObservableSection, IObservableMaterialOverwrite, IObservableMaterialTemperature,
        IObservableLoadGravity, IObservableLoadPorePressure, IObservableLoadStrain, IObservableLoadSurfacePressure, IObservableLoadTemperature, IObservableLoadUniform
    {
    }
}
