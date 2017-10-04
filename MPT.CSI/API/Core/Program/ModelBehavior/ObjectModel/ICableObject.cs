#if !BUILD_ETABS2015 && !BUILD_ETABS2016
using MPT.CSI.API.Core.Helpers;
using MPT.CSI.API.Core.Program.ModelBehavior.Definition;

namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Represents the Cable Object in the application.
    /// </summary>
    public interface ICableObject:
        IAddableObject,
        ICountable, IListableNames, IChangeableName, IGroupAssignable, ISelectable, IDeletable,
        IGUID, IMass, IDeletableMass, IOutputStations, ICableInsertionPoint,

        IObservableTransformationMatrix, IObservablePoints, IObservableElement,
        
        IObservableSection, IChangeableSection,

        IObservableModifiers, IChangeableModifiers, IDeletableModifiers,
        IObservableMaterialOverwrite, IChangeableMaterialOverwrite,
        IObservableMaterialTemperature, IChangeableMaterialTemperature,

        // Loads
        ILoadGravity,
        ILoadDeformationUniaxial,
        ILoadTargetForceUniaxial,

        ILoadStrainUniaxial, 
        ILoadTemperatureConstant,

        ILoadDistributedConstant,

        ILoadDistributedConstantWithGUID
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
        /// <param name="cableParameters">Parameters related to cable shape.
        /// Parameter(0) = Tension at I-End [F].
        /// Parameter(1) = Tension at J-End[F].
        /// Parameter(2) = Horizontal tension component[F].
        /// Parameter(3) = Maximum deformed vertical sag[L].
        /// Parameter(4) = Deformed low-point vertical sag[L].
        /// Parameter(5) = Deformed length[L].
        /// Parameter(6) = Deformed relative length.
        /// Parameter(7) = Maximum undeformed vertical sag[L].
        /// Parameter(8) = Undeformed low-point vertical sag[L].
        /// Parameter(9) = Undeformed length[L].
        /// Parameter(10) = Undeformed relative length.</param>
        void GetCableData(string name,
            ref eCableGeometryDefinition cableType,
            ref int numberOfSegments,
            ref double weight,
            ref double projectedLoad,
            ref bool useDeformedGeometry,
            ref bool isModelUsingFrameElements,
            ref double[] cableParameters);

        /// <summary>
        /// This function retrieves definition data for a specified cable object.
        /// </summary>
        /// <param name="name">The name of a defined cable object.</param>
        /// <param name="cableType">Cable definition parameter.</param>
        /// <param name="numberOfSegments">This is the number of segments into which the program internally divides the cable.</param>
        /// <param name="weight">The added weight per unit length used when calculating the cable shape. [F/L]</param>
        /// <param name="projectedLoad">The projected uniform gravity load used when calculating the cable shape. [F/L]</param>
        /// <param name="value">Value of the parameter used to define the cable shape. 
        /// The item that <paramref name="value"/> represents depends on the <paramref name="cableType"/> item.
        /// <paramref name="cableType"/> = <see cref="eCableGeometryDefinition.MinTensionIEnd"/>: Not Used.
        /// <paramref name="cableType"/> = <see cref="eCableGeometryDefinition.MinTensionJEnd"/>: Not Used.
        /// <paramref name="cableType"/> = <see cref="eCableGeometryDefinition.TensionIEnd"/>: Tension at I-End[F].
        /// <paramref name="cableType"/> = <see cref="eCableGeometryDefinition.TensionJEnd"/>: Tension at J-End[F].
        /// <paramref name="cableType"/> = <see cref="eCableGeometryDefinition.HorizontalTensionComponent"/>: Horizontal tension component[F].
        /// <paramref name="cableType"/> = <see cref="eCableGeometryDefinition.MaximumVerticalSag"/>: Maximum vertical sag[L]. 
        /// <paramref name="cableType"/> = <see cref="eCableGeometryDefinition.LowPointVerticalSag"/>: Low-point vertical sag[L]. 
        /// <paramref name="cableType"/> = <see cref="eCableGeometryDefinition.UndeformedLength"/>: Undeformed length[L]. 
        /// <paramref name="cableType"/> = <see cref="eCableGeometryDefinition.RelativeUndeformedLength"/>: Relative undeformed length.</param>
        /// <param name="useDeformedGeometry">True: The program uses the deformed geometry for the cable object; otherwise it uses the undeformed geometry.</param>
        /// <param name="isModelUsingFrameElements">True: The analysis model uses frame elements to model the cable instead of using cable elements.</param>
        void SetCableData(string name,
            eCableGeometryDefinition cableType,
            int numberOfSegments,
            double weight,
            double projectedLoad,
            double value,
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
        void GetCableGeometry(string name, 
            ref int numberPoints, 
            ref Coordinate3DCartesian[] coordinates, 
            ref double[] verticalSag, 
            ref double[] distanceAbsolute, 
            ref double[] distanceRelative, 
            string coordinateSystem = CoordinateSystems.Global);
    }
}
#endif