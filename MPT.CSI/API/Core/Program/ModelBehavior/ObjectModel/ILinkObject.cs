
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Represents the Link Object in the application.
    /// </summary>
    public interface ILinkObject:
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        IObservableSectionFrequencyDependent, IChangeableSectionFrequencyDependent,

         // Loads
        ILoadGravity, 
        ILoadDeformation, 
        ILoadTargetForce,
#endif
        IAddableObject, IAddableLinkObject,
        ICountable, IListableNames, IChangeableName, IGroupAssignable, ISelectable, IDeletable,
        IObservableLocalAxes, IChangeableLocalAxes,
        ILocalAxesAdvancedWithPoints, IGUID,

        IObservableTransformationMatrix, IObservablePoints, IObservableElement,
        
        IObservableSection, IChangeableSection
    {
       
    }
}
