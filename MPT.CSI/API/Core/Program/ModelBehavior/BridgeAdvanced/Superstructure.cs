using MPT.CSI.API.Core.Program.ModelBehavior.BridgeAdvanced.BridgeType;
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

namespace MPT.CSI.API.Core.Program.ModelBehavior.BridgeAdvanced
{
    /// <summary>
    /// Represents the bridge superstructure in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class Superstructure : CSiApiBase
    {

        #region Fields
        private readonly CSiApiSeed _seed;

        private ConcreteBoxGirder _concreteBoxGirder;
        #endregion


        #region Properties        
        /// <summary>
        /// Gets the concrete box girder.
        /// </summary>
        /// <value>The concrete box girder.</value>
        public ConcreteBoxGirder ConcreteBoxGirder => _concreteBoxGirder ?? (_concreteBoxGirder = new ConcreteBoxGirder(_seed));


        #endregion


        #region Initialization        

        /// <summary>
        /// Initializes a new instance of the <see cref="Superstructure"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public Superstructure(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }


        #endregion

        #region Methods: Public

        public void GetSuperCutStressPoint(string param)
        {
            //_callCode = _sapModel.BridgeAdvancedSuper.GetSuperCutStressPoint();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function returns the number of stress points at the specified superstructure section cut.
        /// If the bridge object is not currently linked to existing objects in the model, an error is returned.
        /// TODO: Handle the error?
        /// </summary>
        /// <param name="name">The name of an existing bridge object.</param>
        /// <param name="cutIndex">The index number of section cut in this bridge object. 
        /// This must be from 0 to <paramref name="numberOfStressPoints"/>-1, where <paramref name="numberOfStressPoints"/> is the value returned by function <see cref="CountSuperCut"/>.</param>
        /// <param name="numberOfStressPoints">The number of stress points for this section cut in this bridge object. 
        /// They will be identified in subsequent API functions using the indices 0 to <paramref name="numberOfStressPoints"/>-1.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void CountSuperCutStressPoint(string name,
            int cutIndex,
            ref int numberOfStressPoints)
        {
            //_callCode = _sapModel.BridgeAdvancedSuper.CountSuperCutStressPoint(name, cutIndex, ref numberOfStressPoints);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        public void GetSuperCutLocation(ref string param)
        {
            //_callCode = _sapModel.
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function returns the number of superstructure section cuts that are available for getting analysis results and performing design.
        /// If the bridge object is not currently linked to existing objects in the model, an error is returned.
        /// TODO: Handle?
        /// </summary>
        /// <param name="name">The name of an existing bridge object.</param>
        /// <param name="count">The number of section cuts in this bridge object. 
        /// They will be identified in subsequent API functions using the indices 0 to <paramref name="count"/>-1. 
        /// There may be one or two section cuts at each output station along the length of the superstructure.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void CountSuperCut(string name,
            ref int count)
        {
            //_callCode = _sapModel.BridgeAdvancedSuper.CountSuperCut(name, ref count);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion
    }
}
