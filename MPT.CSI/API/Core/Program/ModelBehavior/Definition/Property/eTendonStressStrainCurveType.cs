namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Stress-strain curve types available for tendons in the application.
    /// </summary>
    public enum eTendonStressStrainCurveType
    {
        /// <summary>
        /// User defined.
        /// </summary>
        UserDefined = 0,

        /// <summary>
        /// Parametric – 250 ksi strand.
        /// </summary>
        Parametric250ksiStrand = 1,

        /// <summary>
        /// Parametric – 270 ksi strand.
        /// </summary>
        Parametric270ksiStrand = 2
    }
}