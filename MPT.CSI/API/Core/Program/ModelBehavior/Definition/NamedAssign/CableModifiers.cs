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
    /// Represents the cable modifiers in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class CableModifiers : CSiApiBase, 
        IChangeableName, ICountable, IDeletable, IListableNames, 
        IObservableModifiers, IChangeableModifiers
    {
        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="CableModifiers"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public CableModifiers(CSiApiSeed seed) : base(seed) { }

        #endregion

        #region Methods: Interface

        /// <summary>
        /// This function changes the name of an existing cable property modifier.
        /// </summary>
        /// <param name="currentName">The existing name of a defined cable property modifier.</param>
        /// <param name="newName">The new name for the cable property modifier.</param>
        public void ChangeName(string currentName, 
            string newName)
        {
            _callCode = _sapModel.NamedAssign.ModifierCable.ChangeName(currentName, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function returns the total number of defined cable property modifiers in the model.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.NamedAssign.ModifierCable.Count();
        }

        /// <summary>
        /// The function deletes a specified cable property modifier.
        /// It returns an error if the specified property modifier can not be deleted; for example, if it is currently used by a staged construction load case.
        /// </summary>
        /// <param name="name">The name of an existing cable property modifier.</param>
        public void Delete(string name)
        {
            _callCode = _sapModel.NamedAssign.ModifierCable.Delete(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of all defined cable property modifiers.
        /// </summary>
        /// <param name="numberOfNames">The number of cable property modifier names retrieved by the program.</param>
        /// <param name="names">Cable property modifier names retrieved by the program.</param>
        public void GetNameList(ref int numberOfNames, 
            ref string[] names)
        {
            _callCode = _sapModel.NamedAssign.ModifierCable.GetNameList(ref numberOfNames, ref names);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // === Get/Set
        /// <summary>
        /// This function retrieves the modifier assignment for cables. 
        /// The default value for all modifiers is one.
        /// </summary>
        /// <param name="name">The name of an existing cable.</param>
        /// <param name="modifiers">Unitless modifiers.</param>
        public void GetModifiers(string name, 
            ref Modifier modifiers)
        {
            if (modifiers == null) { modifiers = new Modifier(); }
            double[] csiModifiers = new double[0];

            _callCode = _sapModel.NamedAssign.ModifierCable.GetModifiers(name, ref csiModifiers);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            modifiers.FromArray(csiModifiers);
        }

        /// <summary>
        /// This function defines the modifier assignment for cables. 
        /// The default value for all modifiers is one.
        /// </summary>
        /// <param name="name">The name of an existing cables.</param>
        /// <param name="modifiers">Unitless modifiers.</param>
        public void SetModifiers(string name, 
            Modifier modifiers)
        {
            if (modifiers == null) { return; }
            double[] csiModifiers = modifiers.ToArray();

            _callCode = _sapModel.NamedAssign.ModifierCable.SetModifiers(name, ref csiModifiers);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion
    }
}
