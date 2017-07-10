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
    /// Represents model and application options in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class Options : CSiApiBase
    {

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Options"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public Options(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Public
        /// <summary>
        /// This function retrieves the program dimension and tolerance items.
        /// </summary>
        /// <param name="cuttingPlaneTol">The tolerance for 2D view cutting planes. [L]</param>
        /// <param name="worldSpacing">The plan fine grid spacing. [L]</param>
        /// <param name="nudgeValue">The plan nudge value. [L]</param>
        /// <param name="pixelClickSize">The screen selection tolerance in pixels.</param>
        /// <param name="pixelSnapSize">The screen snap tolerance in pixels.</param>
        /// <param name="screenLineThickness">The screen line thickness in pixels.</param>
        /// <param name="printLineThickness">The printer line thickness in pixels.</param>
        /// <param name="maxFont">The maximum graphic font size in points.</param>
        /// <param name="minFont">The minimum graphic font size in points.</param>
        /// <param name="zoomStep">The auto zoom step size in percent (0 &lt; ZoomStep &lt;= 100).</param>
        /// <param name="shrinkFactor">The shrink factor in percent (0 &lt; ShrinkFact &lt;= 100).</param>
        /// <param name="textFileMaxChar">The maximum line length in the text file (ShrinkFact &gt;= 80).</param>
        public void GetDimensions(ref double cuttingPlaneTol,
            ref double worldSpacing,
            ref double nudgeValue,
            ref int pixelClickSize,
            ref int pixelSnapSize,
            ref int screenLineThickness,
            ref int printLineThickness,
            ref int maxFont,
            ref int minFont,
            ref int zoomStep,
            ref int shrinkFactor,
            ref int textFileMaxChar)
        {
            _callCode = _sapModel.Options.GetDimensions(ref cuttingPlaneTol, ref worldSpacing, ref nudgeValue, ref pixelClickSize, ref pixelSnapSize, ref screenLineThickness, ref printLineThickness, ref maxFont, ref minFont, ref zoomStep, ref shrinkFactor, ref textFileMaxChar);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function sets program dimension and tolerance items. 
        /// Inputting 0 for any item means that the item will be ignored by the program; that is, its current value will not be changed.
        /// </summary>
        /// <param name="cuttingPlaneTol">The tolerance for 2D view cutting planes. [L]</param>
        /// <param name="worldSpacing">The plan fine grid spacing. [L]</param>
        /// <param name="nudgeValue">The plan nudge value. [L]</param>
        /// <param name="pixelClickSize">The screen selection tolerance in pixels.</param>
        /// <param name="pixelSnapSize">The screen snap tolerance in pixels.</param>
        /// <param name="screenLineThickness">The screen line thickness in pixels.</param>
        /// <param name="printLineThickness">The printer line thickness in pixels.</param>
        /// <param name="maxFont">The maximum graphic font size in points.</param>
        /// <param name="minFont">The minimum graphic font size in points.</param>
        /// <param name="zoomStep">The auto zoom step size in percent (0 &lt; ZoomStep &lt;= 100).</param>
        /// <param name="shrinkFactor">The shrink factor in percent (0 &lt; ShrinkFact &lt;= 100).</param>
        /// <param name="textFileMaxChar">The maximum line length in the text file (ShrinkFact &gt;= 80).</param>
        public void SetDimensions(double cuttingPlaneTol,
            double worldSpacing,
            double nudgeValue,
            int pixelClickSize,
            int pixelSnapSize,
            int screenLineThickness,
            int printLineThickness,
            int maxFont,
            int minFont,
            int zoomStep,
            int shrinkFactor,
            int textFileMaxChar)
        {
            _callCode = _sapModel.Options.SetDimensions(cuttingPlaneTol, worldSpacing, nudgeValue, pixelClickSize, pixelSnapSize, screenLineThickness, printLineThickness, maxFont, minFont, zoomStep, shrinkFactor, textFileMaxChar);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        #endregion
    }
}
