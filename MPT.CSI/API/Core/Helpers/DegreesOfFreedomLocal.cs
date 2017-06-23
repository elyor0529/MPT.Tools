
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Helpers
{
    /// <summary>
    /// Local degrees of freedom, the inclusion of which is indicated by the corresponding boolean.
    /// </summary>
    public struct DegreesOfFreedomLocal
    {
        /// <summary>
        /// Translational degree-of-freedom along the 1-axis.
        /// </summary>
        public bool U1 { get; set; }

        /// <summary>
        /// Translational degree-of-freedom along the 2-axis.
        /// </summary>
        public bool U2 { get; set; }


        /// <summary>
        /// Translational degree-of-freedom along the 3-axis.
        /// </summary>
        public bool U3 { get; set; }


        /// <summary>
        /// Rotational degree-of-freedom along the 1-axis.
        /// </summary>
        public bool R1 { get; set; }

        /// <summary>
        /// Rotational degree-of-freedom along the 2-axis.
        /// </summary>
        public bool R2 { get; set; }

        /// <summary>
        /// Rotational degree-of-freedom along the 3-axis.
        /// </summary>
        public bool R3 { get; set; }

        /// <summary>
        /// Assigns array values to struct properties.
        /// Array must have 6 entries.
        /// </summary>
        /// <param name="degreesOfFreedom">1x6 matrix of booleans indicating inclusion of the corresponding degree of freedom:
        /// Value(0) = <see cref="U1"/>;
        /// Value(1) = <see cref="U2"/>;
        /// Value(2) = <see cref="U3"/>;
        /// Value(3) = <see cref="R1"/>;
        /// Value(4) = <see cref="R2"/>;
        /// Value(5) = <see cref="R3"/></param>
        public void FromArray(bool[] degreesOfFreedom)
        {
            if (degreesOfFreedom.Length != 6) { throw new CSiException("Array has " + degreesOfFreedom.Length + " elements when 6 elements was expected."); }
            U1 = degreesOfFreedom[0];
            U2 = degreesOfFreedom[1];
            U3 = degreesOfFreedom[2];
            R1 = degreesOfFreedom[3];
            R2 = degreesOfFreedom[4];
            R3 = degreesOfFreedom[5];
        }

        /// <summary>
        /// Return a 1x6 matrix of booleans indicating inclusion of the corresponding degree of freedom:
        /// Value(0) = <see cref="U1"/>;
        /// Value(1) = <see cref="U2"/>;
        /// Value(2) = <see cref="U3"/>;
        /// Value(3) = <see cref="R1"/>;
        /// Value(4) = <see cref="R2"/>;
        /// Value(5) = <see cref="R3"/>
        /// </summary>
        /// <returns></returns>
        public bool[] ToArray()
        {
            bool[] degreesOfFreedom = { U1, U2, U3, R1, R2, R3};
            return degreesOfFreedom;
        }
    }
}
