#if !BUILD_ETABS2015 && !BUILD_ETABS2016
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.CodesAutoLoad.Wind
{
    /// <summary>
    /// Represemts the ASCE_7_02 auto wind load in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class ASCE_7_02 : CSiApiBase
    {
#region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="ASCE_7_02"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public ASCE_7_02(CSiApiSeed seed) : base(seed) { }


#endregion

#region Methods: Public

        public void GetThing(ref string param)
        {
            //_callCode = _sapModel.
            if (throwCurrentApiException(_callCode))
            {
                throw new CSiException();
            }
        }


        public void SetThing(string param)
        {
            //_callCode = _sapModel.
            if (throwCurrentApiException(_callCode))
            {
                throw new CSiException();
            }
        }

#endregion
    }
}
#endif
