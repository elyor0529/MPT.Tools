﻿namespace MPT.CSI.API.Core.Program.ModelBehavior.Design.CodesDesign.Concrete
{
    #if !BUILD_CSiBridgev18 && !BUILD_CSiBridgev19
    /// <summary>
    /// Preferences available for <see cref="KCI_1999"/> concrete design in the application.
    /// </summary>
    public enum ePreferences_KCI_1999
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
        /// Phi bending, with tension.
        /// </summary>
        PhiBendingTension = 4,

        /// <summary>
        /// Phi compression-controlled tied.
        /// </summary>
        PhiCompressionControlledTied = 5,

        /// <summary>
        /// Phi compression-controlled spiral.
        /// </summary>
        PhiCompressionControlledSpiral = 6,

        /// <summary>
        /// Phi shearn.
        /// </summary>
        PhiShear = 7,
                
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