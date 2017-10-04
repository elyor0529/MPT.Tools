#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Time integration types available in the application.
    /// </summary>
    public enum eTimeIntegrationType
    {
        /// <summary>
        /// The Newmark time integration type.
        /// </summary>
        Newmark = 1,

        /// <summary>
        /// The Wilson time integration type.
        /// </summary>
        Wilson = 2,

        /// <summary>
        /// The Collocation time integration type.
        /// </summary>
        Collocation = 3,

        /// <summary>
        /// The Hilber-Hughes-YTaylor time integration type.
        /// </summary>
        HilberHughesTaylor = 4,

        /// <summary>
        /// The Chung and Hulbert time integration type.
        /// </summary>
        ChungHulbert = 5
    }
}
#endif