using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// Represents groups in the application.
    /// </summary>
    public class Groups : CSiApiBase, IChangeableName, ICountable, IDeletable, IListableNames
    {
#else
    /// <summary>
    /// Represents groups in the application.
    /// </summary>
    public class Groups : CSiApiBase, ICountable, IDeletable, IListableNames
    {
#endif
        #region Fields
        public const string All = "ALL";

        #endregion


        #region Initialization


        public Groups(CSiApiSeed seed) : base(seed) {}


        #endregion

        #region Methods: Public
        /// <summary>
        /// Return the number of defined groups.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.GroupDef.Count();
        }

        /// <summary>
        /// Retrieves the names of all defined groups.
        /// </summary>
        /// <param name="numberGroupNames">Number of group names retrieved by the program.</param>
        /// <param name="groupNames">Names of all defined groups.</param>
        public void GetNameList(ref int numberGroupNames,
            ref string[] groupNames)
        {
            _callCode = _sapModel.GroupDef.GetNameList(ref numberGroupNames, ref groupNames);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Deletes the specified group.
        /// "ALL" is a reserved group name and cannot be deleted.
        /// </summary>
        /// <param name="nameGroup">Name of an existing group. Cannot be "ALL".</param>
        public void Delete(string nameGroup)
        {
            if (keywordIsReserved(nameGroup))
            {
                throw new CSiReservedNameException("Cannot delete reserved group name " + All);
            }

            _callCode = _sapModel.GroupDef.Delete(nameGroup);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        /// <summary>
        /// Changes the name of the group. 
        /// "ALL" is a reserved group name and cannot be changed.
        /// </summary>
        /// <param name="nameExisting">Existing name of a defined group.</param>
        /// <param name="nameNew">New name for the group. Cannot be "ALL".</param>
        public void ChangeName(string nameExisting,
            string nameNew)
        {
            if (keywordIsReserved(nameExisting))
            {
                throw new CSiReservedNameException("Cannot change reserved group name " + Groups.All);
            }
            if (keywordIsReserved(nameNew))
            {
                throw new CSiReservedNameException("Cannot change group name " + nameNew + " to reserved group name " + Groups.All);
            }

            _callCode = _sapModel.GroupDef.ChangeName(nameExisting, nameNew);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Function clears (removes) all assignments from the specified group.
        /// </summary>
        /// <param name="nameGroup">Name of an existing group.</param>
        public void Clear(string nameGroup)
        {
            _callCode = _sapModel.GroupDef.Clear(nameGroup);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
#endif
        
        /// <summary>
        /// Retrieves the assignments to a specified group.
        /// </summary>
        /// <param name="nameGroup">Name of an existing group to get the assignments for.</param>
        /// <param name="numberOfAssignmentsToGroup">Number of assignments made to the specified group.</param>
        /// <param name="objectType">Object type of each item in the group correpsonding to an integer code.</param>
        /// <param name="objectNames">Name of each item in the group.</param>
        public void GetAssignments(string nameGroup,
            ref int numberOfAssignmentsToGroup,
            ref int[] objectType,
            ref string[] objectNames)
        {
            _callCode = _sapModel.GroupDef.GetAssignments(nameGroup, ref numberOfAssignmentsToGroup, ref objectType, ref objectNames);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        

        /// <summary>
        /// Gets the group properties, such as display color and usages.
        /// </summary>
        /// <param name="name">Name of an existing group to get the properties for.</param>
        /// <param name="color">Display color for the group specified.</param>
        /// <param name="specifiedForSelection">True: The group is specified to be used for selection.</param>
        /// <param name="specifiedForSectionCutDefinition">True: The group is specified to be used for defining section cuts.</param>
        /// <param name="specifiedForSteelDesign">True: The group is specified to be used for defining steel frame design groups.</param>
        /// <param name="specifiedForConcreteDesign">True: The group is specified to be used for defining concrete frame design groups.</param>
        /// <param name="specifiedForAluminumDesign">True: The group is specified to be used for defining alumnimum frame design groups.</param>
        /// <param name="specifiedForColdFormedDesign">True: The group is specified to be used for defining colf formed frame design groups.</param>
        /// <param name="specifiedForStaticNLActiveStage">True: The group is specified to be used for defining stages for nonlinear static analysis.</param>
        /// <param name="specifiedForBridgeResponseOutput">True: The group is specified to be used for reporting bridge response output.</param>
        /// <param name="specifiedForAutoSeismicOutput">True: The group is specified to be used for reporting auto seismic loads.</param>
        /// <param name="specifiedForAutoWindOutput">True: The group is specified to be used for reporting auto wind loads.</param>
        /// <param name="specifiedForMassAndWeight">True: The group is specified to be used for reporting group masses and weight.</param>
        public void GetGroup(string name,
            ref int color,
            ref bool specifiedForSelection,
            ref bool specifiedForSectionCutDefinition,
            ref bool specifiedForSteelDesign,
            ref bool specifiedForConcreteDesign,
            ref bool specifiedForAluminumDesign,
            ref bool specifiedForColdFormedDesign,
            ref bool specifiedForStaticNLActiveStage,
            ref bool specifiedForBridgeResponseOutput,
            ref bool specifiedForAutoSeismicOutput,
            ref bool specifiedForAutoWindOutput,
            ref bool specifiedForMassAndWeight)
        {
            _callCode = _sapModel.GroupDef.GetGroup(name,
                ref color,
                ref specifiedForSelection,
                ref specifiedForSectionCutDefinition,
                ref specifiedForSteelDesign,
                ref specifiedForConcreteDesign,
                ref specifiedForAluminumDesign,
                ref specifiedForColdFormedDesign,
                ref specifiedForStaticNLActiveStage,
                ref specifiedForBridgeResponseOutput,
                ref specifiedForAutoSeismicOutput,
                ref specifiedForAutoWindOutput,
                ref specifiedForMassAndWeight);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Sets group properties, such as display color and usages.
        /// </summary>
        /// <param name="name">This is the name of a group.  
        /// If this is the name of an existing group,  that group is modified, otherwise a new group is added.</param>
        /// <param name="color">Display color for the group specified.
        /// If this value is input as –1, the program automatically selects a display color for the group.</param>
        /// <param name="specifiedForSelection">True: The group is specified to be used for selection.</param>
        /// <param name="specifiedForSectionCutDefinition">True: The group is specified to be used for defining section cuts.</param>
        /// <param name="specifiedForSteelDesign">True: The group is specified to be used for defining steel frame design groups.</param>
        /// <param name="specifiedForConcreteDesign">True: The group is specified to be used for defining concrete frame design groups.</param>
        /// <param name="specifiedForAluminumDesign">True: The group is specified to be used for defining alumnimum frame design groups.</param>
        /// <param name="specifiedForColdFormedDesign">True: The group is specified to be used for defining colf formed frame design groups.</param>
        /// <param name="specifiedForStaticNLActiveStage">True: The group is specified to be used for defining stages for nonlinear static analysis.</param>
        /// <param name="specifiedForBridgeResponseOutput">True: The group is specified to be used for reporting bridge response output.</param>
        /// <param name="specifiedForAutoSeismicOutput">True: The group is specified to be used for reporting auto seismic loads.</param>
        /// <param name="specifiedForAutoWindOutput">True: The group is specified to be used for reporting auto wind loads.</param>
        /// <param name="specifiedForMassAndWeight">True: The group is specified to be used for reporting group masses and weight.</param>
        public void SetGroup(string name,
            int color = -1,
            bool specifiedForSelection = true,
            bool specifiedForSectionCutDefinition = true,
            bool specifiedForSteelDesign = true,
            bool specifiedForConcreteDesign = true,
            bool specifiedForAluminumDesign = true,
            bool specifiedForColdFormedDesign = true,
            bool specifiedForStaticNLActiveStage = true,
            bool specifiedForBridgeResponseOutput = true,
            bool specifiedForAutoSeismicOutput = true,
            bool specifiedForAutoWindOutput = true,
            bool specifiedForMassAndWeight = true)
        {
            _callCode = _sapModel.GroupDef.SetGroup(name,
                color,
                specifiedForSelection,
                specifiedForSectionCutDefinition,
                specifiedForSteelDesign,
                specifiedForConcreteDesign,
                specifiedForAluminumDesign,
                specifiedForColdFormedDesign,
                specifiedForStaticNLActiveStage,
                specifiedForBridgeResponseOutput,
                specifiedForAutoSeismicOutput,
                specifiedForAutoWindOutput,
                specifiedForMassAndWeight);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

#if BUILD_ETABS2015 || BUILD_ETABS2016
        /// <summary>
        /// Gets the group properties, such as display color and usages.
        /// </summary>
        /// <param name="name">Name of an existing group to get the properties for.</param>
        /// <param name="color">Display color for the group specified.</param>
        /// <param name="specifiedForSelection">True: The group is specified to be used for selection.</param>
        /// <param name="specifiedForSectionCutDefinition">True: The group is specified to be used for defining section cuts.</param>
        /// <param name="specifiedForSteelDesign">True: The group is specified to be used for defining steel frame design groups.</param>
        /// <param name="specifiedForConcreteDesign">True: The group is specified to be used for defining concrete frame design groups.</param>
        /// <param name="specifiedForStaticNLActiveStage">True: The group is specified to be used for defining stages for nonlinear static analysis.</param>
        /// <param name="specifiedForAutoSeismicOutput">True: The group is specified to be used for reporting auto seismic loads.</param>
        /// <param name="specifiedForAutoWindOutput">True: The group is specified to be used for reporting auto wind loads.</param>
        /// <param name="specifiedForMassAndWeight">True: The group is specified to be used for reporting group masses and weight.</param>
        /// <param name="specifiedForSteelJoistDesign">True: The group is specified to be used for defining steel joist design groups.</param>
        /// <param name="specifiedForWallDesign">True: The group is specified to be used for defining wall design groups.</param>
        /// <param name="specifiedForBasePlateDesign">True: The group is specified to be used for defining base plate design groups.</param>
        /// <param name="specifiedForConnectionDesign">True: The group is specified to be used for defining connection design design groups.</param>
        public void GetGroup(string name,
            ref int color,
            ref bool specifiedForSelection,
            ref bool specifiedForSectionCutDefinition,
            ref bool specifiedForSteelDesign,
            ref bool specifiedForConcreteDesign,
            ref bool specifiedForStaticNLActiveStage,
            ref bool specifiedForAutoSeismicOutput,
            ref bool specifiedForAutoWindOutput,
            ref bool specifiedForMassAndWeight,
            ref bool specifiedForSteelJoistDesign,
            ref bool specifiedForWallDesign,
            ref bool specifiedForBasePlateDesign,
            ref bool specifiedForConnectionDesign)
        {
            bool specifiedForAluminumDesign = false;
            _callCode = _sapModel.GroupDef.GetGroup_1(name,
                ref color,
                ref specifiedForSelection,
                ref specifiedForSectionCutDefinition,
                ref specifiedForSteelDesign,
                ref specifiedForConcreteDesign,
                ref specifiedForAluminumDesign,
                ref specifiedForStaticNLActiveStage,
                ref specifiedForAutoSeismicOutput,
                ref specifiedForAutoWindOutput,
                ref specifiedForMassAndWeight,
                ref specifiedForSteelJoistDesign,
                ref specifiedForWallDesign,
                ref specifiedForBasePlateDesign,
                ref specifiedForConnectionDesign);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Sets group properties, such as display color and usages.
        /// </summary>
        /// <param name="name">This is the name of a group.  
        /// If this is the name of an existing group,  that group is modified, otherwise a new group is added.</param>
        /// <param name="color">Display color for the group specified.
        /// If this value is input as –1, the program automatically selects a display color for the group.</param>
        /// <param name="specifiedForSelection">True: The group is specified to be used for selection.</param>
        /// <param name="specifiedForSectionCutDefinition">True: The group is specified to be used for defining section cuts.</param>
        /// <param name="specifiedForSteelDesign">True: The group is specified to be used for defining steel frame design groups.</param>
        /// <param name="specifiedForConcreteDesign">True: The group is specified to be used for defining concrete frame design groups.</param>
        /// <param name="specifiedForStaticNLActiveStage">True: The group is specified to be used for defining stages for nonlinear static analysis.</param>
        /// <param name="specifiedForAutoSeismicOutput">True: The group is specified to be used for reporting auto seismic loads.</param>
        /// <param name="specifiedForAutoWindOutput">True: The group is specified to be used for reporting auto wind loads.</param>
        /// <param name="specifiedForMassAndWeight">True: The group is specified to be used for reporting group masses and weight.</param>
        /// <param name="specifiedForSteelJoistDesign">True: The group is specified to be used for defining steel joist design groups.</param>
        /// <param name="specifiedForWallDesign">True: The group is specified to be used for defining wall design groups.</param>
        /// <param name="specifiedForBasePlateDesign">True: The group is specified to be used for defining base plate design groups.</param>
        /// <param name="specifiedForConnectionDesign">True: The group is specified to be used for defining connection design design groups.</param>
        public void SetGroup(string name,
            int color = -1,
            bool specifiedForSelection = true,
            bool specifiedForSectionCutDefinition = true,
            bool specifiedForSteelDesign = true,
            bool specifiedForConcreteDesign = true,
            bool specifiedForStaticNLActiveStage = true,
            bool specifiedForAutoSeismicOutput = true,
            bool specifiedForAutoWindOutput = true,
            bool specifiedForMassAndWeight = true,
            bool specifiedForSteelJoistDesign = true,
            bool specifiedForWallDesign = true,
            bool specifiedForBasePlateDesign = true,
            bool specifiedForConnectionDesign = true)
        {
            bool specifiedForAluminumDesign = true;
            _callCode = _sapModel.GroupDef.SetGroup_1(name,
                color,
                specifiedForSelection,
                specifiedForSectionCutDefinition,
                specifiedForSteelDesign,
                specifiedForConcreteDesign,
                specifiedForAluminumDesign,
                specifiedForStaticNLActiveStage,
                specifiedForAutoSeismicOutput,
                specifiedForAutoWindOutput,
                specifiedForMassAndWeight,
                specifiedForSteelJoistDesign,
                specifiedForWallDesign,
                specifiedForBasePlateDesign,
                specifiedForConnectionDesign);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
#endif
        #endregion

        #region Methods: Private

        /// <summary>
        /// Determines if the provided keyword is a reserved keyword.
        /// </summary>
        /// <param name="parameter">Keyword to check.</param>
        /// <returns></returns>
        private bool keywordIsReserved(string parameter)
        {
            return parameter.CompareTo(All) == 0;
        }

        #endregion
    }
}
