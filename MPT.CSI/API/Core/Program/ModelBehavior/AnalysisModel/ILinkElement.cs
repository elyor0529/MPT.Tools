
namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel
{
    /// <summary>
    /// Represents the Link Element in the application.
    /// </summary>
#if BUILD_ETABS2015 || BUILD_ETABS2016
    public interface ILinkElement
#endif
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    public interface ILinkElement:
        ICountable, IListableNames, IObservableTransformationMatrix, IObservableLocalAxes, IObservableObject, IObservablePoints,
        IObservableSection, IObservableSectionFrequencyDependent,
        
        IObservableLoadDeformation, 
        IObservableLoadGravity, 
        IObservableLoadTargetForce
#endif
    {

    }
}
