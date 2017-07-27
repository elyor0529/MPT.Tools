using MPT.CSI.API.Core.Support;
using MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern;

#if BUILD_SAP2000v16
using CSiProgram = SAP2000v16;
#elif BUILD_SAP2000v17
using CSiProgram = SAP2000v17;
#elif BUILD_SAP2000v18
using CSiProgram = SAP2000v18;
#elif BUILD_SAP2000v19
using CSiProgram = SAP2000v19;
#elif BUILD_ETABS2013
using CSiProgram = ETABS2013;


#elif BUILD_ETABS2015
using CSiProgram = ETABS2015;
#elif BUILD_ETABS2016
using CSiProgram = ETABS2016;
#endif

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Represents load patterns in the application.
    /// </summary>
    public class LoadPatterns : CSiApiBase, IChangeableName, ICountable, IDeletable, IListableNames
    {
        #region Fields
        private readonly CSiApiSeed _seed;
        
        private AutoSeismic _autoSeismicPattern;
        private AutoWave _autoWavePattern;
        private AutoWind _autoWindPattern;
        #endregion


        #region Properties

        /// <summary>
        /// Represents an auto seismic load pattern in the application.
        /// </summary>
        public AutoSeismic AutoSeismicPattern => _autoSeismicPattern ?? (_autoSeismicPattern = new AutoSeismic(_seed));

        /// <summary>
        /// Represents an auto wave load pattern in the application.
        /// </summary>
        public AutoWave AutoWavePattern => _autoWavePattern ?? (_autoWavePattern = new AutoWave(_seed));

        /// <summary>
        /// Represents an auto wind load pattern in the application.
        /// </summary>
        public AutoWind AutoWindPattern => _autoWindPattern ?? (_autoWindPattern = new AutoWind(_seed));
        #endregion


        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadPatterns"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public LoadPatterns(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }
        #endregion

        #region Methods: Public
        /// <summary>
        /// Adds a new load pattern.
        /// An error is returned if the <paramref name="name"/> item is already used for an existing load pattern.
        /// </summary>
        /// <param name="name">Name for the new load pattern.</param>
        /// <param name="loadPatternType">Load pattern type.</param>
        /// <param name="selfWeightMultiplier">Self weight multiplier for the new load pattern.</param>
        /// <param name="addLoadCase">True: A linear static load case corresponding to the new load pattern is added.</param>
        public void Add(string name,
            eLoadPatternType loadPatternType,
            double selfWeightMultiplier = 0,
            bool addLoadCase = true)
        {
            // TODO: Decide how to handle this: An error is returned if the Name item is already used for an existing load pattern. 

            _callCode = _sapModel.LoadPatterns.Add(name, CSiEnumConverter.ToCSi(loadPatternType), selfWeightMultiplier, addLoadCase);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// The number of defined load patterns.
        /// </summary>
        public int Count()
        {
            return _sapModel.LoadPatterns.Count();
        }

        /// <summary>
        /// The function deletes the specified load pattern.
        /// The load pattern is not deleted and the function returns an error if the load pattern is assigned to an load case or if it is the only defined load pattern.
        /// </summary>
        /// <param name="name">The name of an existing load pattern.</param>
        public void Delete(string name)
        {
            // TODO: Decide how to handle this: The load pattern is not deleted and the function returns an error if the load pattern is assigned to an load case or if it is the only defined load pattern.

            _callCode = _sapModel.LoadPatterns.Delete(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of all defined load cases.
        /// </summary>
        /// <param name="numberOfNames">The number of load pattern names retrieved by the program.</param>
        /// <param name="loadPatternNames">This is a one-dimensional array of load pattern names.</param>
        public void GetNameList(ref int numberOfNames,
            ref string[] loadPatternNames)
        {
            _callCode = _sapModel.LoadPatterns.GetNameList(ref numberOfNames, ref loadPatternNames);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function applies a new name to a load pattern.
        /// </summary>
        /// <param name="name">The name of a defined load pattern.</param>
        /// <param name="newName">The new name for the load pattern.</param>
        public void ChangeName(string name,
            string newName)
        {
            _callCode = _sapModel.LoadPatterns.ChangeName(name, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // === Get/Set


        /// <summary>
        /// This function retrieves the load type for a specified load pattern.
        /// </summary>
        /// <param name="name">The name of an existing load pattern.</param>
        /// <param name="loadPatternType">This is one of the items in the eLoadPatternType enumeration.</param>
        public void GetLoadType(string name,
            ref eLoadPatternType loadPatternType)
        {
            CSiProgram.eLoadPatternType csiLoadPatternType = CSiProgram.eLoadPatternType.Other;
            _callCode = _sapModel.LoadPatterns.GetLoadType(name, ref csiLoadPatternType);

            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            loadPatternType = CSiEnumConverter.FromCSi(csiLoadPatternType);
        }

        /// <summary>
        /// This function assigns a load type to a load pattern.
        /// </summary>
        /// <param name="name">The name of an existing load pattern.</param>
        /// <param name="loadPatternType">This is one of the items in the eLoadPatternType enumeration.</param>
        public void SetLoadType(string name,
            eLoadPatternType loadPatternType)
        {
            _callCode = _sapModel.LoadPatterns.SetLoadType(name, CSiEnumConverter.ToCSi(loadPatternType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // ===

        /// <summary>
        /// This function retrieves the self weight multiplier for a specified load pattern.
        /// </summary>
        /// <param name="name">The name of an existing load pattern.</param>
        /// <param name="selfWeightMultiplier">The self weight multiplier for the specified load pattern.</param>
        public void GetSelfWtMultiplier(string name,
            ref double selfWeightMultiplier)
        {
            _callCode = _sapModel.LoadPatterns.GetSelfWTMultiplier(name, ref selfWeightMultiplier);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function assigns a self weight multiplier to a load case.
        /// </summary>
        /// <param name="name">The name of an existing load pattern.</param>
        /// <param name="selfWeightMultiplier">The self weight multiplier for the specified load pattern.</param>
        public void SetSelfWtMultiplier(string name,
            double selfWeightMultiplier)
        {
            _callCode = _sapModel.LoadPatterns.SetSelfWTMultiplier(name, selfWeightMultiplier);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion
    }
}
