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

namespace MPT.CSI.API.Core.Program.ModelBehavior.Edit
{
    /// <summary>
    /// Represents the solid editor in the application.
    /// </summary>
    public class SolidEditor : CSiApiBase
    {
        #region Initialization

        public SolidEditor(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Public

        /// <summary>
        /// This function meshes solid objects.
        /// </summary>
        /// <param name="name">The name of an existing solid object.</param>
        /// <param name="number2_4">This is the number of objects created between faces 2 and 4 of the solid object.</param>
        /// <param name="number1_3">This is the number of objects created between faces 1 and 3 of the solid object.</param>
        /// <param name="number5_6">This is the number of objects created between faces 5 and 6 of the solid object.</param>
        /// <param name="numberSolids">The number of solid objects created when the specified solid object is divided.</param>
        /// <param name="solidNames">This is an array of the name of each solid object created when the specified solid object is divided.</param>
        public void Divide(string name,
            int number2_4,
            int number1_3,
            int number5_6,
            int numberSolids,
            string[] solidNames)
        {
            _callCode = _sapModel.EditSolid.Divide(name, number2_4, number1_3, number5_6, ref numberSolids, ref solidNames);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
