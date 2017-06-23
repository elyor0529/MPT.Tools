
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Represents the Link Object in the application.
    /// </summary>
    public interface ILinkObject:
        IObservableSectionFrequencyDependent, IChangeableSectionFrequencyDependent,

        IAddableObject, 
        ICountable, IListableNames, IChangeableName, IGroupAssignable, ISelectable, IDeletable,
        ILocalAxes, ILocalAxesAdvanced, IGUID,

        IObservableTransformationMatrix, IObservablePoints, IObservableElement,
        
        IObservableSection, IChangeableSection,

        // Loads
        ILoadGravity, 
        ILoadDeformation, 
        ILoadTargetForce
    {
       
    }
}
