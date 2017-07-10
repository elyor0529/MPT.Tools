using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property.TimeDependent.CodesConcrete
{
    /// <summary>
    /// Represents the CEB FIP 90 method for time dependent cocnrete behavior.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class CEB_FIP_90 : CSiApiBase
    {
        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="CEB_FIP_90"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public CEB_FIP_90(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Public


        public void GetMethod(string nameFrame)
        {
            //_callCode = _sapModel.SapModel.PropMaterial.GetConcreteCEBFIP90();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetMethod(string nameFrame, eItemType itemType = eItemType.Object)
        {
            //_callCode = _sapModel.SapModel.PropMaterial.SetConcreteCEBFIP90();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
