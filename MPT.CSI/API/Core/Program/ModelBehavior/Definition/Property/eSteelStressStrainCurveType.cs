namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Stress-strain curve types available for steel in the application.
    /// </summary>
    public enum eSteelStressStrainCurveType
    {
        /// <summary>
        /// User defined.
        /// </summary>
        UserDefined = 0,

        /// <summary>
        /// Parametric – Simple.
        /// </summary>
        ParametricSimple = 1,
    }
}