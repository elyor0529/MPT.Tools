#if !BUILD_ETABS2015 && !BUILD_ETABS2016
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.CodesAutoLoad.Wave
{
    /// <summary>
    /// Represents a generic auto wave load in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class WaveLoadGeneric : CSiApiBase
    {

#region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="WaveLoadGeneric"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public WaveLoadGeneric(CSiApiSeed seed) : base(seed)
        {
        }


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
