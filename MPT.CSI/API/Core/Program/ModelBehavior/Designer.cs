using System;
using MPT.CSI.API.Core.Program.ModelBehavior.Design;
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

namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    public class Designer : CSiApiBase
    {
        #region Properties
        private readonly CSiApiSeed _seed;

        private DesignAluminum _designAluminum;

        private DesignColdFormed _designColdFormed;

        private DesignConcrete _designConcrete;

        private DesignSteel _designSteel;
        #endregion

        #region Properties

        public DesignAluminum DesignAluminum => _designAluminum ?? (_designAluminum = new DesignAluminum(_seed));

        public DesignColdFormed DesignColdFormed => _designColdFormed ?? (_designColdFormed = new DesignColdFormed(_seed));

        public DesignConcrete DesignConcrete => _designConcrete ?? (_designConcrete = new DesignConcrete(_seed));

        public DesignSteel DesignSteel => _designSteel ?? (_designSteel = new DesignSteel(_seed));
        #endregion


        #region Initialization


        public Designer(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }


        #endregion

        #region Methods



        #endregion
    }
}
