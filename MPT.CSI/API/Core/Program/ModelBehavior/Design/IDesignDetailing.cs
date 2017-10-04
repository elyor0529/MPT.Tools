#if BUILD_ETABS2015 || BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Design
{
    /// <summary>
    /// Implements a design detailing interface for all concrete-based frame elements.
    /// </summary>
    public interface IDesignDetailing : IDesignRun
    {
        /// <summary>
        /// Starts the frame design.
        /// </summary>
        /// <param name="overwriteExisting">True: Any existing detailing will be overwritten.</param>
        void StartDesign(bool overwriteExisting);

        //GetBeamLongRebarData
        //GetBeamTieRebarData

        //GetColumnLongRebarData
        //GetColumnTieRebarData

        //GetDetailedBeamLineData
        //GetDetailedBeamLines

        //GetDetailedColumnStackData
        //GetDetailedColumnStacks

        //GetDetailedSlabBotBarData
        //GetDetailedSlabBotBarData_1

        //GetDetailedSlabs
        //GetDetailedSlabTopBarData
        //GetDetailedSlabTopBarData_1

        //GetSimilarBeamLines
        //GetSimilarColumnStacks
        //GetSimilarSlabs
    }
}
#endif