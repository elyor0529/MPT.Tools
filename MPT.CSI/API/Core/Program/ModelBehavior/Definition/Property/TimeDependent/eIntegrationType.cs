#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property.TimeDependent
{
    /// <summary>
    /// The integration type used.
    /// </summary>
    public enum eIntegrationType
    {
        /// <summary>
        /// Full integeration.
        /// </summary>
        FullIntegeration = 0,

        /// <summary>
        /// Dirichlet series.
        /// </summary>
        DirichletSeries = 1
    }
}
#endif
