namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Stress-strain curve types available for concrete in the application.
    /// </summary>
    public enum eConcreteStressStrainCurveType
    {
        /// <summary>
        /// User defined.
        /// </summary>
        UserDefined = 0,

        /// <summary>
        /// Parametric – Simple.
        /// </summary>
        ParametricSimple = 1,

        /// <summary>
        /// Parametric – Mander.
        /// </summary>
        ParametricMander = 2
    }
}