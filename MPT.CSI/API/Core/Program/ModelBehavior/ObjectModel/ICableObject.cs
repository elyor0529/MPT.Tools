
using MPT.CSI.API.Core.Helpers;
using MPT.CSI.API.Core.Program.ModelBehavior.Definition;

namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Represents the Cable Object in the application.
    /// </summary>
    public interface ICableObject:
        IObservableLine, IChangeableLine,
        IAddableObject,
        ICountable, IListableNames, IChangeableName, IGroupAssignable, ISelectable, IDeletable,
        ILocalAxes, IGUID, IMass, IOutputStations,

        IObservableTransformationMatrix, IObservablePoints, IObservableElement,
        
        IObservableSection, IChangeableSection,

        IObservableModifiers, IChangeableModifiers,
        IObservableMaterialOverwrite, IChangeableMaterialOverwrite,
        IObservableMaterialTemperature, IChangeableMaterialTemperature,

        // Loads
        ILoadGravity,
        ILoadDeformation, 
        ILoadTargetForce, 

        ILoadStrain, 
        ILoadTemperature,

        ILoadDistributed, 

        ILoadDistributedWithGUID
    {
        /// <summary>
        /// This function retrieves definition data for a specified cable object.
        /// </summary>
        /// <param name="name">The name of a defined cable object.</param>
        /// <param name="cableType">Cable definition parameter.</param>
        /// <param name="numberOfSegments">This is the number of segments into which the program internally divides the cable.</param>
        /// <param name="weight">The added weight per unit length used when calculating the cable shape. [F/L]</param>
        /// <param name="projectedLoad">The projected uniform gravity load used when calculating the cable shape. [F/L]</param>
        /// <param name="useDeformedGeometry">True: The program uses the deformed geometry for the cable object; otherwise it uses the undeformed geometry.</param>
        /// <param name="isModelUsingFrameElements">True: The analysis model uses frame elements to model the cable instead of using cable elements.</param>
        /// <param name="cableParameters">Parameters related to cable shape.</param>
        void GetCableData(string name,
            ref eCableGeometryDefinition cableType,
            ref int numberOfSegments,
            ref double weight,
            ref double projectedLoad,
            ref bool useDeformedGeometry,
            ref bool isModelUsingFrameElements,
            ref bool[] cableParameters);

        /// <summary>
        /// This function retrieves definition data for a specified cable object.
        /// </summary>
        /// <param name="name">The name of a defined cable object.</param>
        /// <param name="cableType">Cable definition parameter.</param>
        /// <param name="numberOfSegments">This is the number of segments into which the program internally divides the cable.</param>
        /// <param name="weight">The added weight per unit length used when calculating the cable shape. [F/L]</param>
        /// <param name="projectedLoad">The projected uniform gravity load used when calculating the cable shape. [F/L]</param>
        /// <param name="value">Value of the parameter used to define the cable shape. 
        /// The item that <paramref name="value"/> represents depends on the CableType item.
        /// CableType = 1: Not Used.
        /// CableType = 2: Not Used.
        /// CableType = 3: Tension at I-End[F].
        /// CableType = 4: Tension at J-End[F].
        /// CableType = 5: Horizontal tension component[F].
        /// CableType = 6: Maximum vertical sag[L]. 
        /// CableType = 7: Low-point vertical sag[L]. 
        /// CableType = 8: Undeformed length[L]. 
        /// CableType = 9: Relative undeformed length.</param>
        /// <param name="useDeformedGeometry">True: The program uses the deformed geometry for the cable object; otherwise it uses the undeformed geometry.</param>
        /// <param name="isModelUsingFrameElements">True: The analysis model uses frame elements to model the cable instead of using cable elements.</param>
        void SetCableData(string name,
            eCableGeometryDefinition cableType,
            int numberOfSegments,
            double weight,
            double projectedLoad,
            bool value,
            bool useDeformedGeometry = false,
            bool isModelUsingFrameElements = false);



        /// <summary>
        /// This function retrieves geometric data for a specified cable object.
        /// </summary>
        /// <param name="name">The name of a defined cable object.</param>
        /// <param name="numberPoints">The number of points defining the cable geometry.</param>
        /// <param name="coordinates">Coordinates of the considered point on the cable in the coordinate system specified by the <paramref name="coordinateSystem"/> item. [L]</param>
        /// <param name="verticalSag">The cable vertical sag, measured from the chord, at the considered point. [L]</param>
        /// <param name="distanceAbsolute">The distance along the cable, measured from the cable I-End, to the considered point. [L]</param>
        /// <param name="distanceRelative">The relative distance along the cable, measured from the cable I-End, to the considered point.</param>
        /// <param name="coordinateSystem">The name of the coordinate system in which the x, y and z coordinates are to be reported.
        /// It is Local or the name of a defined coordinate system.</param>
        void GetCableGeometry(ref string name, 
            ref int numberPoints, 
            ref CoordinateCartesian[] coordinates, 
            double[] verticalSag, 
            double[] distanceAbsolute, 
            double[] distanceRelative, 
            string coordinateSystem = CoordinateSystems.Global);
    }
}
