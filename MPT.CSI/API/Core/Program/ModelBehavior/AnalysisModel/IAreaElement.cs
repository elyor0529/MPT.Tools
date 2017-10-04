namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel
{
    /// <summary>
    /// Represents the Area Element in the application.
    /// </summary>
    public interface IAreaElement: 
        ICountable, IListableNames, IObservableTransformationMatrix, IObservableLocalAxes, IObservableModifiers, IObservableObject, IObservablePoints,
        IObservableSection, IObservableMaterialOverwrite,
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        IObservableMaterialTemperature,
#endif
        IObservableAreaOffset,
        IObservableThickness,

#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        IObservableLoadGravity, 
        IObservableLoadPorePressure, 
        IObservableLoadStrain, 
        IObservableLoadSurfacePressure,
#endif
        IObservableLoadTemperature, 
        IObservableLoadUniform
    {
    }
}
