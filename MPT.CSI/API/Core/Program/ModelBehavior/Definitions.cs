using MPT.CSI.API.Core.Program.ModelBehavior.Definition;
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
    public class Definitions : CSiApiBase
    {
        #region Properties
        private readonly CSiApiSeed _seed;

        private Groups _groups;

        private LoadPatterns _loadPatterns;
        #endregion

        #region Properties

        public Groups Groups => _groups ?? (_groups = new Groups(_seed));


        public LoadPatterns LoadPatterns => _loadPatterns ?? (_loadPatterns = new LoadPatterns(_seed));

        #endregion


        #region Initialization


        public Definitions(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }


        #endregion

        #region Methods : Public
        // Properties
        // === Areas ===

        /// <summary>
        /// Retrieves the method to determine the notional size of an area section for the creep and shrinkage calculations. 
        /// This function is currently worked for shell type area section.
        /// </summary>
        /// <param name="nameShellSection">The name of an existing shell-type area section property.</param>
        /// <param name="notionalSectionType">The type of notional size that is defined for the section.</param>
        /// <param name="value">For notionalSectionType "Auto", the Value represents for the scale factor to the program-determined notional size. 
        /// For notionalSectionType “User”, the Value represents for the user-defined notional size [L].</param>
        public void GetNotionalSize(string nameShellSection,
            ref string notionalSectionType,
            ref double value)
        {
            _callCode = _sapModel.PropArea.GetNotionalSize(nameShellSection, ref notionalSectionType, ref value);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Sets the method to determine the notional size of an area section for the creep and shrinkage calculations. 
        /// This function is currently worked for shell type area section.
        /// </summary>
        /// <param name="nameShellSection">The name of an existing shell-type area section property.</param>
        /// <param name="notionalSectionType">The type of notional size that is defined for the section.</param>
        /// <param name="value">For notionalSectionType "Auto", the Value represents for the scale factor to the program-determined notional size. 
        /// For notionalSectionType “User”, the Value represents for the user-defined notional size [L].</param>
        public void SetNotionalSize(string nameShellSection,
            string notionalSectionType,
            double value)
        {
            _callCode = _sapModel.PropArea.SetNotionalSize(nameShellSection, notionalSectionType, value);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
