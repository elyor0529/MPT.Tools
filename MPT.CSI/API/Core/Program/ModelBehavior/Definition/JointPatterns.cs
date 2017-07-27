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

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Represents the joint patterns in the application.
    /// </summary>
    public class JointPatterns : CSiApiBase, IChangeableName, ICountable, IDeletable, IListableNames
    {
        #region Initialization

        public JointPatterns(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Public

        /// <summary>
        /// Renames the specified joint pattern.
        /// </summary>
        /// <param name="nameJointPattern">The existing name of a defined joint pattern.</param>
        /// <param name="newName">The new name for the joint pattern.</param>
        public void ChangeName(string nameJointPattern,
            string newName)
        {
            // TODO: Determine what happens to renaming a nonexisting pattern.

            _callCode = _sapModel.PatternDef.ChangeName(nameJointPattern, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// The function returns the number of defined joint patterns.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.PatternDef.Count();
        }

        /// <summary>
        /// The function deletes the specified joint pattern. 
        /// At least one joint pattern must be defined. 
        /// The function will return an error if an attempt is made to delete the last joint pattern.
        /// </summary>
        /// <param name="nameJointPattern">The name of an existing joint pattern.</param>
        public void Delete(string nameJointPattern)
        {
            _callCode = _sapModel.PatternDef.Delete(nameJointPattern);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of all defined joint patterns.
        /// </summary>
        /// <param name="numberNames">The number of joint pattern names retrieved by the program.</param>
        /// <param name="namesJointPatterns">Joint pattern names retrieved by the program.</param>
        public void GetNameList(ref int numberNames,
            ref string[] namesJointPatterns)
        {
            _callCode = _sapModel.PatternDef.GetNameList(ref numberNames, ref namesJointPatterns);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// The function defines a new joint pattern. 
        /// It returns an error if the specified joint pattern name is already in use
        /// </summary>
        /// <param name="nameJointPattern">The name of a new joint pattern.</param>
        public void SetPattern(string nameJointPattern)
        {
            _callCode = _sapModel.PatternDef.SetPattern(nameJointPattern);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
