
using MPT.CSI.API.Core.Helpers;
using MPT.CSI.API.Core.Program.ModelBehavior.Definition;

namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Represents the Tendon Object in the application.
    /// </summary>
    public interface ITendonObject:
        IAddableObject,
        ICountable, IListableNames, IChangeableName, IGroupAssignable, ISelectable, IDeletable, IDiscretizable, IGroupLoadable,
        ILocalAxes, IGUID,
        
        IObservableTransformationMatrix, IObservablePoints, IObservableElement,
       
        IObservableSection, IChangeableSection, 
        IObservableMaterialTemperature, IChangeableMaterialTemperature,
        IObservableTensionCompressionLimits, IChangeableTensionCompressionLimits,

        // Loads
        ILoadGravity,
        ILoadDeformationUniaxial,

        ILoadStrainUniaxial, 
        ILoadTemperatureConstant, 
        
        ILoadForceStress
    {
        /// <summary>
        /// This function assigns the tendon geometric definition parameters to a tendon object.
        /// </summary>
        /// <param name="name">The name of a defined tendon object.</param>
        /// <param name="numberPoints">The number of points defining the tendon geometry.</param>
        /// <param name="tendonGeometryDefinitions">The tendon geometry definition parameter for the specified point.
        /// The first point should always have a MyType value of 1. If it is not equal to 1, the program uses 1 anyway.
        /// MyType of 6 through 9 is based on using three points to calculate a parabolic or circular arc.
        /// MyType 6 and 8 use the specified point and the two previous points as the three points.
        /// MyType 7 and 9 use the specified point and the points just before and after the specified point as the three points.</param>
        /// <param name="coordinates">Coordinates of the considered point on the tendon in the coordinate system specified by the <paramref name="coordinateSystem"/> item. [L]</param>
        /// <param name="coordinateSystem">The name of the coordinate system in which the x, y and z coordinates are to be reported.
        /// It is Local or the name of a defined coordinate system.</param>
        void GetTendonData(string name,
            ref int numberPoints,
            ref eTendonGeometryDefinition[] tendonGeometryDefinitions,
            ref CoordinateCartesian[] coordinates,
            string coordinateSystem = CoordinateSystems.Global);

        /// <summary>
        /// This function assigns the tendon geometric definition parameters to a tendon object.
        /// </summary>
        /// <param name="name">The name of a defined tendon object.</param>
        /// <param name="numberPoints">The number of points defining the tendon geometry.</param>
        /// <param name="tendonGeometryDefinitions">The tendon geometry definition parameter for the specified point.
        /// The first point should always have a MyType value of 1. If it is not equal to 1, the program uses 1 anyway.
        /// MyType of 6 through 9 is based on using three points to calculate a parabolic or circular arc.
        /// MyType 6 and 8 use the specified point and the two previous points as the three points.
        /// MyType 7 and 9 use the specified point and the points just before and after the specified point as the three points.</param>
        /// <param name="coordinates">Coordinates of the considered point on the tendon in the coordinate system specified by the <paramref name="coordinateSystem"/> item. [L]</param>
        /// <param name="coordinateSystem">The name of the coordinate system in which the x, y and z coordinates are to be reported.
        /// It is Local or the name of a defined coordinate system.</param>
        void SetTendonData(string name,
            int numberPoints,
            eTendonGeometryDefinition[] tendonGeometryDefinitions,
            CoordinateCartesian[] coordinates,
            string coordinateSystem = CoordinateSystems.Global);




        /// <summary>
        /// This function retrieves geometric data for a specified tendon object.
        /// </summary>
        /// <param name="name">The name of a defined tendon object.</param>
        /// <param name="numberPoints">The number of points defining the tendon geometry.</param>
        /// <param name="coordinates">Coordinates of the considered point on the tendon in the coordinate system specified by the <paramref name="coordinateSystem"/> item. [L]</param>
        /// <param name="coordinateSystem">The name of the coordinate system in which the x, y and z coordinates are to be reported.
        /// It is Local or the name of a defined coordinate system.</param>
        void GetTendonGeometry(string name,
            ref int numberPoints,
            ref CoordinateCartesian[] coordinates,
            string coordinateSystem = CoordinateSystems.Global);
    }
}
