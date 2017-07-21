using MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property.TimeDependent.CodesTendon;
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property.TimeDependent
{
    /// <summary>
    /// Represents time dependent tendon material in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class TimeDependentTendon : CSiApiBase
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
        /// Initializes a new instance of the <see cref="TimeDependentTendon"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public TimeDependentTendon(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }

        #endregion

        #region Methods: Public

        /// <summary>
        /// This function retrieves the scale factors for the time-dependent material property data for tendon materials.
        /// The function returns an error if the specified material is not tendon.
        /// TODO: Handle this.
        /// </summary>
        /// <param name="name">The name of an existing tendon material property.</param>
        /// <param name="scaleFactorRelaxation">This value multiplies the relaxation coefficient, and hence the relaxation strain, computed for the material during a time-dependent analysis. 
        /// It has no effect for load cases that do not consider time-dependent effects, or for materials that do not consider relaxation effects. 
        /// The default value is unity, and the specified value must be positive.</param>
        /// <param name="temperature">This item is the temperature at which the specified data is to be retrieved. 
        /// The temperature must have been previously defined for the material.
        /// This item applies only if the specified material has properties that are temperature dependent. 
        /// That is, it applies only if properties are specified for the material at more than one temperature.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void GetScaleFactors(string name,
            ref double scaleFactorRelaxation,
            double temperature = 0)
        {
            _callCode = _sapModel.PropMaterial.TimeDep.GetTendonScaleFactors(name, ref scaleFactorRelaxation, temperature);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function sets scale factors for the time-dependent material property data for tendon materials. 
        /// If this function is not called, default values of unity are assumed for all scale factors.
        /// </summary>
        /// <param name="name">The name of an existing tendon material property.</param>
        /// <param name="scaleFactorRelaxation">This value multiplies the relaxation coefficient, and hence the relaxation strain, computed for the material during a time-dependent analysis. 
        /// It has no effect for load cases that do not consider time-dependent effects, or for materials that do not consider relaxation effects. 
        /// The default value is unity, and the specified value must be positive.</param>
        /// <param name="temperature">This item is the temperature at which the specified data is to be retrieved. 
        /// The temperature must have been previously defined for the material.
        /// This item applies only if the specified material has properties that are temperature dependent. 
        /// That is, it applies only if properties are specified for the material at more than one temperature.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void SetScaleFactors(string name,
            double scaleFactorRelaxation,
            double temperature = 0)
        {
            _callCode = _sapModel.PropMaterial.TimeDep.SetTendonScaleFactors(name, scaleFactorRelaxation, temperature);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
