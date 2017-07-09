
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Represents the Frame Object in the application.
    /// </summary>
    public interface IFrameObject:
        IAddableObject,
        ICountable, IListableNames, IChangeableName, IGroupAssignable, ISelectable, IDeletable,
        ILocalAxes, ILocalAxesAdvanced, IGUID, IMass, IDeletableMass, INotionalSize, 
        IOutputStations, IFrameAutoMesh, IFrameInsertionPoint, IEndLengthOffset, IFrameCurved, IFrameEndSkew, 
        IObservableHinges, // How is this set?
        ILineSpring, IDeletableSpring,

        IDesignProcedure, IFireProofing, ILateralBracing, 
        IObservableDirectAnalysisModifiers, // How is this set?

        IObservableTransformationMatrix, IObservablePoints, IObservableElement, IObservableElementFrame,
        
        IObservableSection, IChangeableSection, IFrameSection, IFrameSectionTrapezoidal,
        IObservableReleases, IChangeableReleases,
        IObservableMaterialTemperature, IChangeableMaterialTemperature,
        IObservableModifiers, IChangeableModifiers,
        IObservableMaterialOverwrite, IChangeableMaterialOverwrite,
        IObservableTensionCompressionLimits, IChangeableTensionCompressionLimits,
        IObservablePDeltaForces, IChangeablePDeltaForces, IDeletablePDeltaForces,

        // Loads
        ILoadGravity, 
        ILoadDeformation, 
        ILoadTargetForce, 
        
        ILoadStrain, 
        ILoadTemperature,

        ILoadDistributed, 

        ILoadDistributedWithGUID,

        ILoadPoint,

        ILoadPointWithGUID,

        ILoadTransfer
    {
       
    }
}
