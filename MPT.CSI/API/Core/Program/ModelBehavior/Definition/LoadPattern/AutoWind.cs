using MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.CodesAutoLoad.Wind;
using User = MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.CodesAutoLoad.Wind.User;
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
    /// Represents an auto wind load pattern in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.IAutoLoad" />
    public class AutoWind : CSiApiBase, IAutoLoad
    {
        #region Fields
        private readonly CSiApiSeed _seed;

        private User _User;
        private ASCE_7_02 _ASCE_7_02;

        #endregion

        #region Properties
        /// <summary>
        /// Auto wind load pattern according to user definitions.
        /// </summary>
        public User User => _User ?? (_User = new User(_seed));

        /// <summary>
        /// Auto wind load pattern according to ASCE 7-02.
        /// </summary>
        public ASCE_7_02 ASCE_7_02 => _ASCE_7_02 ?? (_ASCE_7_02 = new ASCE_7_02(_seed));


        #endregion

        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoWind"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public AutoWind(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }
        #endregion

        #region Methods: Interface

        /// <summary>
        /// This function retrieves the code name used for auto seismic parameters in Wind-type load patterns.
        /// An error is returned if the specified load pattern is not a Wind-type load pattern.
        /// </summary>
        /// <param name="name">The name of an existing Wind-type load pattern.</param>
        /// <param name="codeName">This is either blank or the name code used for the auto wind parameters. 
        /// Blank means no auto wind load is specified for the Wind-type load pattern.</param>
        public void GetAutoCode(string name,
            ref string codeName)
        {
            _callCode = _sapModel.LoadPatterns.GetAutoWindCode(name, ref codeName);

            // TODO: Figure out how to handle: An error is returned if the specified load pattern is not a Wind-type load pattern.

            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function set the auto wind loading type for the specified load pattern to None.
        /// </summary>
        /// <param name="name">The name of an existing Wind-type load pattern.</param>
        public void SetNone(string name)
        {
            _callCode = _sapModel.LoadPatterns.AutoWind.SetNone(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion

        #region Methods: Public
        /// <summary>
        /// This function retrieves exposure parameters for auto wind loads determined from extents of rigid diaphragms. 
        /// This function does not apply for User-type auto wind loads.
        /// </summary>
        /// <param name="patternName">The name of an existing Wind-type load pattern that has an auto wind load assigned.</param>
        /// <param name="numberOfDiaphragms">The number of diaphragms at which exposure data is reported.</param>
        /// <param name="diaphragmNames">This is an array that includes the names of the diaphragms that have eccentricity overrides.</param>
        /// <param name="xCoordinates">This is an array that includes the global X-coordinate of the point where the wind force load is applied to the diaphragm. [L]</param>
        /// <param name="yCoordinates">This is an array that includes the global Y-coordinate of the point where the wind force load is applied to the diaphragm. [L]</param>
        /// <param name="diaphragmWidth">This is an array that includes the exposure width for the wind load applied to the specified diaphragm. [L]</param>
        /// <param name="diaphragmDepth">This is an array that includes the exposure depth for the wind load applied to the specified diaphragm. [L]</param>
        /// <param name="diaphragmHeight">This is an array that includes the exposure height for the wind load applied to the specified diaphragm. [L]</param>
        public void GetExposure(string patternName,
            ref int numberOfDiaphragms,
            ref string[] diaphragmNames,
            ref double[] xCoordinates,
            ref double[] yCoordinates,
            ref double[] diaphragmWidth,
            ref double[] diaphragmDepth,
            ref double[] diaphragmHeight)
        {
            _callCode = _sapModel.LoadPatterns.AutoWind.GetExposure_1(patternName, ref numberOfDiaphragms, ref diaphragmNames, ref xCoordinates, ref yCoordinates, ref diaphragmWidth, ref diaphragmDepth, ref diaphragmHeight);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function assigns exposure parameters for auto wind loads determined from extents of rigid diaphragms. 
        /// This function does not apply for User-type auto wind loads.
        /// </summary>
        /// <param name="patternName">The name of an existing Wind-type load pattern that has an auto wind load assigned.</param>
        /// <param name="diaphragmName">The name of an existing special rigid diaphragm constraint, that is, a diaphragm constraint with the following features:
        /// 1. The constraint type is CONSTRAINT_DIAPHRAGM = 2.
        /// 2. The constraint coordinate system is Global.
        /// 3. The constraint axis is Z. </param>
        /// <param name="xCoordinate">The global X-coordinate of the point where the wind force is applied. [L]</param>
        /// <param name="yCoordinate">The global Y-coordinate of the point where the wind force is applied. [L]</param>
        /// <param name="diaphragmWidth">The exposure width for the wind load applied to the specified diaphragm. [L]</param>
        /// <param name="diaphragmDepth">The exposure depth for the wind load applied to the specified diaphragm. [L]</param>
        /// <param name="diaphragmHeight">The exposure height for the wind load applied to the specified diaphragm. [L]</param>
        public void SetExposure(string patternName,
            string diaphragmName,
            double xCoordinate,
            double yCoordinate,
            double diaphragmWidth,
            double diaphragmDepth,
            double diaphragmHeight)
        {
            _callCode = _sapModel.LoadPatterns.AutoWind.SetExposure_1(patternName, diaphragmName, xCoordinate, yCoordinate, diaphragmWidth, diaphragmDepth, diaphragmHeight);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion
    }
}
