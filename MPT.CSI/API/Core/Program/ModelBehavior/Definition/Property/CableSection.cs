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

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Represents the cable properties in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class CableSection : CSiApiBase, 
        IChangeableName, ICountable, IDeletable, IListableNames, 
        IObservableModifiers, IChangeableModifiers
    {
        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="CableSection"/> class.
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
        public void ChangeName(string currentName, 
            string newName)
        {
            _callCode = _sapModel.PropCable.ChangeName(currentName, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function returns the total number of defined cable properties in the model.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.PropCable.Count();
        }

        /// <summary>
        /// The function deletes a specified cable property.
        /// It returns an error if the specified property can not be deleted; for example, if it is currently used by a staged construction load case.
        /// </summary>
        /// <param name="name">The name of an existing cable property.</param>
        public void Delete(string name)
        {
            _callCode = _sapModel.PropCable.Delete(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of all defined cable properties.
        /// </summary>
        /// <param name="numberOfNames">The number of cable property names retrieved by the program.</param>
        /// <param name="names">Cable property names retrieved by the program.</param>
        public void GetNameList(ref int numberOfNames, 
            ref string[] names)
        {
            _callCode = _sapModel.PropCable.GetNameList(ref numberOfNames, ref names);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // === Get/Set ===

        /// <summary>
        /// This function retrieves the modifier assignment for cable properties. 
        /// The default value for all modifiers is one.
        /// </summary>
        /// <param name="name">The name of an existing cable property.</param>
        /// <param name="modifiers">Unitless modifiers.</param>
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
