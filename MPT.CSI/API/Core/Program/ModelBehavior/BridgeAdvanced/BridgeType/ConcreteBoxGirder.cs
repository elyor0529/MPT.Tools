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

namespace MPT.CSI.API.Core.Program.ModelBehavior.BridgeAdvanced.BridgeType
{
    /// <summary>
    /// Represents the concrete box girder bridge superstructure in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class ConcreteBoxGirder : CSiApiBase
    {

        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="ConcreteBoxGirder"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public ConcreteBoxGirder(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Public

        public void CountSuperCutWebStressPoint(string param)
        {
            //_callCode = _sapModel.BridgeAdvancedSuper.BASConcBox.CountSuperCutWebStressPoint();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void GetSuperCutSectionPropsAtY(string param)
        {
            //_callCode = _sapModel.BridgeAdvancedSuper.BASConcBox.GetSuperCutSectionPropsAtY();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void GetSuperCutSectionValues(string param)
        {
            //_callCode = _sapModel.BridgeAdvancedSuper.BASConcBox.GetSuperCutSectionValues();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void GetSuperCutSlabCoordsAtX(string param)
        {
            //_callCode = _sapModel.BridgeAdvancedSuper.BASConcBox.GetSuperCutSlabCoordsAtX();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void GetSuperCutTendonNames(string param)
        {
            //_callCode = _sapModel.BridgeAdvancedSuper.BASConcBox.GetSuperCutTendonNames();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void GetSuperCutTendonValues(string param)
        {
            //_callCode = _sapModel.BridgeAdvancedSuper.BASConcBox.GetSuperCutTendonValues();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void GetSuperCutWebCoordsAtY(string param)
        {
            //_callCode = _sapModel.BridgeAdvancedSuper.BASConcBox.GetSuperCutWebCoordsAtY();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void GetSuperCutWebStressPoint(string param)
        {
            //_callCode = _sapModel.BridgeAdvancedSuper.BASConcBox.GetSuperCutWebStressPoint();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void GetSuperCutWebValues(string param)
        {
            //_callCode = _sapModel.BridgeAdvancedSuper.BASConcBox.GetSuperCutWebValues();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
