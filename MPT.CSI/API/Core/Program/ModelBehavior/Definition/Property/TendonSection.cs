using System;
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

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Represents the tendon properties in the application.
    /// </summary>
    public class TendonSection : CSiApiBase, 
        IChangeableName, ICountable, IDeletable, IListableNames
    {
        #region Initialization

        public TendonSection(CSiApiSeed seed) : base(seed) { }

        #endregion

        #region Methods: Interface

        /// <summary>
        /// This function changes the name of an existing tendon property.
        /// </summary>
        /// <param name="currentName">The existing name of a defined tendon property.</param>
        /// <param name="newName">The new name for the tendon property.</param>
        public void ChangeName(string currentName, string newName)
        {
            _callCode = _sapModel.PropTendon.ChangeName(currentName, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function returns the total number of defined tendon properties in the model.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.PropTendon.Count();
        }

        /// <summary>
        /// The function deletes a specified tendon property.
        /// It returns an error if the specified property can not be deleted; for example, if it is currently used by a staged construction load case.
        /// </summary>
        /// <param name="name">The name of an existing tendon property.</param>
        public void Delete(string name)
        {
            _callCode = _sapModel.PropTendon.Delete(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of all defined tendon properties.
        /// </summary>
        /// <param name="numberOfNames">The number of tendon property names retrieved by the program.</param>
        /// <param name="names">Tendon property names retrieved by the program.</param>
        public void GetNameList(ref int numberOfNames, ref string[] names)
        {
            _callCode = _sapModel.PropTendon.GetNameList(ref numberOfNames, ref names);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion

        #region Methods: Public

        // === Get/Set ===
        /// <summary>
        /// This function retrieves tendon property definition data.
        /// </summary>
        /// <param name="name">The name of an existing tendon property.</param>
        /// <param name="nameMaterial">The name of the material property assigned to the tendon property.</param>
        /// <param name="modelingOption">Indicates the tendon modeling option.</param>
        /// <param name="area">The cross-sectional area of the tendon. [L^2]</param>
        /// <param name="color">The display color assigned to the property.</param>
        /// <param name="notes">The notes, if any, assigned to the property.</param>
        /// <param name="GUID">The GUID (global unique identifier), if any, assigned to the property.</param>
        public void GetProperty(string name,
            ref string nameMaterial,
            ref eTendonModelingOption modelingOption,
            ref double area,
            ref int color,
            ref string notes,
            ref string GUID)
        {
            int csiModelingOption = 0;

            _callCode = _sapModel.PropTendon.GetProp(name, ref nameMaterial, ref csiModelingOption, ref area, ref color, ref notes, ref GUID);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            modelingOption = (eTendonModelingOption)csiModelingOption;
        }

        /// <summary>
        /// This function defines a tendon property.
        /// </summary>
        /// <param name="name">The name of an existing or new tendon property. 
        /// If this is an existing property, that property is modified; otherwise, a new property is added.</param>
        /// <param name="nameMaterial">The name of the material property assigned to the tendon property.</param>
        /// <param name="modelingOption">Indicates the tendon modeling option.</param>
        /// <param name="area">The cross-sectional area of the cable. [L^2]</param>
        /// <param name="color">The display color assigned to the property.
        /// If Color is specified as -1, the program will automatically assign a color.</param>
        /// <param name="notes">The notes, if any, assigned to the property.</param>
        /// <param name="GUID">The GUID (global unique identifier), if any, assigned to the property.
        /// If this item is input as Default, the program assigns a GUID to the property.</param>
        public void SetProperty(string name,
            string nameMaterial,
            eTendonModelingOption modelingOption,
            double area,
            int color = -1,
            string notes = "",
            string GUID = "")
        {
            _callCode = _sapModel.PropTendon.SetProp(name, nameMaterial, (int)modelingOption, area, color, notes, GUID);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
