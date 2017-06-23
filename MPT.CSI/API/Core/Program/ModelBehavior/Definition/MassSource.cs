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

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Represents the mass source in the application.
    /// </summary>
    public class MassSource : CSiApiBase, IChangeableName, ICountable, IDeletable, IListableNames
    {

        #region Fields


        #endregion


        #region Properties



        #endregion


        #region Initialization

        public MassSource(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Public

        /// <summary>
        /// This function changes the name of an existing mass source.
        /// If the new name already exists, a nonzero value is returned and the mass source name is not changed.
        /// </summary>
        /// <param name="nameMassSource">The name of an existing mass source.</param>
        /// <param name="newName">The new name for the mass source.</param>
        public void ChangeName(string nameMassSource,
            string newName)
        {
            // TODO: Handle: If the new name already exists, a nonzero value is returned and the mass source name is not changed.

            _callCode = _sapModel.SourceMass.ChangeName(nameMassSource, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        /// <summary>
        /// This function returns the number of defined mass sources.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.SourceMass.Count();
        }


        /// <summary>
        /// This function deletes an existing mass source.
        /// If the mass source to be deleted is the default mass source, a nonzero value is returned and th mass source is not deleted.
        /// </summary>
        /// <param name="nameMassSource">The name of the mass source to be deleted.</param>
        public void Delete(string nameMassSource)
        {
            // TODO: Handle: If the mass source to be deleted is the default mass source, a nonzero value is returned and th mass source is not deleted.

            _callCode = _sapModel.SourceMass.Delete(nameMassSource);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        // === Get/Set ===

        /// <summary>
        /// This function retrieves the names of all defined mass sources.
        /// </summary>
        /// <param name="numberNames">The number of mass source names retrieved by the program.</param>
        /// <param name="namesMassSource">Mass source names retrieved by the program.</param>
        public void GetNameList(ref int numberNames,
            ref string[] namesMassSource)
        {
            _callCode = _sapModel.SourceMass.GetNameList(ref numberNames, ref namesMassSource);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // ===

        /// <summary>
        /// This function gets the mass source data for an existing mass source.
        /// </summary>
        /// <param name="nameMassSource">The mass source name.</param>
        /// <param name="massFromElements">True: Element self mass is included in the mass.</param>
        /// <param name="massFromMasses">True: Assigned masses are included in the mass.</param>
        /// <param name="massFromLoads">True: Specified load patterns are included in the mass.</param>
        /// <param name="isDefault">True: Mass source is the default mass source.  
        /// Only one mass source can be the default mass source so when this assignment is True all other mass sources are automatically set to have the IsDefault flag False.</param>
        /// <param name="numberLoads">The number of load patterns specified for the mass source.  
        /// This item is only applicable when the MassFromLoads item is True.</param>
        /// <param name="namesLoadPatterns">This is an array of load pattern names specified for the mass source.</param>
        /// <param name="scaleFactors">This is an array of load pattern multipliers specified for the mass source.</param>
        public void GetMassSource(string nameMassSource,
            ref bool massFromElements,
            ref bool massFromMasses,
            ref bool massFromLoads,
            ref bool isDefault,
            ref int numberLoads,
            ref string[] namesLoadPatterns,
            ref double[] scaleFactors)
        {
            _callCode = _sapModel.SourceMass.GetMassSource(nameMassSource, ref massFromElements, ref massFromMasses, ref massFromLoads, ref isDefault, ref numberLoads, ref namesLoadPatterns, ref scaleFactors);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function adds a new mass source to the model or reinitializes an existing mass source.
        /// </summary>
        /// <param name="nameMassSource">The mass source name. 
        /// If a mass source with this name already exists then the mass source is reinitialized with the new data.  
        /// All previous data assigned to the mass source is lost. 
        /// If a mass source with this name does not exist then a new mass source is added.</param>
        /// <param name="massFromElements">True: Element self mass is included in the mass.</param>
        /// <param name="massFromMasses">True: Assigned masses are included in the mass.</param>
        /// <param name="massFromLoads">True: Specified load patterns are included in the mass.</param>
        /// <param name="isDefault">True: Mass source is the default mass source.  
        /// Only one mass source can be the default mass source so when this assignment is True all other mass sources are automatically set to have the IsDefault flag False.</param>
        /// <param name="numberLoads">The number of load patterns specified for the mass source.  
        /// This item is only applicable when the MassFromLoads item is True.</param>
        /// <param name="namesLoadPatterns">This is an array of load pattern names specified for the mass source.</param>
        /// <param name="scaleFactors">This is an array of load pattern multipliers specified for the mass source.</param>
        public void SetMassSource(string nameMassSource,
            bool massFromElements,
            bool massFromMasses,
            bool massFromLoads,
            bool isDefault,
            int numberLoads,
            string[] namesLoadPatterns,
            double[] scaleFactors)
        {
            _callCode = _sapModel.SourceMass.SetMassSource(nameMassSource, massFromElements, massFromMasses, massFromLoads, isDefault, numberLoads, ref namesLoadPatterns, ref scaleFactors);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        // ===

        /// <summary>
        /// This function retrieves the default mass source name.
        /// </summary>
        /// <param name="nameMassSource">The name of the mass source to be flagged as the default mass source.</param>
        public void GetDefault(ref string nameMassSource)
        {
            _callCode = _sapModel.SourceMass.GetDefault(ref nameMassSource);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function sets the default mass source.
        /// Only one mass source can be the default mass source so when this assignment is set all other mass sources are automatically set to have their IsDefault flag False.
        /// </summary>
        /// <param name="nameMassSource">The name of the mass source to be flagged as the default mass source.</param>
        public void SetDefault(string nameMassSource)
        {
            _callCode = _sapModel.SourceMass.SetDefault(nameMassSource);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
