
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Represents the Point Object in the application.
    /// </summary>
    public interface IPointObject:
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        ILocalAxesAdvancedWithPoints,

        IObservableMerge, IChangeableMerge,
        IObservablePattern, IChangeablePattern, IDeletablePattern,

        IConstraint, 
        IAddableCoordinate,

        ILoadForceWithGUID, 
#endif
#if BUILD_ETABS2015 || BUILD_ETABS2016
        ILabel,
        IDiaphragmPoints,
        ISpringAssignment,
#endif
        ICountable, IListableNames, IChangeableName, IGroupAssignable, ISelectable, IDeletable,
        IObservableLocalAxes,  IGUID, IMassLumped,
        IObservableTransformationMatrix, IObservableElement,
        IObservableConnectivity, IObservableCommonTo,

       
        IObservableCoordinates, 
        
        IPanelZone, ISpecialPoint,
        IObservableRestraint, IChangeableRestraint, IDeletableRestraint,
        IObservablePointSpring, IChangeablePointSpring, IDeletableSpring,
        ICountablePanelZone,

        // Loads
        ILoadForce, ICountableLoadForce,
        ILoadDisplacement, ICountableLoadDisplacement
    {
    }
}
