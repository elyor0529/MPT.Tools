using System.Linq;
using IO = System.IO;

using MPT.CSI.API.Core.Helpers;
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


#elif BUILD_ETABS2015
using ETABS2015;
#elif BUILD_ETABS2016
using ETABS2016;
#endif

namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Represents the analysis controls in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class Analyzer : CSiApiBase
    {
        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Analyzer"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public Analyzer(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Public
        /// <summary>
        /// Creates the analysis model. 
        /// If the analysis model is already created and current, nothing is done.
        /// It is not necessary to call this function before running an analysis. 
        /// The analysis model is automatically created, if necessary, when the model is run.
        /// </summary>
        public void CreateAnalysisModel()
        {
            _callCode = _sapModel.Analyze.CreateAnalysisModel();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Runs the analysis. 
        /// The analysis model is automatically created as part of this function.
        /// </summary>
        /// <param name="filePath">Path to the model file.</param>
        public bool RunAnalysis(string filePath)
        {
            if (!IO.File.Exists(filePath)) return false;
            // TODO: Why is this here? Check if necessary.

            // run model (this will create the analysis model)
            _callCode = _sapModel.Analyze.RunAnalysis();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            return true;
        }

        /// <summary>
        /// Deletes results for the specified load case.
        /// </summary>
        /// <param name="nameLoadCase">The name of an existing load case that is to have its results deleted.
        /// This item is ignored when the 'All' item is 'True'.</param>
        /// <param name="deleteAll">True: Results are deleted for all load cases, and the Name item is ignored.</param>
        public void DeleteResults(string nameLoadCase,
            bool deleteAll = false)
        {
            _callCode = _sapModel.Analyze.DeleteResults(nameLoadCase, deleteAll);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Modifies the undeformed geometry based on displacements obtained from a specified load case.
        /// </summary>
        /// <param name="caseName">The name of the static load case from which displacements are obtained.</param>
        /// <param name="scaleFactor">The scale factor applied to the displacements.</param>
        /// <param name="stageOfStageConstruction">This item applies only when the specified load case is a staged construction load case. 
        /// It is the stage number from which the displacements are obtained.
        /// Specifying a -1 for this item means to use the last run stage.</param>
        /// <param name="resetToOriginal">True: All other input items in this function are ignored and the original undeformed geometry data is reinstated.</param>
        public void ModifyUnDeformedGeometry(string caseName,
            double scaleFactor,
            int stageOfStageConstruction = -1,
            bool resetToOriginal = false)
        {
            _callCode = _sapModel.Analyze.ModifyUndeformedGeometry(caseName, scaleFactor, stageOfStageConstruction, resetToOriginal);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function modifies the undeformed geometry based on the shape of a specified mode from a specified modal or buckling load case.
        /// </summary>
        /// <param name="caseName">The name of a modal or buckling load case.</param>
        /// <param name="mode">The mode shape to consider.</param>
        /// <param name="maxDisplacement">The maximum displacement to which the mode shape will be scaled.</param>
        /// <param name="direction">The direction in which to apply the geometry modification.</param>
        /// <param name="resetToOriginal">True: All other input items in this function are ignored and the original undeformed geometry data is reinstated.</param>
        public void ModifyUndeformedGeometryModeShape(string caseName,
            int mode,
            double maxDisplacement,
            int direction,
            bool resetToOriginal = false)
        {
            _callCode = _sapModel.Analyze.ModifyUndeformedGeometryModeShape(caseName, mode, maxDisplacement, direction, resetToOriginal);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // === Get ===

        /// <summary>
        /// Retrieves the status for all load cases.
        /// </summary>
        /// <param name="numberOfCases">The number of load cases for which the status is reported.</param>
        /// <param name="caseName">This is an array that includes the name of each analysis case for which the status is reported.</param>
        /// <param name="caseStatus">This is an array of that includes 1, 2, 3 or 4, indicating the load case status.</param>
        public void GetCaseStatus(ref int numberOfCases,
            ref string[] caseName,
            ref eCaseStatus[] caseStatus)
        {
            int[] csiCaseStatus = new int[0];

            _callCode = _sapModel.Analyze.GetCaseStatus(ref numberOfCases, ref caseName, ref csiCaseStatus);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            caseStatus = csiCaseStatus.Cast< eCaseStatus>().ToArray();
        }

        // === Get/Set ===


        /// <summary>
        /// Retrieves the model global degrees of freedom.
        /// </summary>
        /// <param name="activeDOFs">Boolean indications of which degrees of freedom are active.</param>
        public void GetActiveDOF(ref DegreesOfFreedomGlobal activeDOFs)
        {
            bool[] dofArray = new bool[0];

            _callCode = _sapModel.Analyze.GetActiveDOF(ref dofArray);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            activeDOFs.FromArray(dofArray);
        }

        /// <summary>
        /// Sets the model global degrees of freedom.
        /// </summary>
        /// <param name="activeDOFs">Boolean indications of which degrees of freedom are active.</param>
        public void SetActiveDOF(DegreesOfFreedomGlobal activeDOFs)
        {
            bool[] dofArray = activeDOFs.ToArray();

            _callCode = _sapModel.Analyze.SetActiveDOF(ref dofArray);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Retrieves the model solver options.
        /// </summary>
        /// <param name="solverType">Solver type used for the analysis.</param>
        /// <param name="solverProcessType">Process type used for the analysis.</param>
        /// <param name="force32BitSolver">True: The analysis is always run using 32-bit, even on 64-bit computers.</param>
        /// <param name="stiffCase">The name of the load case used when outputting the mass and stiffness matrices to text files. 
        /// If this item is blank, no matrices are output.</param>
        public void GetSolverOption_1(ref eSolverType solverType,
            ref eSolverProcessType solverProcessType,
            ref bool force32BitSolver,
            ref string stiffCase)
        {
            int csiSolverType = 0;
            int csiSolverProcessType = 0;

            _callCode = _sapModel.Analyze.GetSolverOption_1(ref csiSolverType, ref csiSolverProcessType, ref force32BitSolver, ref stiffCase);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            solverType = (eSolverType)csiSolverType;
            solverProcessType = (eSolverProcessType)csiSolverProcessType;
        }

        /// <summary>
        ///  Sets the model solver options.
        /// </summary>
        /// <param name="solverType">Solver type used for the analysis.</param>
        /// <param name="solverProcessType">Process type used for the analysis.</param>
        /// <param name="force32BitSolver">True: The analysis is always run using 32-bit, even on 64-bit computers.</param>
        /// <param name="stiffCase">The name of the load case used when outputting the mass and stiffness matrices to text files. 
        /// If this item is blank, no matrices are output.</param>
        public void SetSolverOption_1(eSolverType solverType,
            eSolverProcessType solverProcessType,
            bool force32BitSolver,
            string stiffCase = "")
        {
            _callCode = _sapModel.Analyze.SetSolverOption_1((int)solverType, (int)solverProcessType, force32BitSolver, stiffCase);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        /// <summary>
        /// Retrieves the run flags for all analysis cases.
        /// </summary>
        /// <param name="numberOfCases">The number of load cases for which the run flag is reported.</param>
        /// <param name="caseName">This is an array that includes the name of each analysis case for which the run flag is reported.</param>
        /// <param name="caseSetToRun">This is an array of boolean values indicating if the specified load case is to be run.</param>
        public void GetRunCaseFlag(ref int numberOfCases,
            ref string[] caseName,
            ref bool[] caseSetToRun)
        {
            _callCode = _sapModel.Analyze.GetRunCaseFlag(ref numberOfCases, ref caseName, ref caseSetToRun);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Sets the run flag for all of the existing load cases.
        /// </summary>
        /// <param name="caseName">The name of an existing load case that is to have its flag set.</param>
        /// <param name="caseSetToRun">>True: The specified load case is to be run.</param>
        /// <param name="applyToAll">True: The run flag is set as specified by the Run item for all load cases, and the Name item is ignored.</param>
        public void SetRunCaseFlag(string caseName,
            bool caseSetToRun,
            bool applyToAll = false)
        {
            _callCode = _sapModel.Analyze.SetRunCaseFlag(caseName, caseSetToRun, applyToAll);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion
    }
}
