namespace MPT.CSI.API.Core.Program.ModelBehavior.Design.CodesDesign.Concrete
{
    #if !BUILD_CSiBridgev18 && !BUILD_CSiBridgev19
    /// <summary>
    /// Overwrites available for <see cref="BS_8110_97"/> concrete design in the application.
    /// </summary>
    public enum eOverwrites_BS_8110_97
    {
        /// <summary>
        /// Framing type.
        /// </summary>
        FramingType = 1,

        /// <summary>
        /// The live load reduction factor.
        /// </summary>
        LiveLoadReductionFactor = 2,

        /// <summary>
        /// The unbraced length ratio, major.
        /// </summary>
        UnbracedLengthRatio_Major = 3,

        /// <summary>
        /// The unbraced length ratio, minor.
        /// </summary>
        UnbracedLengthRatio_Minor = 4,

        /// <summary>
        /// The effective length factor, beta major.
        /// </summary>
        EffectiveLengthFactor_Beta_Major = 5,

        /// <summary>
        /// The effective length factor, beta minor.
        /// </summary>
        EffectiveLengthFactor_Beta_Minor = 6,

        /// <summary>
        /// The moment coefficient, Cm major.
        /// </summary>
        MomentCoefficient_Cm_Major = 7,

        /// <summary>
        /// The moment coefficient, Cm minor.
        /// </summary>
        MomentCoefficient_Cm_Minor = 8,

        /// <summary>
        /// The non-sway moment factor, Dns major.
        /// </summary>
        NonswayMomentFactor_Dns_Major = 9,

        /// <summary>
        /// The non-sway moment factor, Dns minor.
        /// </summary>
        NonswayMomentFactor_Dns_Minor = 10,

        /// <summary>
        /// The sway moment factor, Ds major.
        /// </summary>
        SwayMomentFactor_Ds_Major = 11,

        /// <summary>
        /// The sway moment factor, Ds minor.
        /// </summary>
        SwayMomentFactor_Ds_Minor = 12,
    }
  #endif
}
