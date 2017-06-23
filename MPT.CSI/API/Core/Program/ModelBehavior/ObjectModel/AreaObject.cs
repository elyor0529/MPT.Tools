using System;
using MPT.CSI.API.Core.Helpers;
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
    /// Represents the area object in the application.
    /// </summary>
    public class AreaObject : CSiApiBase, IAreaObject
    {

        #region Initialization

        public AreaObject(CSiApiSeed seed) : base(seed) { }
        #endregion

        #region Methods: Interface

        /// <summary>
        /// This function changes the name of an existing area object.
        /// </summary>
        /// <param name="currentName">The existing name of a defined area object.</param>
        /// <param name="newName">The new name for the area object.</param>
        public void ChangeName(string currentName, string newName)
        {
            _callCode = _sapModel.AreaObj.ChangeName(currentName, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function returns the total number of defined area properties in the model.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.AreaObj.Count();
        }

        /// <summary>
        /// The function deletes a specified area object.
        /// It returns an error if the specified object can not be deleted; for example, if it is currently used by a staged construction load case.
        /// </summary>
        /// <param name="name">The name of an existing area object.</param>
        public void Delete(string name)
        {
            _callCode = _sapModel.AreaObj.Delete(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // === Get ===

        /// <summary>
        /// This function retrieves the names of all items.
        /// </summary>
        /// <param name="numberOfNames">The number of item names retrieved by the program.</param>
        /// <param name="names">Names retrieved by the program.</param>
        public void GetNameList(ref int numberOfNames,
            ref string[] names)
        {
            _callCode = _sapModel.AreaObj.GetNameList(ref numberOfNames, ref names);
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
            _callCode = _sapModel.AreaObj.GetTransformationMatrix(nameCoordinateSystem, ref directionCosines);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of the point objects that define an area object.
        /// </summary>
        /// <param name="name">The name of an existing area object.</param>
        /// <param name="numberPoints">The number of point objects that define the area object.</param>
        /// <param name="points">The names of the points that defined the area object.
        /// The point names are listed in the positive order around the object.</param>
        public void GetPoints(string name, ref int numberPoints, ref string[] points)
        {
            _callCode = _sapModel.AreaObj.GetPoints(name, ref numberPoints, ref points);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        // === Get/Set ===


        /// <summary>
        /// This function retrieves the section property assigned to an area object.
        /// </summary>
        /// <param name="name">The name of a defined area object.</param>
        /// <param name="propertyName">The name of the section property assigned to the area object. 
        /// This item is None if there is no section property assigned to the area object.</param>
        public void GetSection(string name, ref string propertyName)
        {
            _callCode = _sapModel.AreaObj.GetProperty(name, ref propertyName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function assigns the section property to an area object.
        /// </summary>
        /// <param name="name">The name of a defined area object.</param>
        /// <param name="propertyName">The name of the section property assigned to the area object.</param>
        /// <param name="itemType">If this item is Object, the assignment is made to the area object specified by the Name item.
        /// If this item is Group, the assignment is made to all area objects in the group specified by the Name item.
        /// If this item is SelectedObjects, assignment is made to all selected area objects, and the Name item is ignored.</param>
        public void SetSection(string name, string propertyName, eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.AreaObj.SetProperty(name, propertyName, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        // ===

        /// <summary>
        /// This function retrieves the modifier assignment for area objects. 
        /// The default value for all modifiers is one.
        /// </summary>
        /// <param name="name">The name of an existing area object.</param>
        /// <param name="modifiers">Unitless modifiers.</param>
        public void GetModifiers(string name, ref Modifier modifiers)
        {
            if (modifiers == null) { modifiers = new Modifier(); }
            double[] csiModifiers = new double[0];

            _callCode = _sapModel.AreaObj.GetModifiers(name, ref csiModifiers);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            modifiers.FromArray(csiModifiers);
        }

        /// <summary>
        /// This function defines the modifier assignment for area objects. 
        /// The default value for all modifiers is one.
        /// </summary>
        /// <param name="name">The name of an existing area object.</param>
        /// <param name="modifiers">Unitless modifiers.</param>
        public void SetModifiers(string name, Modifier modifiers)
        {
            if (modifiers == null) { return; }
            double[] csiModifiers = modifiers.ToArray();

            _callCode = _sapModel.AreaObj.SetModifiers(name, ref csiModifiers);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the material overwrite assigned to an area object, if any. 
        /// The material property name is indicated as None if there is no material overwrite assignment.
        /// </summary>
        /// <param name="name">The name of a defined area object.</param>
        /// <param name="propertyName">This is None, indicating that no material overwrite exists for the specified area object, or it is the name of an existing material property.</param>
        public void GetMaterialOverwrite(string name,
            ref string propertyName)
        {
            _callCode = _sapModel.AreaObj.GetMaterialOverwrite(name, ref propertyName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the local axis angle assignment for the area .
        /// </summary> 
        /// <param name="name">The name of an existing area object.</param>
        /// <param name="angleOffset">This is the angle 'a' that the local 1 and 2 axes are rotated about the positive local 3 axis from the default orientation. 
        /// The rotation for a positive angle appears counter clockwise when the local +3 axis is pointing toward you. [deg]</param>
        /// <param name="isAdvanced">True area object local axes orientation was obtained using advanced local axes parameters.</param>
        public void GetLocalAxes(string name,
            ref AngleLocalAxes angleOffset,
            ref bool isAdvanced)
        {
            double angleA = 0;
            _callCode = _sapModel.AreaObj.GetLocalAxes(name, ref angleA, ref isAdvanced);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            angleOffset.AngleA = angleA;
        }

        // === Loads ===

        /// <summary>
        /// This function retrieves the material temperature assignments to objects.
        /// </summary>
        /// <param name="name">The name of an existing object.</param>
        /// <param name="temperature">This is the material temperature value assigned to the object. [T]</param>
        /// <param name="patternName">This is blank or the name of a defined joint pattern. 
        /// If it is blank, the material temperature for the line object is uniform along the object at the value specified by <paramref name="temperature"/>.
        /// If PatternName is the name of a defined joint pattern, the material temperature for the line object may vary from one end to the other.
        /// The material temperature at each end of the object is equal to the specified temperature multiplied by the pattern value at the joint at the end of the line object.</param>
        public void GetMaterialTemperature(string name,
            ref double temperature,
            ref string patternName)
        {
            _callCode = _sapModel.AreaObj.GetMatTemp(name, ref temperature, ref patternName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the gravity load assignments to objects.
        /// </summary>
        /// <param name="name">The name of an existing object, object or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="numberItems">The total number of gravity loads retrieved for the specified objects.</param>
        /// <param name="names">The name of the object associated with each gravity load.</param>
        /// <param name="loadPatterns">The name of the coordinate system in which the gravity load multipliers are specified.</param>
        /// <param name="coordinateSystems">The name of the coordinate system associated with each gravity load.</param>
        /// <param name="xLoadMultiplier">Gravity load multipliers in the x direction of the specified coordinate system.</param>
        /// <param name="yLoadMultiplier">Gravity load multipliers in the y direction of the specified coordinate system.</param>
        /// <param name="zLoadMultiplier">Gravity load multipliers in the z direction of the specified coordinate system.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the load assignments are retrieved for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the load assignments are retrieved for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the load assignments are retrieved for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void GetLoadGravity(string name,
            ref int numberItems,
            ref string[] names,
            ref string[] loadPatterns,
            ref string[] coordinateSystems,
            ref double[] xLoadMultiplier,
            ref double[] yLoadMultiplier,
            ref double[] zLoadMultiplier,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.AreaObj.GetLoadGravity(name, ref numberItems, ref names, ref loadPatterns, ref coordinateSystems, ref xLoadMultiplier, ref yLoadMultiplier, ref zLoadMultiplier, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the pore pressure load assignments to objects.
        /// </summary>
        /// <param name="name">The name of an existing object or group, depending on the value of the <paramref name="itemType"/> item.</param>
        /// <param name="numberItems">The total number of pore pressure loads retrieved for the specified objects.</param>
        /// <param name="names">The name of the object associated with each pore pressure load.</param>
        /// <param name="loadPatterns">The name of the load pattern associated with each pore pressure load.</param>
        /// <param name="porePressureLoadValues">The pore pressure values. [F/L^2]</param>
        /// <param name="jointPatternNames">The joint pattern name, if any, used to specify the pore pressure load.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the load assignments are retrieved for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the load assignments are retrieved for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the load assignments are retrieved for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void GetLoadPorePressure(string name,
            ref int numberItems,
            ref string[] names,
            ref string[] loadPatterns,
            ref double[] porePressureLoadValues,
            ref string[] jointPatternNames,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.AreaObj.GetLoadPorePressure(name, ref numberItems, ref names, ref loadPatterns, ref porePressureLoadValues, ref jointPatternNames, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the strain load assignments to objects.
        /// </summary>
        /// <param name="name">The name of an existing object, object or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="numberItems">The total number of strain loads retrieved for the specified objects.</param>
        /// <param name="names">The name of the object associated with each strain load.</param>
        /// <param name="loadPatterns">The name of the load pattern associated with each strain load.</param>
        /// <param name="component">Indicates the strain component associated with each strain load.</param>
        /// <param name="strainLoadValues">The strain values. [L/L]</param>
        /// <param name="jointPatternNames">The joint pattern name, if any, used to specify each strain load.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the load assignments are retrieved for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the load assignments are retrieved for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the load assignments are retrieved for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void GetLoadStrain(string name,
            ref int numberItems,
            ref string[] names,
            ref string[] loadPatterns,
            ref eStrainComponent[] component,
            ref double[] strainLoadValues,
            ref string[] jointPatternNames,
            eItemType itemType = eItemType.Object)
        {
            int[] csiComponent = new int[0];

            _callCode = _sapModel.AreaObj.GetLoadStrain(name, ref numberItems, ref names, ref loadPatterns, ref csiComponent, ref strainLoadValues, ref jointPatternNames, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            component = new eStrainComponent[csiComponent.Length - 1];
            for (int i = 0; i < csiComponent.Length; i++)
            {
                component[i] = (eStrainComponent)csiComponent[i];
            }
        }

        /// <summary>
        /// This function retrieves the surface pressure assignments to objects.
        /// </summary>
        /// <param name="name">The name of an existing object, object or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="numberItems">The total number of surface pressure loads retrieved for the specified objects.</param>
        /// <param name="names">The name of the object associated with each surface pressure load.</param>
        /// <param name="loadPatterns">The name of the load pattern associated with each surface pressure load.</param>
        /// <param name="faceApplied">The object face to which each specified load assignment applies.
        /// Note that edge face n is from plane object point n to plane object point n + 1. For example, edge face 2 is from plane object point 2 to plane object point 3.</param>
        /// <param name="surfacePressureLoadValues">The surface pressure values. [F/L^2]</param>
        /// <param name="jointPatternNames">The joint pattern name, if any, used to specify each surface pressure load.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the load assignments are retrieved for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the load assignments are retrieved for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the load assignments are retrieved for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void GetLoadSurfacePressure(string name,
            ref int numberItems,
            ref string[] names,
            ref string[] loadPatterns,
            ref eFace[] faceApplied,
            ref double[] surfacePressureLoadValues,
            ref string[] jointPatternNames,
            eItemType itemType = eItemType.Object)
        {
            int[] csiFaceApplied = new int[0];

            _callCode = _sapModel.AreaObj.GetLoadSurfacePressure(name, ref numberItems, ref names, ref loadPatterns, ref csiFaceApplied, ref surfacePressureLoadValues, ref jointPatternNames, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            faceApplied = new eFace[csiFaceApplied.Length - 1];
            for (int i = 0; i < csiFaceApplied.Length; i++)
            {
                faceApplied[i] = (eFace)csiFaceApplied[i];
            }
        }

        /// <summary>
        /// This function retrieves the temperature load assignments to objects.
        /// </summary>
        /// <param name="name">The name of an existing object or group, depending on the value of the <paramref name="itemType"/> item.</param>
        /// <param name="numberItems">The total number of temperature loads retrieved for the specified objects.</param>
        /// <param name="names">The name of the object associated with each temperature load.</param>
        /// <param name="loadPatterns">The name of the load pattern associated with each temperature load.</param>
        /// <param name="temperatureLoadType">Indicates the type of temperature load for each load pattern.</param>
        /// <param name="temperatureLoadValues">Temperature load values. [T] for <paramref name="temperatureLoadType"/> = Temperature, [T/L] for all others.</param>
        /// <param name="jointPatternNames">The joint pattern name, if any, used to specify the temperature load.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the load assignments are retrieved for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the load assignments are retrieved for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the load assignments are retrieved for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void GetLoadTemperature(string name,
            ref int numberItems,
            ref string[] names,
            ref string[] loadPatterns,
            ref eLoadTemperatureType[] temperatureLoadType,
            ref double[] temperatureLoadValues,
            ref string[] jointPatternNames,
            eItemType itemType = eItemType.Object)
        {
            int[] csiTemperatureLoadType = new int[0];

            _callCode = _sapModel.AreaObj.GetLoadTemperature(name, ref numberItems, ref names, ref loadPatterns, ref csiTemperatureLoadType, ref temperatureLoadValues, ref jointPatternNames, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            temperatureLoadType = new eLoadTemperatureType[csiTemperatureLoadType.Length - 1];
            for (int i = 0; i < csiTemperatureLoadType.Length; i++)
            {
                temperatureLoadType[i] = (eLoadTemperatureType)csiTemperatureLoadType[i];
            }
        }

        /// <summary>
        /// This function retrieves the uniform load assignments to objects.
        /// </summary>
        /// <param name="name">The name of an existing object, object or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="numberItems">The total number of uniform loads retrieved for the specified objects.</param>
        /// <param name="names">The name of the object associated with each uniform load.</param>
        /// <param name="loadPatterns">The name of the load pattern associated with each uniform load.</param>
        /// <param name="coordinateSystems">The name of the coordinate system associated with each uniform load.</param>
        /// <param name="directionApplied">The direction that the load is applied for each load pattern.</param>
        /// <param name="uniformLoadValues">The uniform load values. [F/L^2]</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the load assignments are retrieved for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the load assignments are retrieved for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the load assignments are retrieved for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void GetLoadUniform(string name,
            ref int numberItems,
            ref string[] names,
            ref string[] loadPatterns,
            ref string[] coordinateSystems,
            ref eLoadDirection[] directionApplied,
            ref double[] uniformLoadValues,
            eItemType itemType = eItemType.Object)
        {
            int[] csiDirectionApplied = new int[0];

            _callCode = _sapModel.AreaObj.GetLoadUniform(name, ref numberItems, ref names, ref loadPatterns, ref coordinateSystems, ref csiDirectionApplied, ref uniformLoadValues, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            directionApplied = new eLoadDirection[csiDirectionApplied.Length - 1];
            for (int i = 0; i < csiDirectionApplied.Length; i++)
            {
                directionApplied[i] = (eLoadDirection)csiDirectionApplied[i];
            }
        }


        /// <summary>
        /// This function retrieves the rotate load assignments to elements.
        /// </summary>
        /// <param name="name">The name of an existing object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="numberItems">The total number of rotate loads retrieved for the specified elements.</param>
        /// <param name="names">The name of the element associated with each rotate load.</param>
        /// <param name="loadPatterns">The name of the load pattern associated with each rotate load.</param>
        /// <param name="rotateLoadValues">Rotate load values. [F/L^2]</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the load assignments are retrieved for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the load assignments are retrieved for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the load assignments are retrieved for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void GetLoadRotate(string name,
            ref int numberItems,
            ref string[] names,
            ref string[] loadPatterns,
            ref double[] rotateLoadValues,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.AreaObj.GetLoadRotate(name, ref numberItems, ref names, ref loadPatterns, ref rotateLoadValues, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion

        #region Methods: Public


        public void GetOffsets()
        {
            //_callCode = _sapModel.AreaObj.
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        public void GetThickness()
        {
            //_callCode = _sapModel.AreaObj.
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        
        #endregion
    }
}
