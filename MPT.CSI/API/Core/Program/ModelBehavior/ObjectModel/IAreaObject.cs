using MPT.CSI.API.Core.Helpers;

namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Represents the Area Object in the application.
    /// </summary>
    public interface IAreaObject :
        IAddableObject,
        ICountable, IListableNames, IChangeableName, IGroupAssignable, ISelectable, ISelectableEdge, IDeletable,
        IObservableLocalAxes, IChangeableLocalAxes,
        IGUID, IMass, IDeletableMass,  IEdgeConstraints,
        IDeletableSpring,
#if BUILD_ETABS2015 || BUILD_ETABS2016
        ILabel,
        IDiaphragmAreas,
        ISpringAssignment,
        IPier, ISpandrel, IRebarDataPierSpandrel,
        IOpening,
#else
        ILocalAxesAdvanced,
        IAreaAutoMesh, INotionalSize,
        ISurfaceSpring, 
#endif
        IObservableTransformationMatrix, IObservablePoints, IObservableElement,
        IObservableModifiers, IChangeableModifiers, IDeletableModifiers,
        IObservableMaterialOverwrite, IChangeableMaterialOverwrite,

        IObservableSection, IChangeableSection,
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        IObservableAreaOffset, IChangeableAreaOffset,
        IObservableThickness, IChangeableThickness,
        IObservableMaterialTemperature, IChangeableMaterialTemperature,
#endif


        // Loads
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        ILoadGravity,
        ILoadPorePressure, 
        ILoadStrain,
        ILoadSurfacePressure,
        
        ILoadRotate,
#endif
        ILoadTemperature,

        ILoadUniform,
        ILoadUniformToFrame,
        IDeletableLoadUniform,

        ILoadWindPressure
    {
#if BUILD_ETABS2015 || BUILD_ETABS2016        
        /// <summary>
        /// Retrieves the design orientation of an area object.
        /// </summary>
        /// <param name="name">The name of a defined area object.</param>
        /// <param name="designOrientation">The design orientation.</param>
        void GetDesignOrientation(string name,
            ref eAreaDesignOrientation designOrientation);

        /// <summary>
        /// Retrieves select data for all area objects in the model .
        /// </summary>
        /// <param name="numberOfNames">The number of names.</param>
        /// <param name="areaNames">The area names.</param>
        /// <param name="designOrientations">The design orientations.</param>
        /// <param name="numberOfBoundaryPts">The number of boundary points.</param>
        /// <param name="pointDelimiters">The point delimiters.</param>
        /// <param name="pointNames">The point names for each area.</param>
        /// <param name="coordinates">The coordinates for each point for each area. [L].</param>
        void GetAllAreas(ref int numberOfNames,
            ref string[] areaNames,
            ref eAreaDesignOrientation[] designOrientations,
            ref int numberOfBoundaryPts,
            ref int[] pointDelimiters,
            ref string[] pointNames,
            ref Coordinate3DCartesian[] coordinates);
#endif
    }
}
