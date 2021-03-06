﻿// ***********************************************************************
// Assembly         : MPT.CSI.API
// Author           : Mark Thomas
// Created          : 06-11-2017
//
// Last Modified By : Mark Thomas
// Last Modified On : 10-08-2017
// ***********************************************************************
// <copyright file="CableSection.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
using MPT.CSI.API.Core.Helpers;
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Represents the cable properties in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property.ICableSection" />
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class CableSection : CSiApiBase, ICableSection
    {
        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="CableSection" /> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public CableSection(CSiApiSeed seed) : base(seed) { }

        #endregion

        #region Methods: Interface

        /// <summary>
        /// This function changes the name of an existing cable property.
        /// </summary>
        /// <param name="currentName">The existing name of a defined cable property.</param>
        /// <param name="newName">The new name for the cable property.</param>
        /// <exception cref="CSiException"></exception>
        public void ChangeName(string currentName, 
            string newName)
        {
            _callCode = _sapModel.PropCable.ChangeName(currentName, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function returns the total number of defined cable properties in the model.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _sapModel.PropCable.Count();
        }

        /// <summary>
        /// The function deletes a specified cable property.
        /// It returns an error if the specified property can not be deleted; for example, if it is currently used by a staged construction load case.
        /// </summary>
        /// <param name="name">The name of an existing cable property.</param>
        /// <exception cref="CSiException"></exception>
        public void Delete(string name)
        {
            _callCode = _sapModel.PropCable.Delete(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of all defined cable properties.
        /// </summary>
        /// <param name="names">Cable property names retrieved by the program.</param>
        /// <exception cref="CSiException"></exception>
        public void GetNameList(ref string[] names)
        {
            _callCode = _sapModel.PropCable.GetNameList(ref _numberOfItems, ref names);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // === Get/Set ===

        /// <summary>
        /// This function retrieves the modifier assignment for cable properties.
        /// The default value for all modifiers is one.
        /// </summary>
        /// <param name="name">The name of an existing cable property.</param>
        /// <param name="modifiers">Unitless modifiers.</param>
        /// <exception cref="CSiException"></exception>
        public void GetModifiers(string name, 
            ref Modifier modifiers)
        {
            if (modifiers == null) { modifiers = new Modifier(); }
            double[] csiModifiers = new double[0];

            _callCode = _sapModel.PropCable.GetModifiers(name, ref csiModifiers);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            modifiers.FromArray(csiModifiers);
        }

        /// <summary>
        /// This function defines the modifier assignment for cable properties.
        /// The default value for all modifiers is one.
        /// </summary>
        /// <param name="name">The name of an existing cable property.</param>
        /// <param name="modifiers">Unitless modifiers.</param>
        /// <exception cref="CSiException"></exception>
        public void SetModifiers(string name,
            Modifier modifiers)
        {
            if (modifiers == null) { return; }
            double[] csiModifiers = modifiers.ToArray();

            _callCode = _sapModel.PropCable.SetModifiers(name, ref csiModifiers);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion

        #region Methods: Public

        /// <summary>
        /// This function retrieves cable property definition data.
        /// </summary>
        /// <param name="name">The name of an existing cable property.</param>
        /// <param name="nameMaterial">The name of the material property assigned to the cable property.</param>
        /// <param name="area">The cross-sectional area of the cable. [L^2]</param>
        /// <param name="color">The display color assigned to the property.</param>
        /// <param name="notes">The notes, if any, assigned to the property.</param>
        /// <param name="GUID">The GUID (global unique identifier), if any, assigned to the property.</param>
        /// <exception cref="CSiException"></exception>
        public void GetProperty(string name,
            ref string nameMaterial,
            ref double area,
            ref int color,
            ref string notes,
            ref string GUID)
        {
            _callCode = _sapModel.PropCable.GetProp(name, ref nameMaterial, ref area, ref color, ref notes, ref GUID);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function defines a cable property.
        /// </summary>
        /// <param name="name">The name of an existing or new cable property.
        /// If this is an existing property, that property is modified; otherwise, a new property is added.</param>
        /// <param name="nameMaterial">The name of the material property assigned to the cable property.</param>
        /// <param name="area">The cross-sectional area of the cable. [L^2]</param>
        /// <param name="color">The display color assigned to the property.
        /// If Color is specified as -1, the program will automatically assign a color.</param>
        /// <param name="notes">The notes, if any, assigned to the property.</param>
        /// <param name="GUID">The GUID (global unique identifier), if any, assigned to the property.
        /// If this item is input as Default, the program assigns a GUID to the property.</param>
        /// <exception cref="CSiException"></exception>
        public void SetProperty(string name,
            string nameMaterial,
            double area,
            int color = -1,
            string notes = "",
            string GUID = "")
        {
            _callCode = _sapModel.PropCable.SetProp(name, nameMaterial, area, color, notes, GUID);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

#endregion
    }
}
#endif
