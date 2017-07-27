namespace MPT.CSI.API.Core.Program.ModelBehavior.Design.CodesDesign.Concrete
{
    #if !BUILD_CSiBridgev18 && !BUILD_CSiBridgev19
    /// <summary>
    /// Preferences available for <see cref="BS_8110_97"/> concrete design in the application.
    /// </summary>
    public enum ePreferences_BS_8110_97
    {
        /// <summary>
        /// The number of interaction curves.
        /// </summary>
        NumberOfInteractionCurves = 1,

        /// <summary>
        /// The number of interaction points.
        /// </summary>
        NumberOfInteractionPoints = 2,

        /// <summary>
        /// Consider minimum eccentricity.
        /// </summary>
        ConsiderMinimumEccentricity = 3,

        /// <summary>
        /// The steel gamma.
        /// </summary>
        SteelGamma = 4,

        /// <summary>
        /// The concrete gamma.
        /// </summary>
        ConcreteGamma = 5,

        /// <summary>
        /// The concrete shear gamma.
        /// </summary>
        ConcreteShearGamma = 6,

        /// <summary>
        /// The pattern live load factor.
        /// </summary>
        PatternLiveLoadFactor = 7,

        /// <summary>
        /// The utilization factor limit.
        /// </summary>
        UtilizationFactorLimit = 8,

        /// <summary>
        /// The multi-response case design.
        /// </summary>
        MultiResponseCaseDesign = 9
    }
#endif
}
