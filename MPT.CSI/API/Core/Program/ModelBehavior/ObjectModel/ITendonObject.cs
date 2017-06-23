
using MPT.CSI.API.Core.Helpers;
using MPT.CSI.API.Core.Program.ModelBehavior.Definition;

namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Represents the Tendon Object in the application.
    /// </summary>
    public interface ITendonObject:
        IAddableObject,
        ICountable, IListableNames, IChangeableName, IGroupAssignable, ISelectable, IDeletable,
        ILocalAxes, IGUID,
        
        IObservableTransformationMatrix, IObservablePoints, IObservableElement,
       
        IObservableSection, IChangeableSection, 
        IObservableMaterialTemperature, IChangeableMaterialTemperature,
        IObservableTensionCompressionLimits, IChangeableTensionCompressionLimits,

        // Loads
        ILoadGravity, 
        ILoadDeformation, 
        ILoadTargetForce, 

        ILoadStrain, 
        ILoadTemperature, 
        
        ILoadForceStress
    {
        /// <summary>
        /// This function retrieves the maximum discretization length assignment for tendon objects.
        /// </summary>
        /// <param name="name">The name of an existing tendon object.</param>
        /// <param name="maxDiscretizationLength">The maximum discretization length for the tendon. [L]</param>
        void GetDiscretization(string name,
            ref double maxDiscretizationLength);

        /// <summary>
        /// This function assigns a maximum discretization length to tendon objects.
        /// </summary>
        /// <param name="name">The name of an existing tendon object.</param>
        /// <param name="maxDiscretizationLength">The maximum discretization length for the tendon. [L]</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are retrieved for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are retrieved for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are retrieved for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        void SetDiscretization(string name,
            double maxDiscretizationLength,
            eItemType itemType = eItemType.Object);




        /// <summary>
        /// This function retrieves the loaded group for tendon objects. 
        /// A tendon object transfers its load to any object that is in the specified group.
        /// </summary>
        /// <param name="name">The name of an existing tendon object.</param>
        /// <param name="groupName">This is the name of an existing group. 
        /// All objects in the specified group can be loaded by the tendon.</param>
        void GetLoadedGroup(string name,
            ref string groupName);

        /// <summary>
        /// This function makes the loaded group assignment to tendon objects. 
        /// A tendon object transfers its load to any object that is in the specified group.
        /// </summary>
        /// <param name="name">The name of an existing tendon object.</param>
        /// <param name="groupName">This is the name of an existing group. 
        /// All objects in the specified group can be loaded by the tendon.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are retrieved for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are retrieved for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are retrieved for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        void SetLoadedGroup(string name,
            string groupName,
            eItemType itemType = eItemType.Object);



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
        void GetTendonGeometry(ref string name,
            ref int numberPoints,
            ref CoordinateCartesian[] coordinates,
            string coordinateSystem = CoordinateSystems.Global);
    }
}
