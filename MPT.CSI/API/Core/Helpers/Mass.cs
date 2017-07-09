using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Helpers
{
    /// <summary>
    /// Mass values for each degree of freedom.
    /// </summary>
    public struct Mass
    {
        /// <summary>
        /// Translational mass along the 1-axis [M].
        /// </summary>
        public double U1 { get; set; }

        /// <summary>
        /// Translational mass along the 2-axis [M].
        /// </summary>
        public double U2 { get; set; }


        /// <summary>
        /// Translational mass along the 3-axis [M].
        /// </summary>
        public double U3 { get; set; }


        /// <summary>
        /// Rotational mass about the 1-axis [M*L^2].
        /// </summary>
        public double R1 { get; set; }

        /// <summary>
        /// Rotational mass about the 2-axis [M*L^2].
        /// </summary>
        public double R2 { get; set; }

        /// <summary>
        /// Rotational mass about the 3-axis [M*L^2].
        /// </summary>
        public double R3 { get; set; }

        /// <summary>
        /// Assigns array values to struct properties.
        /// Array must have 6 entries.
        /// </summary>
        /// <param name="stiffnesses">1x6 matrix of mass values of the corresponding degree of freedom:
        /// Value(0) = <see cref="U1"/>;
        /// Value(1) = <see cref="U2"/>;
        /// Value(2) = <see cref="U3"/>;
        /// Value(3) = <see cref="R1"/>;
        /// Value(4) = <see cref="R2"/>;
        /// Value(5) = <see cref="R3"/></param>
        public void FromArray(double[] stiffnesses)
        {
            if (stiffnesses.Length != 6) { throw new CSiException("Array has " + stiffnesses.Length + " elements when 6 elements was expected."); }
            U1 = stiffnesses[0];
            U2 = stiffnesses[1];
            U3 = stiffnesses[2];
            R1 = stiffnesses[3];
            R2 = stiffnesses[4];
            R3 = stiffnesses[5];
        }

        /// <summary>
        /// Return a 1x6 matrix of mass values of the corresponding degree of freedom:
        /// Value(0) = <see cref="U1"/>;
        /// Value(1) = <see cref="U2"/>;
        /// Value(2) = <see cref="U3"/>;
        /// Value(3) = <see cref="R1"/>;
        /// Value(4) = <see cref="R2"/>;
        /// Value(5) = <see cref="R3"/>
        /// </summary>
        /// <returns></returns>
        public double[] ToArray()
        {
            double[] stiffnesses = { U1, U2, U3, R1, R2, R3 };
            return stiffnesses;
        }
    }
}
