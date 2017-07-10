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
    /// <summary>
    /// Represents structural design in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
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
        /// <summary>
        /// Gets the design aluminum.
        /// </summary>
        /// <value>The design aluminum.</value>
        public DesignAluminum DesignAluminum => _designAluminum ?? (_designAluminum = new DesignAluminum(_seed));

        /// <summary>
        /// Gets the design cold formed.
        /// </summary>
        /// <value>The design cold formed.</value>
        public DesignColdFormed DesignColdFormed => _designColdFormed ?? (_designColdFormed = new DesignColdFormed(_seed));

        /// <summary>
        /// Gets the design concrete.
        /// </summary>
        /// <value>The design concrete.</value>
        public DesignConcrete DesignConcrete => _designConcrete ?? (_designConcrete = new DesignConcrete(_seed));

        /// <summary>
        /// Gets the design steel.
        /// </summary>
        /// <value>The design steel.</value>
        public DesignSteel DesignSteel => _designSteel ?? (_designSteel = new DesignSteel(_seed));
        #endregion


        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Designer"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public Designer(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }


        #endregion
    }
}
