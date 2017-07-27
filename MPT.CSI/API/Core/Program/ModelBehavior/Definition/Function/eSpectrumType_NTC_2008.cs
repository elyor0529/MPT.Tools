namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Function
{
    /// <summary>
    /// The spectrum type for NTC 2008 response spectrum.
    /// </summary>
    public enum eSpectrumType_NTC_2008
    {
        /// <summary>
        /// Elastic horizontal spectrum type.
        /// </summary>
        ElasticHorizontal = 1,
        
        /// <summary>
        /// Elastic vertical spectrum type.
        /// </summary>
        ElasticVertical = 2,
        
        /// <summary>
        /// Design horizontal spectrum type.
        /// </summary>
        DesignHorizontal = 3,
        
        /// <summary>
        /// Design vertical spectrum type.
        /// </summary>
        DesignVertical = 4,
    }
}