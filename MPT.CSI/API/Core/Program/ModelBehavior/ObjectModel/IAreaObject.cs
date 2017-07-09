
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Represents the Area Object in the application.
    /// </summary>
    public interface IAreaObject :
        IObservableModifiers, IChangeableModifiers,
        IObservableMaterialOverwrite, IChangeableMaterialOverwrite,

        IAddableObject,
        ICountable, IListableNames, IChangeableName, IGroupAssignable, ISelectable, ISelectableEdge, IDeletable,
        ILocalAxes, ILocalAxesAdvanced, IGUID, IMass, IDeletableMass, IAreaAutoMesh, IEdgeConstraints, INotionalSize,
        ISurfaceSpring, IDeletableSpring,
        IObservableTransformationMatrix, IObservablePoints, IObservableElement,
              
        IObservableSection, IChangeableSection,
        IObservableAreaOffset, IChangeableAreaOffset,
        IObservableThickness, IChangeableThickness,
        IObservableMaterialTemperature, IChangeableMaterialTemperature,

        // Loads
        ILoadGravity,
        ILoadPorePressure, 
        ILoadStrain,
        ILoadSurfacePressure,
        ILoadTemperature,

        ILoadUniform,
        ILoadRotate,

        ILoadUniformToFrame,
        ILoadWindPressure
    {
        
    }
}
