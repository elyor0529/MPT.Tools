using System.Linq;
using MPT.CSI.API.Core.Helpers;
using MPT.CSI.API.Core.Program.ModelBehavior.Definition;
using MPT.CSI.API.Core.Support;

#if BUILD_SAP2000v16
using SAP2000v16;
#elif BUILD_SAP2000v17
using SAP2000v17;
#elif BUILD_SAP2000v18
using SAP2000v18;
#elif BUILD_SAP2000v19
using SAP2000v19;
#elif BUILD_ETABS2013
using ETABS2013;
#elif BUILD_ETABS2014
using ETABS2014;
#elif BUILD_ETABS2015
using ETABS2015;
#elif BUILD_ETABS2016
using ETABS2016;
#endif

namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Represents the tendon object in the application.
    /// </summary>
    public class TendonObject : CSiApiBase, ITendonObject
    {
        #region Initialization

        public TendonObject(CSiApiSeed seed) : base(seed) { }
        #endregion

        #region Query
        /// <summary>
        /// This function returns the total number of defined tendon properties in the model.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.TendonObj.Count();
        }

        /// <summary>
        /// This function retrieves the names of all defined tendon properties.
        /// </summary>
        /// <param name="numberOfNames">The number of tendon object names retrieved by the program.</param>
        /// <param name="names">Tendon object names retrieved by the program.</param>
        public void GetNameList(ref int numberOfNames, ref string[] names)
        {
            _callCode = _sapModel.TendonObj.GetNameList(ref numberOfNames, ref names);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Returns the 3x3 direction cosines to transform local coordinates to global coordinates by the equation [directionCosines]*[localCoordinates] = [globalCoordinates].
        /// Direction cosines returned are ordered by row, and then by column.
        /// </summary>
        /// <param name="nameCoordinateSystem">The name of an existing coordinate system.</param>
        /// <param name="directionCosines">Value is an array of nine direction cosines that define the transformation matrix from the specified global coordinate system to the global coordinate system.
        /// </param>
        public void GetTransformationMatrix(string nameCoordinateSystem,
            ref double[] directionCosines)
        {
            _callCode = _sapModel.TendonObj.GetTransformationMatrix(nameCoordinateSystem, ref directionCosines);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of the point objects that define a tendon object.
        /// </summary>
        /// <param name="name">The name of an existing tendon object.</param>
        /// <param name="numberPoints">The number of point objects that define the tendon object.</param>
        /// <param name="points">The names of the points that defined the tendon object.
        /// The point names are listed in the positive order around the object.</param>
        public void GetPoints(string name, ref int numberPoints, ref string[] points)
        {
            string point1 = "";
            string point2 = "";

            _callCode = _sapModel.TendonObj.GetPoints(name, ref point1, ref point2);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            numberPoints = 2;
            points = new string[numberPoints - 1];
            points[0] = point1;
            points[1] = point2;
        }


        /// <summary>
        /// This function retrieves the GUID for the specified object. 
        /// </summary>
        /// <param name="name">The name of an existing object.</param>
        /// <param name="GUID">The GUID (Global Unique ID) for the specified object.</param>
        public void GetGUID(string name,
            ref string GUID)
        {
            _callCode = _sapModel.TendonObj.GetGUID(name, ref GUID);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function sets the GUID for the specified object. 
        /// If the GUID is passed in as a blank string, the program automatically creates a GUID for the object.
        /// </summary>
        /// <param name="name">The name of an existing object.</param>
        /// <param name="GUID">The GUID (Global Unique ID) for the specified object.</param>
        public void SetGUID(string name,
            string GUID = "")
        {
            _callCode = _sapModel.TendonObj.SetGUID(name, GUID);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        /// <summary>
        /// This function retrieves the name of the element (analysis model) associated with a specified object in the object-based model.
        /// An error occurs if the analysis model does not exist.
        /// </summary>
        /// <param name="name">The name of an existing object.</param>
        /// <param name="numberOfElements">The number of area elements created from the specified area object.</param>
        /// <param name="elementNames">The name of each element created from the specified object.</param>
        public void GetElement(string name,
            ref int numberOfElements,
            ref string[] elementNames)
        {
            double[] relativeDistanceI = new double[0];
            double[] relativeDistanceJ = new double[0];

            _callCode = _sapModel.TendonObj.GetElm(name, ref numberOfElements, ref elementNames, ref relativeDistanceI, ref relativeDistanceJ);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion

        #region Axes
        /// <summary>
        /// This function retrieves the local axis angle assignment of the object.
        /// </summary> 
        /// <param name="name">The name of an existing object.</param>
        /// <param name="angleOffset">This is the angle 'a' that the local 1 and 2 axes are rotated about the positive local 3 axis from the default orientation. 
        /// The rotation for a positive angle appears counter clockwise when the local +3 axis is pointing toward you. [deg]</param>
        /// <param name="isAdvanced">True object local axes orientation was obtained using advanced local axes parameters.</param>
        public void GetLocalAxes(string name,
            ref AngleLocalAxes angleOffset,
            ref bool isAdvanced)
        {
            double angle = 0;

            _callCode = _sapModel.TendonObj.GetLocalAxes(name, ref angle);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            angleOffset.AngleA = angle;
            isAdvanced = false;
        }

        /// <summary>
        /// This function retrieves the local axis angle assignment for the object.
        /// </summary> 
        /// <param name="name">The name of an existing object or group, depending on the value of the <paramref name="itemType"/> item.</param>
        /// <param name="angleOffset">This is the angle 'a' that the local 2 and 3 axes are rotated about the positive local 1 axis, from the default orientation. 
        /// The rotation for a positive angle appears counter clockwise when the local +1 axis is pointing toward you. [deg]</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignment is made to the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignment is made to all objects in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, assignment is made to all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void SetLocalAxes(string name,
            AngleLocalAxes angleOffset,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.SetLocalAxes(name, angleOffset.AngleA, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
        
        #region Creation & Groups
        /// <summary>
        /// This function changes the name of an existing tendon object.
        /// </summary>
        /// <param name="currentName">The existing name of a defined tendon object.</param>
        /// <param name="newName">The new name for the tendon object.</param>
        public void ChangeName(string currentName, string newName)
        {
            _callCode = _sapModel.TendonObj.ChangeName(currentName, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// The function deletes a specified tendon object.
        /// It returns an error if the specified object can not be deleted; for example, if it is currently used by a staged construction load case.
        /// </summary>
        /// <param name="name">The name of an existing tendon object.</param>
        public void Delete(string name)
        {
            _callCode = _sapModel.TendonObj.Delete(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function adds a new object whose corner points are at the specified coordinates.
        /// </summary>
        /// <param name="coordinates">Coordinates for the corner points of the object. 
        /// The coordinates are in the coordinate system defined by the <paramref name="coordinateSystem"/> item.
        /// Two coordinates are required.</param>
        /// <param name="name">This is the name that the program ultimately assigns for the object. 
        /// If no <paramref name="userName"/> is specified, the program assigns a default name to the object. 
        /// If a <paramref name="userName"/> is specified and that name is not used for another object, the <paramref name="userName"/> is assigned to the object; otherwise a default name is assigned to the object.</param>
        /// <param name="nameProperty">This is either Default or the name of a defined solid property.
        /// If it is Default, the program assigns a default solid property to the solid object. 
        /// If it is the name of a defined property, that property is assigned to the object.</param>
        /// <param name="userName">This is an optional user specified name for the object. 
        /// If a <paramref name="userName"/> is specified and that name is already used for another object of the same type, the program ignores the <paramref name="userName"/>.</param>
        /// <param name="coordinateSystem">The name of the coordinate system in which the object point coordinates are defined.</param>
        public void AddByCoordinate(ref CoordinateCartesian[] coordinates,
            ref string name,
            string nameProperty = "Default",
            string userName = "",
            string coordinateSystem = CoordinateSystems.Global)
        {
            if (coordinates.Length != 2)
            {
                throw new CSiException("Two coordinates must be provided for a tendon object. " +
                                       "Provided: " + coordinates.Length);
            }

            _callCode = _sapModel.TendonObj.AddByCoord(
                coordinates[0].X, coordinates[0].Y, coordinates[0].Z,
                coordinates[1].X, coordinates[1].Y, coordinates[1].Z,
                ref name, nameProperty, userName, coordinateSystem);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        /// <summary>
        /// This function adds a new object whose corner points are specified by name.
        /// </summary>
        /// <param name="pointNames">Names of the point objects that define the corner points of the added object.
        /// Two points are required.</param>
        /// <param name="name">This is the name that the program ultimately assigns for the object. 
        /// If no <paramref name="userName"/> is specified, the program assigns a default name to the object. 
        /// If a <paramref name="userName"/> is specified and that name is not used for another object, the <paramref name="userName"/> is assigned to the object; otherwise a default name is assigned to the object.</param>
        /// <param name="nameProperty">This is either Default or the name of a defined solid property.
        /// If it is Default, the program assigns a default solid property to the solid object. 
        /// If it is the name of a defined property, that property is assigned to the object.</param>
        /// <param name="userName">This is an optional user specified name for the object. 
        /// If a <paramref name="userName"/> is specified and that name is already used for another object of the same type, the program ignores the <paramref name="userName"/>.</param>
        public void AddByPoint(string[] pointNames,
            ref string name,
            string nameProperty = "Default",
            string userName = "")
        {
            if (pointNames.Length != 2)
            {
                throw new CSiException("Two points must be provided for a tendon object. " +
                                       "Provided: " + pointNames.Length);
            }

            _callCode = _sapModel.TendonObj.AddByPoint(pointNames[0], pointNames[1], ref name, nameProperty, userName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function adds or removes objects from a specified group.
        /// </summary>
        /// <param name="name">The name of an existing object or group, depending on the value of the <paramref name="itemType"/> item.</param>
        /// <param name="groupName">The name of an existing group to which the assignment is made.</param>
        /// <param name="remove">False: The specified objects are added to the group specified by the <paramref name="groupName"/> item.  
        /// True: The objects are removed from the group.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are made for the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are made for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are made for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void SetGroupAssign(string name,
            string groupName,
            bool remove = false,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.SetGroupAssign(name, groupName, remove, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion

        #region Selection
        /// <summary>
        /// This function retrieves the selected status for an object.
        /// </summary>
        /// <param name="name">The name of an existing object.</param>
        /// <param name="isSelected">True: The specified object is selected.</param>
        public void GetSelected(string name,
            ref bool isSelected)
        {
            _callCode = _sapModel.TendonObj.GetSelected(name, ref isSelected);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the selected status for an object.
        /// </summary>
        /// <param name="name">The name of an existing object.</param>
        /// <param name="isSelected">True: The specified object is selected.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the selected status is set for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the selected status is set for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the selected status is set for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void SetSelected(string name,
            bool isSelected,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.SetSelected(name, isSelected, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion

        #region Cross-Section & Material Properties
        /// <summary>
        /// This function retrieves the section property assigned to a tendon object.
        /// </summary>
        /// <param name="name">The name of a defined tendon object.</param>
        /// <param name="propertyName">The name of the section property assigned to the tendon object.</param>
        public void GetSection(string name, ref string propertyName)
        {
            _callCode = _sapModel.TendonObj.GetProperty(name, ref propertyName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function assigns the section property to a tendon object.
        /// </summary>
        /// <param name="name">The name of a defined tendon object.</param>
        /// <param name="propertyName">The name of the section property assigned to the tendon object.</param>
        /// <param name="itemType">If this item is Object, the assignment is made to the tendon object specified by the Name item.
        /// If this item is Group, the assignment is made to all tendon objects in the group specified by the Name item.
        /// If this item is SelectedObjects, assignment is made to all selected tendon objects, and the Name item is ignored.</param>
        public void SetSection(string name, string propertyName, eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.SetProperty(name, propertyName, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the material temperature assignments to elements.
        /// </summary>
        /// <param name="name">The name of an existing element.</param>
        /// <param name="temperature">This is the material temperature value assigned to the element. [T]</param>
        /// <param name="patternName">This is blank or the name of a defined joint pattern. 
        /// If it is blank, the material temperature for the line element is uniform along the element at the value specified by <paramref name="temperature"/>.
        /// If PatternName is the name of a defined joint pattern, the material temperature for the line element may vary from one end to the other.
        /// The material temperature at each end of the element is equal to the specified temperature multiplied by the pattern value at the joint at the end of the line element.</param>
        public void GetMaterialTemperature(string name,
            ref double temperature,
            ref string patternName)
        {
            _callCode = _sapModel.TendonObj.GetMatTemp(name, ref temperature, ref patternName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the material temperature assignments to elements.
        /// </summary>
        /// <param name="name">The name of an existing element.</param>
        /// <param name="temperature">This is the material temperature value assigned to the element. [T]</param>
        /// <param name="patternName">This is blank or the name of a defined joint pattern. 
        /// If it is blank, the material temperature for the line element is uniform along the element at the value specified by <paramref name="temperature"/>.
        /// If PatternName is the name of a defined joint pattern, the material temperature for the line element may vary from one end to the other.
        /// The material temperature at each end of the element is equal to the specified temperature multiplied by the pattern value at the joint at the end of the line element.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are made for the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are made for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are made for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void SetMaterialTemperature(string name,
            double temperature,
            string patternName,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.SetMatTemp(name, temperature, patternName, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the tension/compression force limit assignments to line elements.
        /// Note that the tension and compression limits are only used in nonlinear analyses.
        /// </summary>
        /// <param name="name">The name of an existing line element.</param>
        /// <param name="limitCompressionExists">True: A compression force limit exists for the line element.</param>
        /// <param name="limitCompression">The compression force limit for the line element. [F]</param>
        /// <param name="limitTensionExists">True: A tension force limit exists for the line element.</param>
        /// <param name="limitTension">The tension force limit for the line element. [F]</param>
        public void GetTensionCompressionLimits(string name,
            ref bool limitCompressionExists,
            ref double limitCompression,
            ref bool limitTensionExists,
            ref double limitTension)
        {
            _callCode = _sapModel.TendonObj.GetTCLimits(name, ref limitCompressionExists, ref limitCompression, ref limitTensionExists, ref limitTension);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the tension/compression force limit assignments to line elements.
        /// Note that the tension and compression limits are only used in nonlinear analyses.
        /// </summary>
        /// <param name="name">The name of an existing line element.</param>
        /// <param name="limitCompressionExists">True: A compression force limit exists for the line element.</param>
        /// <param name="limitCompression">The compression force limit for the line element. [F]</param>
        /// <param name="limitTensionExists">True: A tension force limit exists for the line element.</param>
        /// <param name="limitTension">The tension force limit for the line element. [F]</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are made for the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are made for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are made for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void SetTensionCompressionLimits(string name,
            bool limitCompressionExists,
            double limitCompression,
            bool limitTensionExists,
            double limitTension,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.SetTCLimits(name, limitCompressionExists, limitCompression, limitTensionExists, limitTension, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion

        #region Tendon Properties
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
        public void GetTendonData(string name,
            ref int numberPoints,
            ref eTendonGeometryDefinition[] tendonGeometryDefinitions,
            ref CoordinateCartesian[] coordinates,
            string coordinateSystem = CoordinateSystems.Global)
        {
            int[] csiTendonGeometryDefinitions = new int[0];
            double[] x = new double[0];
            double[] y = new double[0];
            double[] z = new double[0];

            _callCode = _sapModel.TendonObj.GetTendonData(name, ref numberPoints, ref csiTendonGeometryDefinitions, ref x, ref y, ref z, coordinateSystem);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            tendonGeometryDefinitions = new eTendonGeometryDefinition[numberPoints - 1];
            coordinates = new CoordinateCartesian[numberPoints - 1];
            for (int i = 0; i < numberPoints; i++)
            {
                tendonGeometryDefinitions[i] = (eTendonGeometryDefinition)csiTendonGeometryDefinitions[i];
                coordinates[i].X = x[i];
                coordinates[i].Y = y[i];
                coordinates[i].Z = z[i];
            }
        }

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
        public void SetTendonData(string name,
            int numberPoints,
            eTendonGeometryDefinition[] tendonGeometryDefinitions,
            CoordinateCartesian[] coordinates,
            string coordinateSystem = CoordinateSystems.Global)
        {
            int[] csiTendonGeometryDefinitions = tendonGeometryDefinitions.Cast<int>().ToArray();

            double[] x = new double[coordinates.Length - 1];
            double[] y = new double[coordinates.Length - 1];
            double[] z = new double[coordinates.Length - 1];
            for (int i = 0; i < coordinates.Length; i++)
            {
                x[i] = coordinates[i].X;
                y[i] = coordinates[i].Y;
                z[i] = coordinates[i].Z;
            }
            _callCode = _sapModel.TendonObj.SetTendonData(name, numberPoints, ref csiTendonGeometryDefinitions, ref x, ref y, ref z, coordinateSystem);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves geometric data for a specified tendon object.
        /// </summary>
        /// <param name="name">The name of a defined tendon object.</param>
        /// <param name="numberPoints">The number of points defining the tendon geometry.</param>
        /// <param name="coordinates">Coordinates of the considered point on the tendon in the coordinate system specified by the <paramref name="coordinateSystem"/> item. [L]</param>
        /// <param name="coordinateSystem">The name of the coordinate system in which the x, y and z coordinates are to be reported.
        /// It is Local or the name of a defined coordinate system.</param>
        public void GetTendonGeometry(string name,
            ref int numberPoints,
            ref CoordinateCartesian[] coordinates,
            string coordinateSystem = CoordinateSystems.Global)
        {
            double[] x = new double[0];
            double[] y = new double[0];
            double[] z = new double[0];

            _callCode = _sapModel.TendonObj.GetTendonGeometry(name, ref numberPoints, ref x, ref y, ref z, coordinateSystem);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
            
            coordinates = new CoordinateCartesian[numberPoints - 1];
            for (int i = 0; i < numberPoints; i++)
            {
                coordinates[i].X = x[i];
                coordinates[i].Y = y[i];
                coordinates[i].Z = z[i];
            }
        }



        /// <summary>
        /// This function retrieves the maximum discretization length assignment for tendon objects.
        /// </summary>
        /// <param name="name">The name of an existing tendon object.</param>
        /// <param name="maxDiscretizationLength">The maximum discretization length for the tendon. [L]</param>
        public void GetDiscretization(string name,
            ref double maxDiscretizationLength)
        {
            _callCode = _sapModel.TendonObj.GetDiscretization(name, ref maxDiscretizationLength);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function assigns a maximum discretization length to tendon objects.
        /// </summary>
        /// <param name="name">The name of an existing tendon object.</param>
        /// <param name="maxDiscretizationLength">The maximum discretization length for the tendon. [L]</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are retrieved for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are retrieved for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are retrieved for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void SetDiscretization(string name,
            double maxDiscretizationLength,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.SetDiscretization(name, maxDiscretizationLength, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the loaded group for tendon objects. 
        /// A tendon object transfers its load to any object that is in the specified group.
        /// </summary>
        /// <param name="name">The name of an existing tendon object.</param>
        /// <param name="groupName">This is the name of an existing group. 
        /// All objects in the specified group can be loaded by the tendon.</param>
        public void GetLoadedGroup(string name,
            ref string groupName)
        {
            _callCode = _sapModel.TendonObj.GetLoadedGroup(name, ref groupName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

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
        public void SetLoadedGroup(string name,
            string groupName,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.SetLoadedGroup(name, groupName, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion

        #region Loads
        // LoadGravity
        /// <summary>
        /// This function retrieves the gravity load assignments to elements.
        /// </summary>
        /// <param name="name">The name of an existing object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="numberItems">The total number of gravity loads retrieved for the specified elements.</param>
        /// <param name="names">The name of the element associated with each gravity load.</param>
        /// <param name="loadPatterns">The name of the coordinate system in which the gravity load multipliers are specified.</param>
        /// <param name="coordinateSystems">The name of the coordinate system associated with each gravity load.</param>
        /// <param name="xLoadMultiplier">Gravity load multipliers in the x direction of the specified coordinate system.</param>
        /// <param name="yLoadMultiplier">Gravity load multipliers in the y direction of the specified coordinate system.</param>
        /// <param name="zLoadMultiplier">Gravity load multipliers in the z direction of the specified coordinate system.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are retrieved for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are retrieved for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are retrieved for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void GetLoadGravity(string name,
            ref int numberItems,
            ref string[] names,
            ref string[] loadPatterns,
            ref double[] xLoadMultiplier,
            ref double[] yLoadMultiplier,
            ref double[] zLoadMultiplier,
            ref string[] coordinateSystems,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.GetLoadGravity(name, ref numberItems, ref names, ref loadPatterns, ref coordinateSystems, ref xLoadMultiplier, ref yLoadMultiplier, ref zLoadMultiplier, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function assigns gravity loads to objects.
        /// </summary>
        /// <param name="name">The name of an existing object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="loadPattern">The name of the load pattern associated with the gravity load.</param>
        /// <param name="xLoadMultiplier">Gravity load multiplier in the x direction of the specified coordinate system.</param>
        /// <param name="yLoadMultiplier">Gravity load multiplier in the y direction of the specified coordinate system.</param>
        /// <param name="zLoadMultiplier">Gravity load multiplier in the z direction of the specified coordinate system.</param>
        ///  <param name="coordinateSystem">The name of the coordinate system associated with the gravity load.</param>
        /// <param name="replace">True: All previous gravity loads, if any, assigned to the specified object(s), in the specified load pattern, are deleted before making the new assignment.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are made for the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are made for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are made for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void SetLoadGravity(string name,
            string loadPattern,
            double xLoadMultiplier,
            double yLoadMultiplier,
            double zLoadMultiplier,
            string coordinateSystem = CoordinateSystems.Global,
            bool replace = true,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.SetLoadGravity(name, loadPattern, xLoadMultiplier, yLoadMultiplier, zLoadMultiplier, replace, coordinateSystem, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function deletes the gravity load assignments to the specified objects for the specified load pattern.
        /// </summary>
        /// <param name="name">The name of an existing object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="loadPattern">The name of the load pattern associated with the load.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are deleted for the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are deleted for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are deleted for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void DeleteLoadGravity(string name,
            string loadPattern,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.DeleteLoadGravity(name, loadPattern, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        // LoadDeformation
        /// <summary>
        /// This function retrieves the deformation load assignments to elements.
        /// </summary>
        /// <param name="name">The name of an existing object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="numberItems">The total number of deformation loads retrieved for the specified elements.</param>
        /// <param name="names">The name of the element associated with each deformation load.</param>
        /// <param name="loadPatterns">The name of the load pattern associated with each deformation load.</param>
        /// <param name="U1">Axial deformation load value. [L]</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the load assignments are retrieved for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the load assignments are retrieved for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the load assignments are retrieved for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void GetLoadDeformation(string name,
            ref int numberItems,
            ref string[] names,
            ref string[] loadPatterns,
            ref double[] U1,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.GetLoadDeformation(name, ref numberItems, ref names, ref loadPatterns, ref U1, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function assigns deformation loads to frame objects.
        /// </summary>
        /// <param name="name">The name of an existing object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="loadPattern">The name of the load pattern associated with the load.</param>
        /// <param name="U1">Axial deformation load value. [L]</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are made for the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are made for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are made for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void SetLoadDeformation(string name,
            string loadPattern,
            double U1,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.SetLoadDeformation(name, loadPattern, ref U1, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function deletes the deformation load assignments to the specified objects for the specified load pattern.
        /// </summary>
        /// <param name="name">The name of an existing object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="loadPattern">The name of the load pattern associated with the load.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are deleted for the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are deleted for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are deleted for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void DeleteLoadDeformation(string name,
            string loadPattern,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.DeleteLoadDeformation(name, loadPattern, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




       
        // LoadStrain
        /// <summary>
        /// This function retrieves the strain load assignments to elements.
        /// </summary>
        /// <param name="name">The name of an existing object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="numberItems">The total number of strain loads retrieved for the specified elements.</param>
        /// <param name="names">The name of the element associated with each strain load.</param>
        /// <param name="loadPatterns">The name of the load pattern associated with each strain load.</param>
        /// <param name="strainLoadValues">The strain values. [L/L]</param>
        /// <param name="jointPatternNames">The joint pattern name, if any, used to specify each strain load.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are retrieved for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are retrieved for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are retrieved for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void GetLoadStrain(string name,
            ref int numberItems,
            ref string[] names,
            ref string[] loadPatterns,
            ref double[] strainLoadValues,
            ref string[] jointPatternNames,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.GetLoadStrain(name, ref numberItems, ref names, ref loadPatterns, ref strainLoadValues, ref jointPatternNames, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function assigns strain loads to objects.
        /// </summary>
        /// <param name="name">The name of an existing object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="loadPattern">The name of the load pattern associated with the strain load.</param>
        /// <param name="strainLoadValue">The strain value. [L/L]</param>
        /// <param name="jointPatternName">The joint pattern name, if any, used to specify the strain load.</param>
        /// <param name="replace">True: All previous strain loads, if any, assigned to the specified object(s), in the specified load pattern, are deleted before making the new assignment.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are made for the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are made for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are made for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void SetLoadStrain(string name,
            string loadPattern,
            double strainLoadValue,
            string jointPatternName,
            bool replace = true,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.SetLoadStrain(name, loadPattern, strainLoadValue, replace, jointPatternName, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function deletes the strain load assignments to the specified objects for the specified load pattern.
        /// </summary>
        /// <param name="name">The name of an existing object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="loadPattern">The name of the load pattern associated with the load.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are deleted for the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are deleted for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are deleted for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void DeleteLoadStrain(string name,
            string loadPattern,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.DeleteLoadStrain(name, loadPattern, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        // LoadTemperature
        /// <summary>
        /// This function retrieves the temperature load assignments to elements.
        /// </summary>
        /// <param name="name">The name of an existing element or group, depending on the value of the <paramref name="itemType"/> item.</param>
        /// <param name="numberItems">The total number of temperature loads retrieved for the specified elements.</param>
        /// <param name="names">The name of the element associated with each temperature load.</param>
        /// <param name="loadPatterns">The name of the load pattern associated with each temperature load.</param>
        /// <param name="temperatureLoadValues">Temperature load values, [T].</param>
        /// <param name="jointPatternNames">The joint pattern name, if any, used to specify the temperature load.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the load assignments are retrieved for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the load assignments are retrieved for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the load assignments are retrieved for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void GetLoadTemperature(string name,
            ref int numberItems,
            ref string[] names,
            ref string[] loadPatterns,
            ref double[] temperatureLoadValues,
            ref string[] jointPatternNames,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.GetLoadTemperature(name, ref numberItems, ref names, ref loadPatterns, ref temperatureLoadValues, ref jointPatternNames, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function assigns temperature loads to frame objects.
        /// </summary>
        /// <param name="name">The name of an existing element or group, depending on the value of the <paramref name="itemType"/> item.</param>
        /// <param name="loadPattern">The name of the load pattern associated with the temperature load.</param>
        /// <param name="temperatureLoadValue">Temperature load value, [T].</param>
        /// <param name="jointPatternName">The joint pattern name, if any, used to specify the temperature load.</param>
        /// <param name="replace">True: All previous uniform loads, if any, assigned to the specified object(s), in the specified load pattern, are deleted before making the new assignment.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are made for the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are made for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are made for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void SetLoadTemperature(string name,
            string loadPattern,
            double temperatureLoadValue,
            string jointPatternName,
            bool replace,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.SetLoadTemperature(name, loadPattern, temperatureLoadValue, jointPatternName, replace, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function deletes the temperature load assignments to the specified objects for the specified load pattern.
        /// </summary>
        /// <param name="name">The name of an existing object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="loadPattern">The name of the load pattern associated with the load.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are deleted for the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are deleted for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are deleted for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void DeleteLoadTemperature(string name,
            string loadPattern,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.DeleteLoadTemperature(name, loadPattern, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        // LoadForceStress
        /// <summary>
        /// This function retrieves the force stress load assignments to elements.
        /// </summary>
        /// <param name="name">The name of an existing object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="numberItems">The total number of uniform loads retrieved for the specified elements.</param>
        /// <param name="tendonNames">The name of the element associated with each force stress load.</param>
        /// <param name="loadPatterns">The name of the load pattern associated with each force stress load.</param>
        /// <param name="jackedFrom">Indicates how the tendon is jacked.</param>
        /// <param name="loadTypes">Indicates the type of load.</param>
        /// <param name="values">The load value. [F] when <paramref name="loadTypes"/> = <see cref="eTendonLoadType.Force"/>, and [F/L^2] when <paramref name="loadTypes"/> = <see cref="eTendonLoadType.Stress"/>.</param>
        /// <param name="curvatureCoefficients">The curvature coefficient used when calculating friction losses.</param>
        /// <param name="wobbleCoefficients">The wobble coefficient used when calculating friction losses. [1/L]</param>
        /// <param name="lossAnchorages">The anchorage set slip. [L]</param>
        /// <param name="lossShortenings">The tendon stress loss due to elastic shortening. [F/L^2]</param>
        /// <param name="lossCreep">The tendon stress loss due to creep. [F/L^2]</param>
        /// <param name="lossShrinkages">The tendon stress loss due to shrinkage. [F/L^2]</param>
        /// <param name="lossSteelRelax">The tendon stress loss due to tendon steel relaxation. [F/L^2]</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are retrieved for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are retrieved for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are retrieved for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void GetLoadForceStress(string name,
            ref int numberItems,
            ref string[] tendonNames,
            ref string[] loadPatterns,
            ref eTendonJack[] jackedFrom,
            ref eTendonLoadType[] loadTypes,
            ref double[] values,
            ref double[] curvatureCoefficients,
            ref double[] wobbleCoefficients,
            ref double[] lossAnchorages,
            ref double[] lossShortenings,
            ref double[] lossCreep,
            ref double[] lossShrinkages,
            ref double[] lossSteelRelax,
            eItemType itemType = eItemType.Object)
        {
            int[] csiJackedFrom = new int[0];
            int[] csiLoadTypes = new int[0];

            _callCode = _sapModel.TendonObj.GetLoadForceStress(name, ref numberItems, ref tendonNames, ref loadPatterns, ref csiJackedFrom, ref csiLoadTypes, ref values, ref curvatureCoefficients, ref wobbleCoefficients, ref lossAnchorages, ref lossShortenings, ref lossCreep, ref lossShrinkages, ref lossSteelRelax, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            jackedFrom = csiJackedFrom.Cast<eTendonJack>().ToArray();
            loadTypes = csiLoadTypes.Cast<eTendonLoadType>().ToArray();
        }

        /// <summary>
        /// This function assigns force stress loads to objects.
        /// </summary>
        /// <param name="name">The name of an existing object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="loadPattern">The name of the load pattern associated with the force stress load.</param>
        /// <param name="jackedFrom">Indicates how the tendon is jacked.</param>
        /// <param name="loadType">Indicates the type of load.</param>
        /// <param name="value">The load value. [F] when <paramref name="loadType"/> = <see cref="eTendonLoadType.Force"/>, and [F/L^2] when <paramref name="loadType"/> = <see cref="eTendonLoadType.Stress"/>.</param>
        /// <param name="curvatureCoefficient">The curvature coefficient used when calculating friction losses.</param>
        /// <param name="wobbleCoefficient">The wobble coefficient used when calculating friction losses. [1/L]</param>
        /// <param name="lossAnchorage">The anchorage set slip. [L]</param>
        /// <param name="lossShortening">The tendon stress loss due to elastic shortening. [F/L^2]</param>
        /// <param name="lossCreep">The tendon stress loss due to creep. [F/L^2]</param>
        /// <param name="lossShrinkage">The tendon stress loss due to shrinkage. [F/L^2]</param>
        /// <param name="lossSteelRelax">The tendon stress loss due to tendon steel relaxation. [F/L^2]</param>
        /// <param name="replace">True: All previous force stress loads, if any, assigned to the specified object(s), in the specified load pattern, are deleted before making the new assignment.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are made for the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are made for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are made for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void SetLoadForceStress(string name,
            string loadPattern,
            eTendonJack jackedFrom,
            eTendonLoadType loadType,
            double value,
            double curvatureCoefficient,
            double wobbleCoefficient,
            double lossAnchorage,
            double lossShortening,
            double lossCreep,
            double lossShrinkage,
            double lossSteelRelax,
            bool replace = true,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.SetLoadForceStress(name, loadPattern, (int)jackedFrom, (int)loadType, value, curvatureCoefficient, wobbleCoefficient, lossAnchorage, lossShortening, lossCreep, lossShrinkage, lossSteelRelax, replace, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function deletes the force stress load assignments to the specified objects for the specified load pattern.
        /// </summary>
        /// <param name="name">The name of an existing object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="loadPattern">The name of the load pattern associated with the load.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are deleted for the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are deleted for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are deleted for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void DeleteLoadForceStress(string name,
            string loadPattern,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.TendonObj.DeleteLoadForceStress(name, loadPattern, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        #endregion

    }
}
