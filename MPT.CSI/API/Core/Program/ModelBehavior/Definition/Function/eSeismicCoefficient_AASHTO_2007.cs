namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Function
{
    /// <summary>
    /// Seismic coefficient for AASHTO 2007 response spectrum function.
    /// </summary>
    public enum eSeismicCoefficient_AASHTO_2007
    {
        /// <summary>
        /// Ss and S1 are from USGS by latitiude and longitude.
        /// </summary>
        SsAndS1FromUSGSLatLong = 0,

        /// <summary>
        /// Ss and S1 are from USGS by zip code.
        /// </summary>
        SsAndS1FromUSGSZipCode = 1,

        /// <summary>
        /// Ss and S1 are user defined.
        /// </summary>
        SsAndS1UserDefined = 2
    }
}