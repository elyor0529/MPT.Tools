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

namespace MPT.CSI.API.Core.Program.ModelBehavior.Design.CodesDesign.Steel
{
    /// <summary>
    /// Steel design code API_RP2A_WSD_2014.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class API_RP2A_WSD_2014 : CSiApiBase
    {
        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="API_RP2A_WSD_2014"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public API_RP2A_WSD_2014(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Public


        public void GetOverwrite(string nameFrame)
        {
            //_callCode = _sapModel.SapModel.DesignSteel.AISC360_05_IBC2006.GetOverwrite();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        public void GetPreference()
        {
            //_callCode = _sapModel.SapModel.DesignSteel.AISC360_05_IBC2006.GetPreference();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        public void SetOverwrite(string nameFrame, eItemType itemType = eItemType.Object)
        {
            //_callCode = _sapModel.SapModel.DesignSteel.AISC360_05_IBC2006.SetOverwrite();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        public void SetPreference()
        {
            //_callCode = _sapModel.SapModel.DesignSteel.AISC360_05_IBC2006.SetPreference();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion
    }
}
