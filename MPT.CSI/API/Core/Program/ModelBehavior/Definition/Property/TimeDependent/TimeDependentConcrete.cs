using MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property.TimeDependent.CodesConcrete;
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property.TimeDependent
{
    /// <summary>
    /// Represents time dependent concrete in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class TimeDependentConcrete : CSiApiBase
    {
        #region Fields
        private readonly CSiApiSeed _seed;

        private CEB_FIP_90 _CEB_FIP_90;
        #endregion

        #region Properties                            
        /// <summary>
        /// Gets the CEB FIP 90 method.
        /// </summary>
        /// <value>The CEB FIP 90 method.</value>
        public CEB_FIP_90 CEB_FIP_90 => _CEB_FIP_90 ?? (_CEB_FIP_90 = new CEB_FIP_90(_seed));
        #endregion


        #region Initialization        

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeDependentConcrete"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public TimeDependentConcrete(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }

        #endregion

        #region Methods: Public


        public void GetScaleFactors(string nameFrame)
        {
            //_callCode = _sapModel.SapModel.PropMaterial.TimeDep.GetConcreteScaleFactors();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetScaleFactors(string nameFrame, eItemType itemType = eItemType.Object)
        {
            //_callCode = _sapModel.SapModel.PropMaterial.TimeDep.SetConcreteScaleFactors();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
