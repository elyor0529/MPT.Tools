#if !BUILD_ETABS2015 && !BUILD_ETABS2016
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.CodesAutoLoad.Seismic
{
    /// <summary>
    /// Represents the IBC_2003 auto seismic load in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class IBC_2003 : CSiApiBase
    {

#region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="IBC_2003"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public IBC_2003(CSiApiSeed seed) : base(seed) { }


#endregion

#region Methods: Public

        public void GetThing(ref string param)
        {
            //_callCode = _sapModel.
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetThing(string param)
        {
            //_callCode = _sapModel.
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

#endregion
    }
}
#endif
