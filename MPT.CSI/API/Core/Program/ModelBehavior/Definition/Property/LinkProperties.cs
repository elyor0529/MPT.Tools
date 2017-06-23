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
    /// Represents the link properties in the application.
    /// </summary>
    public class LinkProperties : CSiApiBase, 
        IChangeableName, ICountable, IDeletable, IListableNames
    {
        #region Initialization

        public LinkProperties(CSiApiSeed seed) : base(seed) { }

        #endregion

        #region Methods: Interface

        /// <summary>
        /// This function changes the name of an existing link property.
        /// </summary>
        /// <param name="currentName">The existing name of a defined link property.</param>
        /// <param name="newName">The new name for the link property.</param>
        public void ChangeName(string currentName, string newName)
        {
            _callCode = _sapModel.PropLink.ChangeName(currentName, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function returns the total number of defined link properties in the model.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.PropLink.Count();
        }

        /// <summary>
        /// The function deletes a specified link property.
        /// It returns an error if the specified property can not be deleted; for example, if it is currently used by a staged construction load case.
        /// </summary>
        /// <param name="name">The name of an existing link property.</param>
        public void Delete(string name)
        {
            _callCode = _sapModel.PropLink.Delete(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of all defined link properties.
        /// </summary>
        /// <param name="numberOfNames">The number of link property names retrieved by the program.</param>
        /// <param name="names">Link property names retrieved by the program.</param>
        public void GetNameList(ref int numberOfNames, ref string[] names)
        {
            _callCode = _sapModel.PropLink.GetNameList(ref numberOfNames, ref names);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion

        #region Methods: Public

        // === Get/Set ===
        // Note: Copy Get/SetModifier methods from NamedAssigns to here
        public void GetThing(ref string param)
        {
            //_callCode = _sapModel.PropLink.
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetThing(string param)
        {
            //_callCode = _sapModel.PropLink.
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
