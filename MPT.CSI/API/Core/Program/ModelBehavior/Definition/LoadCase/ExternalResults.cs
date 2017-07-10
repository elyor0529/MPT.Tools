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

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Represents external results in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class ExternalResults : CSiApiBase
    {

        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalResults"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public ExternalResults(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Public

        public void GetThing(ref string param)
        {
            //_callCode = _sapModel.
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetThing(string param)
        {
            //_callCode = _sapModel.
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
