#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.CodesAutoLoad.Seismic
{
    /// <summary>
    /// Country for which the Nationally Determined Parameters (NDPs) are specified. 
    /// Used by Eurocode.
    /// </summary>
    public enum eCountry
    {
        /// <summary>
        /// Other (NDPs are user specified).
        /// </summary>
        Other = 0,

        /// <summary>
        /// CEN Default.
        /// </summary>
        CENDefault = 1,

        /// <summary>
        /// Norway.
        /// </summary>
        Norway = 5,

        /// <summary>
        /// Portugal.
        /// </summary>
        Portugal = 10
    }
}
#endif
