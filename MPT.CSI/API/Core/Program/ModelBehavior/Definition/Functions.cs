using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Represents the functions in the application.
    /// </summary>
    public class Functions : CSiApiBase, IChangeableName, ICountable, IDeletable, IListableNames
    {
        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="Functions"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public Functions(CSiApiSeed seed) : base(seed) { }

        /// <summary>
        /// This function changes the name of an existing loading function.
        /// </summary>
        /// <param name="currentName">The existing name of a defined loading function.</param>
        /// <param name="newName">The new name for the loading function.</param>
        public void ChangeName(string currentName, string newName)
        {
            _callCode = _sapModel.Func.ChangeName(currentName, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function returns the total number of defined loading functions in the model.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.Func.Count();
        }

        /// <summary>
        /// The function deletes a specified loading function.
        /// It returns an error if the specified loading function can not be deleted; for example, if it is currently used by a staged construction load case.
        /// </summary>
        /// <param name="name">The name of an existing loading function.</param>
        public void Delete(string name)
        {
            _callCode = _sapModel.Func.Delete(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of all defined loading functions.
        /// </summary>
        /// <param name="numberOfNames">The number of loading function names retrieved by the program.</param>
        /// <param name="names">Loading function names retrieved by the program.</param>
        public void GetNameList(ref int numberOfNames, ref string[] names)
        {
            _callCode = _sapModel.Func.GetNameList(ref numberOfNames, ref names);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        #endregion

        #region Methods: Public

        /// <summary>
        /// This function retrieves the function type for the specified function.
        /// </summary>
        /// <param name="name">The name of an existing function.</param>
        /// <param name="functionType">This is the main type of function.</param>
        /// <param name="functionSubType">This is the function subtype, which is dependent upond the function type.
        /// See enumerations for code definitions.</param>
        public void GetType(string name,
            ref eFunctionType functionType,
            ref int functionSubType)
        {
            int csiFunctionType = 0;

            _callCode = _sapModel.Func.GetTypeOAPI(name, ref csiFunctionType, ref functionSubType);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            functionType = (eFunctionType)csiFunctionType;
        }

        /// <summary>
        /// This function retrieves the time and function values for any defined function.
        /// </summary>
        /// <param name="name">The name of an existing function.</param>
        /// <param name="numberItems">The number of time and function value pairs retrieved.</param>
        /// <param name="timeValue">This is an array that includes the time value for each data point. 
        /// [sec] for response spectrum and time history functions, [cyc/sec] for power spectral density and steady state functions</param>
        /// <param name="functionValue">This is an array that includes the function value for each data point.</param>
        public void GetValues(string name,
            ref int numberItems,
            ref double[] timeValue,
            ref double[] functionValue)
        {
            _callCode = _sapModel.Func.GetValues(name, ref numberItems, ref timeValue, ref functionValue);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function converts an existing function to a user defined function. 
        /// An error is returned if the specified function is already a user defined function.
        /// </summary>
        /// <param name="name">The name of an existing function that is not a user defined function.</param>
        public void ConvertToUser(string name)
        {
            // TODO: Handle: An error is returned if the specified function is already a user defined function.
            _callCode = _sapModel.Func.ConvertToUser(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
