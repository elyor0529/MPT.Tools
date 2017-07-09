
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Represents the Point Object in the application.
    /// </summary>
    public interface IPointObject:
        ICountable, IListableNames, IChangeableName, IGroupAssignable, ISelectable, IDeletable,
        ILocalAxes, ILocalAxesAdvancedWithPoints, IGUID, IMassLumped,
        IObservableTransformationMatrix, IObservableElement,
        IObservableConnectivity, IObservableCommonTo,

        IObservableMerge, IChangeableMerge,
        IObservableCoordinates, IAddableCoordinate,
        IObservablePattern, IChangeablePattern, IDeletablePattern,

        IConstraint, IPanelZone, ISpecialPoint,
        IObservableRestraint, IChangeableRestraint, IDeletableRestraint,
        IObservablePointSpring, IChangeablePointSpring, IDeletableSpring,
        

        // Loads
        ILoadForce, ICountableLoadForce,
        ILoadForceWithGUID, 
        ILoadDisplacement, ICountableLoadDisplacement
    {
    }
}
