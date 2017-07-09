
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Represents the Link Object in the application.
    /// </summary>
    public interface ILinkObject:
        IAddableObject, IAddableLinkObject,
        ICountable, IListableNames, IChangeableName, IGroupAssignable, ISelectable, IDeletable,
        ILocalAxes, ILocalAxesAdvancedWithPoints, IGUID,

        IObservableTransformationMatrix, IObservablePoints, IObservableElement,
        
        IObservableSection, IChangeableSection,
        IObservableSectionFrequencyDependent, IChangeableSectionFrequencyDependent,

        // Loads
        ILoadGravity, 
        ILoadDeformation, 
        ILoadTargetForce
    {
       
    }
}
