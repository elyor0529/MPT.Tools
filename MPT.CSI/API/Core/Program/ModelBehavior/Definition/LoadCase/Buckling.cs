using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Represents the buckling load case in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class Buckling : CSiApiBase, IBuckling
    {
        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="Buckling"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public Buckling(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Interface
        /// <summary>
        /// This function initializes a load case. 
        /// If this function is called for an existing load case, all items for the case are reset to their default value.
        /// </summary>
        /// <param name="name">The name of an existing or new load case. 
        /// If this is an existing case, that case is modified; otherwise, a new case is added.</param>
        /// <exception cref="CSiException"></exception>
        public void SetCase(string name)
        {
            _callCode = _sapModel.LoadCases.Buckling.SetCase(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        /// <summary>
        /// This function retrieves the initial condition assumed for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="initialCase">This is blank, None, or the name of an existing analysis case. 
        /// This item specifies if the load case starts from zero initial conditions, that is, an unstressed state, or if it starts using the stiffness that occurs at the end of a nonlinear static or nonlinear direct integration time history load case.
        /// If the specified initial case is a nonlinear static or nonlinear direct integration time history load case, the stiffness at the end of that case is used.
        /// If the initial case is anything else then zero initial conditions are assumed.</param>
        /// <exception cref="CSiException"></exception>
        public void GetInitialCase(string name, 
            ref string initialCase)
        {
            _callCode = _sapModel.LoadCases.Buckling.GetInitialCase(name, ref initialCase);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        /// <summary>
        /// This function sets the initial condition for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="initialCase">This is blank, None, or the name of an existing analysis case. 
        /// This item specifies if the load case starts from zero initial conditions, that is, an unstressed state, or if it starts using the stiffness that occurs at the end of a nonlinear static or nonlinear direct integration time history load case.
        /// If the specified initial case is a nonlinear static or nonlinear direct integration time history load case, the stiffness at the end of that case is used.
        /// If the initial case is anything else then zero initial conditions are assumed.</param>
        /// <exception cref="CSiException"></exception>
        public void SetInitialCase(string name, 
            string initialCase)
        {
            _callCode = _sapModel.LoadCases.Buckling.SetInitialCase(name, initialCase);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion

        #region Methods: Public        
        /// <summary>
        /// This function retrieves various parameters for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing buckling load case.</param>
        /// <param name="numberOfBucklingModes">The number of buckling modes requested.</param>
        /// <param name="eigenvalueConvergenceTolerance">The relative convergence tolerance for eigenvalues.</param>
        /// <exception cref="CSiException"></exception>
        public void GetParameters(string name,
            ref int numberOfBucklingModes,
            ref double eigenvalueConvergenceTolerance)
        {
            _callCode = _sapModel.LoadCases.Buckling.GetParameters(name, ref numberOfBucklingModes, ref eigenvalueConvergenceTolerance);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        /// <summary>
        /// This function sets various parameters for the specified buckling load case.
        /// </summary>
        /// <param name="name">The name of an existing buckling load case.</param>
        /// <param name="numberOfBucklingModes">The number of buckling modes requested.</param>
        /// <param name="eigenvalueConvergenceTolerance">The relative convergence tolerance for eigenvalues.</param>
        /// <exception cref="CSiException"></exception>
        public void SetParameters(string name,
            int numberOfBucklingModes,
            double eigenvalueConvergenceTolerance)
        {
            _callCode = _sapModel.LoadCases.Buckling.SetParameters(name, numberOfBucklingModes, eigenvalueConvergenceTolerance);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion  
    }
}
