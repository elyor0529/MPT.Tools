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

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.NamedAssign
{
    /// <summary>
    /// Represents the area modifiers in the application.
    /// </summary>
    public class AreaModifiers : CSiApiBase, 
        IChangeableName, ICountable, IDeletable, IListableNames, 
        IObservableModifiers, IChangeableModifiers
    {
        #region Initialization

        public AreaModifiers(CSiApiSeed seed) : base(seed) { }

        #endregion

        #region Methods: Interface

        /// <summary>
        /// This function changes the name of an existing area property modifier.
        /// </summary>
        /// <param name="currentName">The existing name of a defined area property modifier.</param>
        /// <param name="newName">The new name for the area property modifier.</param>
        public void ChangeName(string currentName, string newName)
        {
            _callCode = _sapModel.NamedAssign.ModifierArea.ChangeName(currentName, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function returns the total number of defined area property modifiers in the model.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.NamedAssign.ModifierArea.Count();
        }

        /// <summary>
        /// The function deletes a specified area property modifier.
        /// It returns an error if the specified property modifier can not be deleted; for example, if it is currently used by a staged construction load case.
        /// </summary>
        /// <param name="name">The name of an existing area property modifier.</param>
        public void Delete(string name)
        {
            _callCode = _sapModel.NamedAssign.ModifierArea.Delete(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of all defined area property modifiers.
        /// </summary>
        /// <param name="numberOfNames">The number of area property modifier names retrieved by the program.</param>
        /// <param name="names">Area property modifier names retrieved by the program.</param>
        public void GetNameList(ref int numberOfNames, ref string[] names)
        {
            _callCode = _sapModel.NamedAssign.ModifierArea.GetNameList(ref numberOfNames, ref names);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // === Get/Set
        /// <summary>
        /// This function retrieves the modifier assignment for areas. 
        /// The default value for all modifiers is one.
        /// </summary>
        /// <param name="name">The name of an existing area.</param>
        /// <param name="modifiers">Unitless modifiers.</param>
        public void GetModifiers(string name, ref Modifier modifiers)
        {
            if (modifiers == null) { modifiers = new Modifier(); }
            double[] csiModifiers = new double[0];

            _callCode = _sapModel.NamedAssign.ModifierArea.GetModifiers(name, ref csiModifiers);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            modifiers.FromArray(csiModifiers);
        }

        /// <summary>
        /// This function defines the modifier assignment for areas. 
        /// The default value for all modifiers is one.
        /// </summary>
        /// <param name="name">The name of an existing areas.</param>
        /// <param name="modifiers">Unitless modifiers.</param>
        public void SetModifiers(string name, Modifier modifiers)
        {
            if (modifiers == null) { return; }
            double[] csiModifiers = modifiers.ToArray();

            _callCode = _sapModel.NamedAssign.ModifierArea.SetModifiers(name, ref csiModifiers);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion
    }
}
