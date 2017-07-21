using MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property.TimeDependent.CodesConcrete;
using MPT.CSI.API.Core.Support;

#if BUILD_SAP2000v16
using SAP2000v16;
#elif BUILD_SAP2000v17
using SAP2000v17;
#elif BUILD_SAP2000v18
using SAP2000v18;
#elif BUILD_SAP2000v19
using SAP2000v19;
#elif BUILD_ETABS2013
using ETABS2013;
#elif BUILD_ETABS2014
using ETABS2014;
#elif BUILD_ETABS2015
using ETABS2015;
#elif BUILD_ETABS2016
using ETABS2016;
#endif

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

        /// <summary>
        /// This function retrieves the scale factors for the time-dependent material property data for concrete materials.
        /// </summary>
        /// <param name="name">The name of an existing concrete material property.</param>
        /// <param name="scaleFactorAge">This value multiplies the stiffness (modulus of elasticity) computed with age for the material during a time-dependent analysis. 
        /// It has no effect for load cases that do not consider time-dependent effects, or for materials that do not consider time-dependent age effects. 
        /// The default value is unity, and the specified value must be positive.</param>
        /// <param name="scaleFactorCreep">This value multiplies the creep coefficient, and hence the creep strain, computed for the material during a time-dependent analysis. 
        /// It has no effect for load cases that do not consider time-dependent effects, or for materials that do not consider creep effects. 
        /// The default value is unity, and the specified value must be positive.</param>
        /// <param name="scaleFactorShrinkage">This value multiplies the shrinkage strain computed for the material during a time-dependent analysis. 
        /// It has no effect for load cases that do not consider time-dependent effects, or for materials that do not consider shrinkage effects. 
        /// The default value is unity, and the specified value must be positive.</param>
        /// <param name="temperature">This item is the temperature at which the specified data is to be retrieved. 
        /// The temperature must have been previously defined for the material.
        /// This item applies only if the specified material has properties that are temperature dependent. 
        /// That is, it applies only if properties are specified for the material at more than one temperature.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void GetScaleFactors(string name,
            double scaleFactorAge,
            double scaleFactorCreep,
            double scaleFactorShrinkage,
            double temperature = 0)
        {
            _callCode = _sapModel.PropMaterial.TimeDep.GetConcreteScaleFactors(name, ref scaleFactorAge, ref scaleFactorCreep, ref scaleFactorShrinkage, temperature);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function sets scale factors for the time-dependent material property data for concrete materials. 
        /// If this function is not called, default values of unity are assumed for all scale factors.
        /// </summary>
        /// <param name="name">The name of an existing concrete material property.</param>
        /// <param name="scaleFactorAge">This value multiplies the stiffness (modulus of elasticity) computed with age for the material during a time-dependent analysis. 
        /// It has no effect for load cases that do not consider time-dependent effects, or for materials that do not consider time-dependent age effects. 
        /// The default value is unity, and the specified value must be positive.</param>
        /// <param name="scaleFactorCreep">This value multiplies the creep coefficient, and hence the creep strain, computed for the material during a time-dependent analysis. 
        /// It has no effect for load cases that do not consider time-dependent effects, or for materials that do not consider creep effects. 
        /// The default value is unity, and the specified value must be positive.</param>
        /// <param name="scaleFactorShrinkage">This value multiplies the shrinkage strain computed for the material during a time-dependent analysis. 
        /// It has no effect for load cases that do not consider time-dependent effects, or for materials that do not consider shrinkage effects. 
        /// The default value is unity, and the specified value must be positive.</param>
        /// <param name="temperature">This item is the temperature at which the specified data is to be retrieved. 
        /// The temperature must have been previously defined for the material.
        /// This item applies only if the specified material has properties that are temperature dependent. 
        /// That is, it applies only if properties are specified for the material at more than one temperature.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void SetScaleFactors(string name,
            double scaleFactorAge,
            double scaleFactorCreep,
            double scaleFactorShrinkage,
            double temperature = 0)
        {
            _callCode = _sapModel.PropMaterial.TimeDep.SetConcreteScaleFactors(name, scaleFactorAge, scaleFactorCreep, scaleFactorShrinkage, temperature);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
