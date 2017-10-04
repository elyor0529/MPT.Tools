#if !BUILD_ETABS2015 && !BUILD_ETABS2016
using MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.CodesAutoLoad.Wave;
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern
{
    /// <summary>
    /// Represents an auto wave load pattern in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.IAutoLoad" />
    public class AutoWave : CSiApiBase, IAutoLoad
    {
#region Fields
        private readonly CSiApiSeed _seed;

        private WaveLoadGeneric _WaveLoadGeneric;

#endregion

#region Properties
        /// <summary>
        /// Auto wave load pattern according to generic definitions.
        /// </summary>
        public WaveLoadGeneric WaveLoadGeneric => _WaveLoadGeneric ?? (_WaveLoadGeneric = new WaveLoadGeneric(_seed));


#endregion

#region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoWave"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public AutoWave(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }
#endregion

#region Methods: Interface

        /// <summary>
        /// This function retrieves the code name used for auto wave parameters in Wave-type load patterns.
        /// An error is returned if the specified load pattern is not a Wave-type load pattern.
        /// </summary>
        /// <param name="name">The name of an existing Wave-type load pattern.</param>
        /// <param name="codeName">This is either blank or the name code used for the auto wave parameters. 
        /// Blank means no auto wave load is specified for the Wave-type load pattern.</param>
        public void GetAutoCode(string name,
            ref string codeName)
        {
            _callCode = _sapModel.LoadPatterns.GetAutoWaveCode(name, ref codeName);

            // TODO: Figure out how to handle: An error is returned if the specified load pattern is not a Wave-type load pattern.

            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function sets the auto seastate loading type for the specified load pattern to None.
        /// </summary>
        /// <param name="name">The name of an existing seastate-type load pattern.</param>
        public void SetNone(string name)
        {
            _callCode = _sapModel.LoadPatterns.AutoSeastate.SetNone(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


#endregion

#region Methods: Public

        /// <summary>
        /// This function retrieves auto seastate loading parameters.
        /// </summary>
        /// <param name="name">The name of an existing seastate-type load pattern.</param>
        /// <param name="loadMethod">This is one of the following three options defining what parameters are being specified.</param>
        /// <param name="coordinateSystem">The coordinate system used as a reference for specifying the center of rotation location and the inertia load parameters.</param>
        /// <param name="adjustGravityLateral">This item only applies when using LoadMethod 1 or 2. 
        /// It is True if generated lateral loads should include the effects of the rotated structure, otherwise it is False.</param>
        /// <param name="adjustGravityLateralFactor">This item only applies when using LoadMethod 1 or 2. 
        /// This is a scale factor on the lateral effects generated as a result of the rotated structure.</param>
        /// <param name="adjustGravityVertical">This item only applies when using LoadMethod 1 or 2. 
        /// It is True if generated vetical loads should include the effects of the rotated structure, otherwise it is False.</param>
        /// <param name="adjustGravityVerticalFactor">This item only applies when using LoadMethod 1 or 2. 
        /// This is a scale factor on the vertical effects generated as a result of the rotated structure.</param>
        /// <param name="centerRotation">This is an array dimensioned to 2 (3 doubles) that defines the coordinates of the center of rotation, with respect to the selected coordinate system.</param>
        /// <param name="parameters">This is an array of the inertia load parameters, based on the specified LoadMethod, as described below. For all cases, the array contains the amplitude, period, &amp; phase for each DOF: 
        /// Load Method = 1: UZ, RX, RY, Load Method = 2: UX, UY, UZ, RX, RY, RZ, Load Method = 3: UX, UY, UZ, RX, RY, RZ</param>
        /// <param name="ignorePhase">This item only applies when using LoadMethod 1 or 2. 
        /// It is True if the input phases should be ignored, otherwise it is False.</param>
        public void GetAuto(string name,
            ref int loadMethod,
            ref string coordinateSystem,
            ref bool adjustGravityLateral,
            ref double adjustGravityLateralFactor,
            ref bool adjustGravityVertical,
            ref double adjustGravityVerticalFactor,
            ref double[] centerRotation,
            ref double[] parameters,
            ref bool ignorePhase)
        {
            _callCode = _sapModel.LoadPatterns.AutoSeastate.GetAuto(name, ref loadMethod, ref coordinateSystem, ref adjustGravityLateral, ref adjustGravityLateralFactor, ref adjustGravityVertical, ref adjustGravityVerticalFactor, ref centerRotation, ref parameters, ref ignorePhase);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves auto seastate loading parameters.
        /// </summary>
        /// <param name="name">The name of an existing seastate-type load pattern.</param>
        /// <param name="loadMethod">This is one of the following three options defining what parameters are being specified.</param>
        /// <param name="coordinateSystem">The coordinate system used as a reference for specifying the center of rotation location and the inertia load parameters.</param>
        /// <param name="adjustGravityLateral">This item only applies when using LoadMethod 1 or 2. 
        /// It is True if generated lateral loads should include the effects of the rotated structure, otherwise it is False.</param>
        /// <param name="adjustGravityLateralFactor">This item only applies when using LoadMethod 1 or 2. 
        /// This is a scale factor on the lateral effects generated as a result of the rotated structure.</param>
        /// <param name="adjustGravityVertical">This item only applies when using LoadMethod 1 or 2. 
        /// It is True if generated vetical loads should include the effects of the rotated structure, otherwise it is False.</param>
        /// <param name="adjustGravityVerticalFactor">This item only applies when using LoadMethod 1 or 2. 
        /// This is a scale factor on the vertical effects generated as a result of the rotated structure.</param>
        /// <param name="centerRotation">This is an array dimensioned to 2 (3 doubles) that defines the coordinates of the center of rotation, with respect to the selected coordinate system.</param>
        /// <param name="parameters">This is an array of the inertia load parameters, based on the specified LoadMethod, as described below. For all cases, the array contains the amplitude, period, &amp; phase for each DOF: 
        /// Load Method = 1: UZ, RX, RY, Load Method = 2: UX, UY, UZ, RX, RY, RZ, Load Method = 3: UX, UY, UZ, RX, RY, RZ</param>
        /// <param name="ignorePhase">This item only applies when using LoadMethod 1 or 2. 
        /// It is True if the input phases should be ignored, otherwise it is False.</param>
        public void SetAuto(string name,
            int loadMethod,
            string coordinateSystem,
            bool adjustGravityLateral,
            double adjustGravityLateralFactor,
            bool adjustGravityVertical,
            double adjustGravityVerticalFactor,
            double[] centerRotation,
            double[] parameters,
            bool ignorePhase)
        {
            _callCode = _sapModel.LoadPatterns.AutoSeastate.SetAuto(name, loadMethod, coordinateSystem, adjustGravityLateral, adjustGravityLateralFactor, adjustGravityVertical, adjustGravityVerticalFactor, centerRotation, parameters, ignorePhase);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
#endregion
    }
}
#endif
