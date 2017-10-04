#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Represents steady state damping in the application.
    /// </summary>
    public interface IDampingSteadyState
    {
        /// <summary>
        /// This function retrieves the constant hysteretic damping for all frequencies assigned to the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing steady state load case that has constant damping.</param>
        /// <param name="massProportionalDampingCoefficient">The mass proportional damping coefficient.</param>
        /// <param name="stiffnessProportionalDampingCoefficient">The stiffness proportional damping coefficient.</param>
        void GetDampingConstant(string name,
            ref double massProportionalDampingCoefficient,
            ref double stiffnessProportionalDampingCoefficient);

        /// <summary>
        /// This function sets constant hysteretic damping for all frequencies for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing steady state load case that has constant damping.</param>
        /// <param name="massProportionalDampingCoefficient">The mass proportional damping coefficient.</param>
        /// <param name="stiffnessProportionalDampingCoefficient">The stiffness proportional damping coefficient.</param>
        void SetDampingConstant(string name,
            double massProportionalDampingCoefficient,
            double stiffnessProportionalDampingCoefficient);



        /// <summary>
        /// This function retrieves the interpolated hysteretic damping by frequency assigned to the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing steady state load case that has interpolated damping.</param>
        /// <param name="massProportionalDampingCoefficient">The mass proportional damping coefficients.</param>
        /// <param name="stiffnessProportionalDampingCoefficient">The stiffness proportional damping coefficients.</param>
        /// <param name="frequencyUnit">The frequency unit.</param>
        /// <param name="numberOfFrequencies">The number of frequencies.</param>
        /// <param name="frequencies">The frequencies, given in the units specified by <paramref name="frequencyUnit"/>.</param>
        void GetDampingInterpolated(string name,
            ref eFrequencyType frequencyUnit,
            ref int numberOfFrequencies,
            ref double[] frequencies,
            ref double[] massProportionalDampingCoefficient,
            ref double[] stiffnessProportionalDampingCoefficient);

        /// <summary>
        /// This function sets interpolated hysteretic damping by frequency for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing steady state load case that has interpolated damping.</param>
        /// <param name="massProportionalDampingCoefficient">The mass proportional damping coefficients.</param>
        /// <param name="stiffnessProportionalDampingCoefficient">The stiffness proportional damping coefficients.</param>
        /// <param name="frequencyUnit">The frequency unit.</param>
        /// <param name="numberOfFrequencies">The number of frequencies.</param>
        /// <param name="frequencies">The frequencies, given in the units specified by <paramref name="frequencyUnit"/>.</param>
        void SetDampingInterpolated(string name,
            eFrequencyType frequencyUnit,
            int numberOfFrequencies,
            double[] frequencies,
            double[] massProportionalDampingCoefficient,
            double[] stiffnessProportionalDampingCoefficient);



        /// <summary>
        /// This function retrieves the hysteretic damping type for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing steady state load case.</param>
        /// <param name="dampingType">The hysteretic damping type for the load case.</param>
        void GetDampingType(string name,
            ref eDampingTypeHysteretic dampingType);
    }
}

#endif