namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Function
{
    /// <summary>
    /// Indicates the country for which the Nationally Determined Parameters (NDPs) are specified for Eurocode 8 2004 response spectrum.
    /// </summary>
    public enum eParameters_Eurocode_8_2004
    {
        /// <summary>
        /// Other (NDPs) are specified.
        /// </summary>
        Other = 0,
        
        /// <summary>
        /// CEN NDP defaults.
        /// </summary>
        CENDefault = 1,
        
        /// <summary>
        /// Norway NDPs.
        /// </summary>
        Norway = 2,
        
        /// <summary>
        /// Portugal NPDs.
        /// </summary>
        Portugal = 3,
    }
}