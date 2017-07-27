namespace MPT.CSI.API.Core.Program.ModelBehavior.Design.CodesDesign.Concrete
{
    #if !BUILD_CSiBridgev18 && !BUILD_CSiBridgev19
    /// <summary>
    /// Preferences available for <see cref="TS_500_2000"/> concrete design in the application.
    /// </summary>
    public enum ePreferences_TS_500_2000
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
        /// The seismic zone.
        /// </summary>
        SeismicZone = 4,
        
        /// <summary>
        /// The steel gamma.
        /// </summary>
        SteelGamma = 5,

        /// <summary>
        /// The concrete gamma.
        /// </summary>
        ConcreteGamma = 6,

        /// <summary>
        /// The concrete shear gamma.
        /// </summary>
        ConcreteShearGamma = 7,

        /// <summary>
        /// The pattern live load factor.
        /// </summary>
        PatternLiveLoadFactor = 8,

        /// <summary>
        /// The utilization factor limit.
        /// </summary>
        UtilizationFactorLimit = 9,

        /// <summary>
        /// The multi-response case design.
        /// </summary>
        MultiResponseCaseDesign = 10
    }
#endif
}
