
namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel
{
    /// <summary>
    /// Represents the Link Element in the application.
    /// </summary>
    public interface ILinkElement:
        ICountable, IListableNames, IObservableTransformationMatrix, IObservableLocalAxes, IObservableObject, IObservablePoints,
        IObservableSection, IObservableSectionFrequencyDependent,
        
        IObservableLoadDeformation, 
        IObservableLoadGravity, 
        IObservableLoadTargetForce
    {
        
    }
}
