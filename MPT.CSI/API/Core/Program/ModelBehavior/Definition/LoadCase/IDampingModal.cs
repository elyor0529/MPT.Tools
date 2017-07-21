namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Represents modal damping in the application.
    /// </summary>
    public interface IDampingModal:
        IDampingProportional
    {
        /// <summary>
        /// This function retrieves the constant modal damping for all modes assigned to the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case that has constant damping.</param>
        /// <param name="damping">The constant damping for all modes (0 &lt;= <paramref name="damping"/> &lt; 1).</param>
        void GetDampingConstant(string name,
            ref double damping);

        /// <summary>
        /// This function sets constant modal damping for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case that has constant damping.</param>
        /// <param name="damping">The constant damping for all modes (0 &lt;= <paramref name="damping"/> &lt; 1).</param>
        void SetDampingConstant(string name,
            double damping);



        /// <summary>
        /// This function retrieves the interpolated modal damping data assigned to the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case that has interpolated damping.</param>
        /// <param name="dampingType">The interpolated modal damping type.</param>
        /// <param name="numberOfItems">The number of <paramref name="periodsOrFrequencies"/> and <paramref name="damping"/> pairs.</param>
        /// <param name="periodsOrFrequencies">The periods or frequencies, depending on the value of <paramref name="dampingType"/>.
        /// [s] for <paramref name="dampingType"/> = <see cref="eDampingTypeInterpolated.InterpolatedByPeriod"/> and [cyc/s] for <paramref name="dampingType"/> = <see cref="eDampingTypeInterpolated.InterpolatedByFrequency"/>.</param>
        /// <param name="damping">The damping for the specified period of frequency (0 &lt;= <paramref name="damping"/> &lt; 1).</param>
        void GetDampingInterpolated(string name,
            ref eDampingTypeInterpolated dampingType,
            ref int numberOfItems,
            ref double[] periodsOrFrequencies,
            ref double[] damping);

        /// <summary>
        /// This function retrieves the interpolated modal damping data assigned to the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case that has interpolated damping.</param>
        /// <param name="dampingType">The interpolated modal damping type.</param>
        /// <param name="numberOfItems">The number of <paramref name="periodsOrFrequencies"/> and <paramref name="damping"/> pairs.</param>
        /// <param name="periodsOrFrequencies">The periods or frequencies, depending on the value of <paramref name="dampingType"/>.
        /// [s] for <paramref name="dampingType"/> = <see cref="eDampingTypeInterpolated.InterpolatedByPeriod"/> and [cyc/s] for <paramref name="dampingType"/> = <see cref="eDampingTypeInterpolated.InterpolatedByFrequency"/>.</param>
        /// <param name="damping">The damping for the specified period of frequency (0 &lt;= <paramref name="damping"/> &lt; 1).</param>
        void SetDampingInterpolated(string name,
            eDampingTypeInterpolated dampingType,
            int numberOfItems,
            double[] periodsOrFrequencies,
            double[] damping);






        /// <summary>
        /// This function retrieves the modal damping overrides assigned to the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing analysis case.</param>
        /// <param name="numberOfItems">The number of <paramref name="modes"/> and <paramref name="damping"/> pairs.</param>
        /// <param name="modes">The modes.</param>
        /// <param name="damping">The damping for the specified mode (0 &lt;= <paramref name="damping"/> &lt; 1).</param>
        void GetDampingOverrides(string name,
            ref int numberOfItems,
            ref int[] modes,
            ref double[] damping);


        /// <summary>
        /// This function retrieves the modal damping overrides assigned to the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing analysis case.</param>
        /// <param name="numberOfItems">The number of <paramref name="modes"/> and <paramref name="damping"/> pairs.</param>
        /// <param name="modes">The modes.</param>
        /// <param name="damping">The damping for the specified mode (0 &lt;= <paramref name="damping"/> &lt; 1).</param>
        void SetDampingOverrides(string name,
            int numberOfItems,
            int[] modes,
            double[] damping);





        /// <summary>
        /// This function retrieves the hysteretic damping type for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="dampingType">The modal damping type for the load case.</param>
        void GetDampingType(string name,
            ref eDampingType dampingType);
    }
}
