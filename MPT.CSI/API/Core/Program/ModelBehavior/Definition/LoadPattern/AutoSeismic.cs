using MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.CodesAutoLoad.Seismic;
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

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern
{
    /// <summary>
    /// Represents an auto seismic load pattern in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.IAutoLoad" />
    public class AutoSeismic : CSiApiBase, IAutoLoad
    {
        #region Properties
        private readonly CSiApiSeed _seed;

        private User _User;
        private IBC_2003 _IBC_2003;

        #endregion

        #region Properties
        /// <summary>
        /// Auto seismic load pattern according to user definitions.
        /// </summary>
        public User User => _User ?? (_User = new User(_seed));

        /// <summary>
        /// Auto seismic load pattern according to IBC 2003.
        /// </summary>
        public IBC_2003 IBC_2003 => _IBC_2003 ?? (_IBC_2003 = new IBC_2003(_seed));


        #endregion

        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoSeismic"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public AutoSeismic(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }


        #endregion

        #region Methods: Interface

        /// <summary>
        /// This function retrieves the code name used for auto seismic parameters in Quake-type load patterns.
        /// An error is returned if the specified load pattern is not a Quake-type load pattern.
        /// </summary>
        /// <param name="name">The name of an existing Quake-type load pattern.</param>
        /// <param name="codeName">This is either blank or the name code used for the auto seismic parameters. 
        /// Blank means no auto seismic load is specified for the Quake-type load pattern.</param>
        public void GetAutoCode(string name,
            ref string codeName)
        {
            _callCode = _sapModel.LoadPatterns.GetAutoSeismicCode(name, ref codeName);

            // TODO: Figure out how to handle: An error is returned if the specified load pattern is not a Quake-type load pattern.

            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function sets the auto seismic loading type for the specified load pattern to None.
        /// </summary>
        /// <param name="name">The name of an existing Quake-type load pattern.</param>
        public void SetNone(string name)
        {
            _callCode = _sapModel.LoadPatterns.AutoSeismic.SetNone(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion

        #region Methods: Public
        /// <summary>
        /// This function retrieves diaphragm eccentricity overrides for auto seismic loads. 
        /// This function does not apply for User Load type auto seismic loads.
        /// </summary>
        /// <param name="patternName">The name of an existing Quake-type load pattern that has an auto seismic load assigned.</param>
        /// <param name="numberOfOverrides">The number of diaphragm eccentricity overrides for the specified load pattern.</param>
        /// <param name="diaphragmNames">This is an array that includes the names of the diaphragms which have eccentricity overrides.</param>
        /// <param name="eccentricities">This is an array that includes the eccentricity applied to each diaphragm. [L]</param>
        public void GetDiaphragmEccentricityOverride(string patternName,
            ref int numberOfOverrides,
            ref string[] diaphragmNames,
            ref double[] eccentricities)
        {
            _callCode = _sapModel.LoadPatterns.AutoSeismic.GetDiaphragmEccentricityOverride(patternName, ref numberOfOverrides, ref diaphragmNames, ref eccentricities);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function assigns diaphragm eccentricity overrides for auto seismic loads. 
        /// This function does not apply for User Load type auto seismic loads.
        /// </summary>
        /// <param name="patternName">The name of an existing Quake-type load pattern that has an auto seismic load assigned.</param>
        /// <param name="diaphragmName">The name of an existing special rigid diaphragm constraint, that is, a diaphragm constraint with the following features:
        /// 1. The constraint type is CONSTRAINT_DIAPHRAGM = 2.
        /// 2. The constraint coordinate system is Global.
        /// 3. The constraint axis is Z.</param>
        /// <param name="eccentricity">The eccentricity applied to the specified diaphragm. [L</param>
        /// <param name="delete">True: Eccentricity override for the specified diaphragm is deleted.</param>
        public void SetDiaphragmEccentricityOverride(string patternName,
            string diaphragmName,
            double eccentricity,
            bool delete = false)
        {
            _callCode = _sapModel.LoadPatterns.AutoSeismic.SetDiaphragmEccentricityOverride(patternName, diaphragmName, eccentricity, delete);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion
    }
}
