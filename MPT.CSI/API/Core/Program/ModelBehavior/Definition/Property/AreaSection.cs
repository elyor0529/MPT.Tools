using System;
using System.Linq;
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


#elif BUILD_ETABS2015
using ETABS2015;
#elif BUILD_ETABS2016
using ETABS2016;
#endif

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Represents the area properties in the application.
    /// </summary>area property
    public class AreaSection : CSiApiBase, 
        IChangeableName, ICountable, IDeletable, IListableNames, 
        IObservableModifiers, IChangeableModifiers
    {
        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="AreaSection"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public AreaSection(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Interface

        /// <summary>
        /// This function changes the name of an existing area property.
        /// </summary>
        /// <param name="currentName">The existing name of a defined area property.</param>
        /// <param name="newName">The new name for the area property.</param>
        public void ChangeName(string currentName, 
            string newName)
        {
            _callCode = _sapModel.PropArea.ChangeName(currentName, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function returns the total number of defined area properties in the model.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.PropArea.Count();
        }

        /// <summary>
        /// The function deletes a specified area property.
        /// It returns an error if the specified property can not be deleted; for example, if it is currently used by a staged construction load case.
        /// </summary>
        /// <param name="name">The name of an existing area property.</param>
        public void Delete(string name)
        {
            _callCode = _sapModel.PropArea.Delete(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of all defined area properties.
        /// </summary>
        /// <param name="numberOfNames">The number of area property names retrieved by the program.</param>
        /// <param name="names">Area property names retrieved by the program.</param>
        public void GetNameList(ref int numberOfNames, 
            ref string[] names)
        {
            _callCode = _sapModel.PropArea.GetNameList(ref numberOfNames, ref names);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of all defined area properties of the specified type.
        /// </summary>
        /// <param name="numberOfNames">The number of area property names retrieved by the program.</param>
        /// <param name="names">Area property names retrieved by the program.</param>
        /// <param name="areaType">The area type to filter the name list by.</param>
        public void GetNameList(ref int numberOfNames,
            ref string[] names,
            eAreaSectionType areaType)
        {
            _callCode = _sapModel.PropArea.GetNameList(ref numberOfNames, ref names, (int)areaType);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        // === Get/Set ===

        /// <summary>
        /// This function retrieves the modifier assignment for area properties. 
        /// The default value for all modifiers is one.
        /// </summary>
        /// <param name="name">The name of an existing area property.</param>
        /// <param name="modifiers">Unitless modifiers.</param>
        public void GetModifiers(string name, 
            ref Modifier modifiers)
        {
            if (modifiers == null) { modifiers = new Modifier(); }
            double[] csiModifiers = new double[0];

            _callCode = _sapModel.PropArea.GetModifiers(name, ref csiModifiers);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            modifiers.FromArray(csiModifiers);
        }

        /// <summary>
        /// This function defines the modifier assignment for area properties. 
        /// The default value for all modifiers is one.
        /// </summary>
        /// <param name="name">The name of an existing area property.</param>
        /// <param name="modifiers">Unitless modifiers.</param>
        public void SetModifiers(string name, 
            Modifier modifiers)
        {
            if (modifiers == null) { return; }
            double[] csiModifiers = modifiers.ToArray();

            _callCode = _sapModel.PropArea.SetModifiers(name, ref csiModifiers);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion

        #region Methods: Public        
        /// <summary>
        /// This function retrieves the property type for the specified area property.
        /// </summary>
        /// <param name="name">The name of an existing area property.</param>
        /// <param name="areaPropertyType">Type of the area property.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void GetType(string name,
            ref eAreaSectionType areaPropertyType)
        {
            int csiAreaPropertyType = 0;
            _callCode = _sapModel.PropArea.GetTypeOAPI(name, ref csiAreaPropertyType);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            areaPropertyType = (eAreaSectionType)csiAreaPropertyType;
        }

        /// <summary>
        /// This function retrieves area property data for an asolid-type area section.
        /// </summary>
        /// <param name="name">The name of an existing asolid-type area property.</param>
        /// <param name="materialProperty">The name of the material property for the area property.</param>
        /// <param name="materialAngle">The material angle. [deg]</param>
        /// <param name="arcAngle">The arc angle through which the area object is passed to define the asolid element. [deg]</param>
        /// <param name="incompatibleBendingModes">True: Incompatible bending modes are included in the stiffness formulation. 
        /// In general, incompatible modes significantly improve the bending behavior of the object.</param>
        /// <param name="coordinateSystem">The area object is rotated about the Z-axis in this coordinate system to define the asolid element.</param>
        /// <param name="color">The display color assigned to the property.</param>
        /// <param name="notes">The notes, if any, assigned to the property.</param>
        /// <param name="GUID">The GUID (global unique identifier), if any, assigned to the property.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void GetASolid(string name,
            ref string materialProperty,
            ref double materialAngle,
            ref double arcAngle,
            ref bool incompatibleBendingModes,
            ref string coordinateSystem,
            ref int color,
            ref string notes,
            ref string GUID)
        {
            _callCode = _sapModel.PropArea.GetAsolid(name, ref materialProperty, ref materialAngle, ref arcAngle, ref incompatibleBendingModes, ref coordinateSystem, ref color, ref notes, ref GUID);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function initializes an asolid-type area property. 
        /// If this function is called for an existing area property, all items for the property are reset to their default value.
        /// </summary>
        /// <param name="name">The name of an existing asolid-type area property.</param>
        /// <param name="materialProperty">The name of the material property for the area property.</param>
        /// <param name="materialAngle">The material angle. [deg]</param>
        /// <param name="arcAngle">The arc angle through which the area object is passed to define the asolid element. [deg]
        /// A value of zero means 1 radian (approximately 57.3 degrees).</param>
        /// <param name="incompatibleBendingModes">True: Incompatible bending modes are included in the stiffness formulation. 
        /// In general, incompatible modes significantly improve the bending behavior of the object.</param>
        /// <param name="coordinateSystem">The area object is rotated about the Z-axis in this coordinate system to define the asolid element.</param>
        /// <param name="color">The display color assigned to the property.
        /// If Color is specified as -1, the program will automatically assign a color.</param>
        /// <param name="notes">The notes, if any, assigned to the property.</param>
        /// <param name="GUID">The GUID (global unique identifier), if any, assigned to the property.
        /// If this item is input as Default, the program assigns a GUID to the property.</param>
        public void SetASolid(string name,
            string materialProperty,
            double materialAngle,
            double arcAngle,
            bool incompatibleBendingModes,
            string coordinateSystem = CoordinateSystems.Global,
            int color = -1,
            string notes = "",
            string GUID = "")
        {
            _callCode = _sapModel.PropArea.SetAsolid(name, materialProperty, materialAngle, arcAngle, incompatibleBendingModes, coordinateSystem, color, notes, GUID);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        /// <summary>
        /// This function retrieves area property data for a plane-type area section.
        /// </summary>
        /// <param name="name">The name of an existing plane-type area property.</param>
        /// <param name="planeType">Type of the plane.</param>
        /// <param name="materialProperty">The name of the material property for the area property.</param>
        /// <param name="materialAngle">The material angle. [deg]</param>
        /// <param name="thickness">The plane thickness. [L]</param>
        /// <param name="incompatibleModes">True: Incompatible bending modes are included in the stiffness formulation. 
        /// In general, incompatible modes significantly improve the bending behavior of the object.</param>
        /// <param name="color">The display color assigned to the property.</param>
        /// <param name="notes">The notes, if any, assigned to the property.</param>
        /// <param name="GUID">The GUID (global unique identifier), if any, assigned to the property.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void GetPlane(string name,
            ref ePlaneType planeType,
            ref string materialProperty,
            ref double materialAngle,
            ref double thickness,
            ref bool incompatibleModes,
            ref int color,
            ref string notes,
            ref string GUID)
        {
            int csiPlaneType = 0;

            _callCode = _sapModel.PropArea.GetPlane(name, ref csiPlaneType, ref materialProperty, ref materialAngle, ref thickness, ref incompatibleModes, ref color, ref notes, ref GUID);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            planeType = (ePlaneType) csiPlaneType;
        }

        /// <summary>
        /// This function initializes a plane-type area property. 
        /// If this function is called for an existing area property, all items for the property are reset to their default value.
        /// </summary>
        /// <param name="name">The name of an existing plane-type area property.</param>
        /// <param name="planeType">Type of the plane.</param>
        /// <param name="materialProperty">The name of the material property for the area property.</param>
        /// <param name="materialAngle">The material angle. [deg]</param>
        /// <param name="thickness">The plane thickness. [L]</param>
        /// <param name="incompatibleModes">True: Incompatible bending modes are included in the stiffness formulation. 
        /// In general, incompatible modes significantly improve the bending behavior of the object.</param>
        /// <param name="color">The display color assigned to the property.
        /// If Color is specified as -1, the program will automatically assign a color.</param>
        /// <param name="notes">The notes, if any, assigned to the property.</param>
        /// <param name="GUID">The GUID (global unique identifier), if any, assigned to the property.
        /// If this item is input as Default, the program assigns a GUID to the property.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void SetPlane(string name,
            ePlaneType planeType,
            string materialProperty,
            double materialAngle,
            double thickness,
            bool incompatibleModes,
            int color = -1,
            string notes = "",
            string GUID = "")
        {
            _callCode = _sapModel.PropArea.SetPlane(name, (int)planeType, materialProperty, materialAngle, thickness, incompatibleModes, color, notes, GUID);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        /// <summary>
        /// This function retrieves area property data for a shell-type area section.
        /// </summary>
        /// <param name="name">The name of an existing shell-type area property.</param>
        /// <param name="shellType">Type of shell.</param>
        /// <param name="includeDrillingDOF">True: Drilling degrees of freedom are included in the element formulation in the analysis model. 
        /// This item does not apply when <paramref name="shellType"/> = <see cref="eShellType.PlateThin"/>, <see cref="eShellType.PlateThick"/> or <see cref="eShellType.ShellLayered"/>.</param>
        /// <param name="materialProperty">The name of the material property for the area property. 
        /// This item does not apply when <paramref name="shellType"/> = <see cref="eShellType.ShellLayered"/>.</param>
        /// <param name="materialAngle">The material angle. [deg]
        /// This item does not apply when <paramref name="shellType"/> = <see cref="eShellType.ShellLayered"/>.</param>
        /// <param name="membraneThickness">The membrane thickness. [L]
        /// This item does not apply when <paramref name="shellType"/> = <see cref="eShellType.ShellLayered"/>.</param>
        /// <param name="bendingThickness">The bending thickness. [L]
        /// This item does not apply when <paramref name="shellType"/> = <see cref="eShellType.ShellLayered"/>.</param>
        /// <param name="color">The display color assigned to the property.</param>
        /// <param name="notes">The notes, if any, assigned to the property.</param>
        /// <param name="GUID">The GUID (global unique identifier), if any, assigned to the property.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void GetShell(string name,
            ref eShellType shellType,
            ref bool includeDrillingDOF,
            ref string materialProperty,
            ref double materialAngle,
            ref double membraneThickness,
            ref double bendingThickness,
            ref int color,
            ref string notes,
            ref string GUID)
        {
            int csiShellType = 0;

            _callCode = _sapModel.PropArea.GetShell_1(name, ref csiShellType, ref includeDrillingDOF, ref materialProperty, ref materialAngle, ref membraneThickness, ref bendingThickness, ref color, ref notes, ref GUID);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            shellType = (eShellType)csiShellType;
        }

        /// <summary>
        /// The name of an existing or new area property. 
        /// If this is an existing property, that property is modified; otherwise, a new property is added.
        /// </summary>
        /// <param name="name">The name of an existing shell-type area property.</param>
        /// <param name="shellType">Type of shell.</param>
        /// <param name="includeDrillingDOF">True: Drilling degrees of freedom are included in the element formulation in the analysis model. 
        /// This item does not apply when <paramref name="shellType"/> = <see cref="eShellType.PlateThin"/>, <see cref="eShellType.PlateThick"/> or <see cref="eShellType.ShellLayered"/>.</param>
        /// <param name="materialProperty">The name of the material property for the area property. 
        /// This item does not apply when <paramref name="shellType"/> = <see cref="eShellType.ShellLayered"/>.</param>
        /// <param name="materialAngle">The material angle. [deg]
        /// This item does not apply when <paramref name="shellType"/> = <see cref="eShellType.ShellLayered"/>.</param>
        /// <param name="membraneThickness">The membrane thickness. [L]
        /// This item does not apply when <paramref name="shellType"/> = <see cref="eShellType.ShellLayered"/>.</param>
        /// <param name="bendingThickness">The bending thickness. [L]
        /// This item does not apply when <paramref name="shellType"/> = <see cref="eShellType.ShellLayered"/>.</param>
        /// <param name="color">The display color assigned to the property.
        /// If Color is specified as -1, the program will automatically assign a color.</param>
        /// <param name="notes">The notes, if any, assigned to the property.</param>
        /// <param name="GUID">The GUID (global unique identifier), if any, assigned to the property.
        /// If this item is input as Default, the program assigns a GUID to the property.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void SetShell(string name,
            eShellType shellType,
            bool includeDrillingDOF,
            string materialProperty,
            double materialAngle,
            double membraneThickness,
            double bendingThickness,
            int color = -1,
            string notes = "",
            string GUID = "")
        {
            _callCode = _sapModel.PropArea.SetShell_1(name, (int)shellType, includeDrillingDOF, materialProperty, materialAngle, membraneThickness, bendingThickness, color, notes, GUID);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        /// <summary>
        /// This function retrieves area property design parameters for a shell-type area section.
        /// </summary>
        /// <param name="name">The name of an existing shell-type area property.</param>
        /// <param name="materialProperty">The name of the material property for the area property.</param>
        /// <param name="rebarLayout">The rebar layout option.</param>
        /// <param name="designCoverTopDirection1">The cover to the centroid of the top reinforcing steel running in the local 1 axis directions of the area object. [L]
        /// This item applies only when <paramref name="rebarLayout"/> = <see cref="eShellSteelLayoutOption.OneLayer"/> or <see cref="eShellSteelLayoutOption.TwoLayers"/>.</param>
        /// <param name="designCoverTopDirection2">The cover to the centroid of the top reinforcing steel running in the local 2 axis directions of the area object. [L]
        /// This item applies only when <paramref name="rebarLayout"/> = <see cref="eShellSteelLayoutOption.OneLayer"/> or <see cref="eShellSteelLayoutOption.TwoLayers"/>.</param>
        /// <param name="designCoverBottomDirection1">The cover to the centroid of the bottom reinforcing steel running in the local 1 axis directions of the area object. [L]
        /// This item applies only when <paramref name="rebarLayout"/> = <see cref="eShellSteelLayoutOption.TwoLayers"/>.</param>
        /// <param name="designCoverBottomDirection2">The cover to the centroid of the bottom reinforcing steel running in the local 2 axis directions of the area object. [L]
        /// This item applies only when <paramref name="rebarLayout"/> = <see cref="eShellSteelLayoutOption.TwoLayers"/>.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void GetShellDesign(string name,
            ref string materialProperty,
            ref eShellSteelLayoutOption rebarLayout,
            ref double designCoverTopDirection1,
            ref double designCoverTopDirection2,
            ref double designCoverBottomDirection1,
            ref double designCoverBottomDirection2)
        {
            int csiRebarLayout = 0;

            _callCode = _sapModel.PropArea.GetShellDesign(name, ref materialProperty, ref csiRebarLayout, ref designCoverTopDirection1, ref designCoverTopDirection2, ref designCoverBottomDirection1, ref designCoverBottomDirection2);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            rebarLayout = (eShellSteelLayoutOption)csiRebarLayout;
        }

        /// <summary>
        /// This function assigns the design parameters for shell-type area properties.
        /// </summary>
        /// <param name="name">The name of an existing shell-type area property.</param>
        /// <param name="materialProperty">The name of the material property for the area property.</param>
        /// <param name="rebarLayout">The rebar layout option.</param>
        /// <param name="designCoverTopDirection1">The cover to the centroid of the top reinforcing steel running in the local 1 axis directions of the area object. [L]
        /// This item applies only when <paramref name="rebarLayout"/> = <see cref="eShellSteelLayoutOption.OneLayer"/> or <see cref="eShellSteelLayoutOption.TwoLayers"/>.</param>
        /// <param name="designCoverTopDirection2">The cover to the centroid of the top reinforcing steel running in the local 2 axis directions of the area object. [L]
        /// This item applies only when <paramref name="rebarLayout"/> = <see cref="eShellSteelLayoutOption.OneLayer"/> or <see cref="eShellSteelLayoutOption.TwoLayers"/>.</param>
        /// <param name="designCoverBottomDirection1">The cover to the centroid of the bottom reinforcing steel running in the local 1 axis directions of the area object. [L]
        /// This item applies only when <paramref name="rebarLayout"/> = <see cref="eShellSteelLayoutOption.TwoLayers"/>.</param>
        /// <param name="designCoverBottomDirection2">The cover to the centroid of the bottom reinforcing steel running in the local 2 axis directions of the area object. [L]
        /// This item applies only when <paramref name="rebarLayout"/> = <see cref="eShellSteelLayoutOption.TwoLayers"/>.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void SetShellDesign(string name,
            string materialProperty,
            eShellSteelLayoutOption rebarLayout,
            double designCoverTopDirection1,
            double designCoverTopDirection2,
            double designCoverBottomDirection1,
            double designCoverBottomDirection2)
        {
            _callCode = _sapModel.PropArea.SetShellDesign(name, materialProperty, (int)rebarLayout, designCoverTopDirection1, designCoverTopDirection2, designCoverBottomDirection1, designCoverBottomDirection2);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        /// <summary>
        /// The name of an existing shell-type area property that is specified to be a layered shell property.
        /// </summary>
        /// <param name="name">The name of an existing shell-type area property that is specified to be a layered shell property.</param>
        /// <param name="numberOfLayers">The number of layers in the area property.</param>
        /// <param name="layerNames">This is an array that includes the name of each layer.</param>
        /// <param name="distanceOffsets">This is an array that includes the distance from the area reference surface (area object joint location plus offsets) to the mid-height of the layer. [L].</param>
        /// <param name="thicknesses">This is an array that includes the thickness of each layer. [L].</param>
        /// <param name="layerTypes">The layer types.</param>
        /// <param name="numberOfIntegrationPoints">The number of integration points in the thickness direction for the layer. 
        /// The locations are determined by the program using standard Guass-quadrature rules.</param>
        /// <param name="materialProperties">This is an array that includes the name of the material property for the l.</param>
        /// <param name="materialAngles">This is an array that includes the material angle for the layer. [deg].</param>
        /// <param name="S11Types">The material component behavior in the S11 direction.</param>
        /// <param name="S22Types">The material component behavior in the S22 directions.</param>
        /// <param name="S12Types">The material component behavior in the S12 directions.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void GetShellLayer(string name,
            ref int numberOfLayers,
            ref string[] layerNames,
            ref double[] distanceOffsets,
            ref double[] thicknesses,
            ref eShellLayerType[] layerTypes,
            ref int[] numberOfIntegrationPoints,
            ref string[] materialProperties,
            ref double[] materialAngles,
            ref eMaterialComponentBehaviorType[] S11Types,
            ref eMaterialComponentBehaviorType[] S22Types,
            ref eMaterialComponentBehaviorType[] S12Types)
        {
            int[] csiLayerTypes = new int[0];
            int[] csiS11Types = new int[0];
            int[] csiS22Types = new int[0];
            int[] csiS12Types = new int[0];

            _callCode = _sapModel.PropArea.GetShellLayer_1(name, ref numberOfLayers, ref layerNames, ref distanceOffsets, ref thicknesses, ref csiLayerTypes, ref numberOfIntegrationPoints, ref materialProperties, ref materialAngles, ref csiS11Types, ref csiS22Types, ref csiS12Types);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            layerTypes = csiLayerTypes.Cast<eShellLayerType>().ToArray();
            S11Types = csiS11Types.Cast<eMaterialComponentBehaviorType>().ToArray();
            S22Types = csiS22Types.Cast<eMaterialComponentBehaviorType>().ToArray();
            S12Types = csiS12Types.Cast<eMaterialComponentBehaviorType>().ToArray();
        }

        /// <summary>
        /// The name of an existing shell-type area property that is specified to be a layered shell property
        /// </summary>
        /// <param name="name">The name of an existing shell-type area property that is specified to be a layered shell property.</param>
        /// <param name="numberOfLayers">The number of layers in the area property.</param>
        /// <param name="layerNames">This is an array that includes the name of each layer.</param>
        /// <param name="distanceOffsets">This is an array that includes the distance from the area reference surface (area object joint location plus offsets) to the mid-height of the layer. [L].</param>
        /// <param name="thicknesses">This is an array that includes the thickness of each layer. [L].</param>
        /// <param name="layerTypes">The layer types.</param>
        /// <param name="numberOfIntegrationPoints">The number of integration points in the thickness direction for the layer. 
        /// The locations are determined by the program using standard Guass-quadrature rules.</param>
        /// <param name="materialProperties">This is an array that includes the name of the material property for the l.</param>
        /// <param name="materialAngles">This is an array that includes the material angle for the layer. [deg].</param>
        /// <param name="S11Types">The material component behavior in the S11 direction.</param>
        /// <param name="S22Types">The material component behavior in the S22 directions.</param>
        /// <param name="S12Types">The material component behavior in the S12 directions.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void SetShellLayer(string name,
            int numberOfLayers,
            string[] layerNames,
            double[] distanceOffsets,
            double[] thicknesses,
            eShellLayerType[] layerTypes,
            int[] numberOfIntegrationPoints,
            string[] materialProperties,
            double[] materialAngles,
            eMaterialComponentBehaviorType[] S11Types,
            eMaterialComponentBehaviorType[] S22Types,
            eMaterialComponentBehaviorType[] S12Types)
        {
            int[] csiLayerTypes = layerTypes.Cast<int>().ToArray();
            int[] csiS11Types = S11Types.Cast<int>().ToArray();
            int[] csiS22Types = S22Types.Cast<int>().ToArray();
            int[] csiS12Types = S12Types.Cast<int>().ToArray();

            _callCode = _sapModel.PropArea.SetShellLayer_1(name, ref numberOfLayers, ref layerNames, ref distanceOffsets, ref thicknesses, ref csiLayerTypes, ref numberOfIntegrationPoints, ref materialProperties, ref materialAngles, ref csiS11Types, ref csiS22Types, ref csiS12Types);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion

    }
}
