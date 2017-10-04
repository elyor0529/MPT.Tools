
using MPT.CSI.API.Core.Helpers;
using MPT.CSI.API.Core.Program.ModelBehavior.Definition;

namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Represents the Frame Object in the application.
    /// </summary>
    public interface IFrameObject:
        IAddableObject,
        ICountable, IListableNames, IChangeableName, IGroupAssignable, ISelectable, IDeletable,
        IObservableLocalAxes, IChangeableLocalAxes,
        IGUID, IMass, IDeletableMass, 
        IOutputStations, IFrameInsertionPoint, IEndLengthOffset, 
        IObservableHinges, // How is this set?
        IDeletableSpring,
#if BUILD_ETABS2015 || BUILD_ETABS2016
        ILabel, 
        ISpringAssignment,
        IPier, ISpandrel,
        IColumnSpliceOverwrite,
#else
        ILocalAxesAdvanced,
        INotionalSize, 

        IObservableDirectAnalysisModifiers, // How is this set?

        IFrameAutoMesh, IFrameCurved, IFrameEndSkew, IFrameSectionTrapezoidal,
        IFireProofing, 
        ILineSpring,
#endif
        IDesignProcedure, ILateralBracing, 

        IObservableTransformationMatrix, IObservablePoints, IObservableElement, IObservableElementFrame,
        
        IObservableSection, IChangeableSection, IFrameSection, 
        IObservableReleases, IChangeableReleases,
        
        IObservableModifiers, IChangeableModifiers, IDeletableModifiers,
        IObservableMaterialOverwrite, IChangeableMaterialOverwrite,
        IObservableTensionCompressionLimits, IChangeableTensionCompressionLimits,
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        IObservableMaterialTemperature, IChangeableMaterialTemperature,
        IObservablePDeltaForces, IChangeablePDeltaForces, IDeletablePDeltaForces,
#endif


        // Loads
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        ILoadGravity, 
        ILoadDeformation, 
        ILoadTargetForce, 
        
        ILoadStrain, 

        ILoadDistributedWithGUID,
        ILoadPointWithGUID,

        ILoadTransfer,
#endif

        ILoadTemperature,

        ILoadDistributed,        
        ILoadPoint
    {
#if BUILD_ETABS2015 || BUILD_ETABS2016
        /// <summary>
        /// Retrieves the design orientation of a frame object.
        /// </summary>
        /// <param name="name">The name of a defined frame object.</param>
        /// <param name="designOrientation">The design orientation.</param>
        void GetDesignOrientation(string name,
            ref eFrameDesignOrientation designOrientation);

        /// <summary>
        /// Retrieves select data for all area objects in the model .
        /// </summary>
        /// <param name="numberOfNames">The number of names.</param>
        /// <param name="frameNames">The name of each frame.</param>
        /// <param name="sectionNames">The names of the sections assigned to each frame.</param>
        /// <param name="storyNames">The story name associated with each frame</param>
        /// <param name="pointINames">Point I associated with each frame</param>
        /// <param name="pointJNames">Point J associated with each frame</param>
        /// <param name="pointICoordinates">Coordinates for point I of each frame. [L].</param>
        /// <param name="pointJCoordinates">Coordinates for point J of each frame. [L].</param>
        /// <param name="angles">Angle of rotation of the local axis about the local-1 axis. [deg].</param>
        /// <param name="pointIOffsets">Three joint offset distances for point I of each frame. [L].</param>
        /// <param name="pointJOffsets">Three joint offset distances for point J of each frame. [L].</param>
        /// <param name="cardinalInsertionPoints">The cardinal point specifies the relative position of the frame section on the line representing the frame object.</param>
        /// <param name="coordinateSystem">The name of the coordinate system in which the coordinates are returned.</param>
        void GetAllFrames(ref int numberOfNames,
            ref string[] frameNames,
            ref string[] sectionNames,
            ref string[] storyNames,
            ref string[] pointINames,
            ref string[] pointJNames,
            ref Coordinate3DCartesian[] pointICoordinates,
            ref Coordinate3DCartesian[] pointJCoordinates,
            ref double[] angles,
            ref Displacements[] pointIOffsets,
            ref Displacements[] pointJOffsets,
            ref eCardinalInsertionPoint[] cardinalInsertionPoints,
            string coordinateSystem = CoordinateSystems.Global);


        /// <summary>
        /// Retrieves support data for a given frame beam object.
        /// </summary>
        /// <param name="name">The name of an existing frame beam object.</param>
        /// <param name="supportName1">The name of the column frame object, beam frame object or wall area object which supports the beam at its start node.</param>
        /// <param name="supportType1">The type of support at the start node.</param>
        /// <param name="supportName2">The name of the column frame object, beam frame object or wall area object which supports the beam at its end node.</param>
        /// <param name="supportType2">The type of support at the end node.</param>
        void GetSupports(string name,
            ref string supportName1,
            ref eSupportType supportType1,
            ref string supportName2,
            ref eSupportType supportType2);
#endif
    }
}
