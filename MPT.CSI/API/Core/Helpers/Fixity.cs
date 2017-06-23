
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Helpers
{
    /// <summary>
    /// Fixities along the local degrees-of-freedom.
    /// </summary>
    public struct Fixity
    {
        /// <summary>
        /// Translational fixity along the 1-axis [F/L].
        /// </summary>
        public double U1 { get; set; }

        /// <summary>
        /// Translational fixity along the 2-axis [F/L].
        /// </summary>
        public double U2 { get; set; }


        /// <summary>
        /// Translational fixity along the 3-axis [F/L].
        /// </summary>
        public double U3 { get; set; }


        /// <summary>
        /// Rotational fixity along the 1-axis [FL/rad].
        /// </summary>
        public double R1 { get; set; }

        /// <summary>
        /// Rotational fixity along the 2-axis [FL/rad].
        /// </summary>
        public double R2 { get; set; }

        /// <summary>
        /// Rotational fixity along the 3-axis [FL/rad].
        /// </summary>
        public double R3 { get; set; }

        /// <summary>
        /// Assigns array values to struct properties.
        /// Array must have 6 entries.
        /// </summary>
        /// <param name="deformations">1x6 matrix of fixity values of the corresponding degree of freedom:
        /// Value(0) = <see cref="U1"/>;
        /// Value(1) = <see cref="U2"/>;
        /// Value(2) = <see cref="U3"/>;
        /// Value(3) = <see cref="R1"/>;
        /// Value(4) = <see cref="R2"/>;
        /// Value(5) = <see cref="R3"/></param>
        public void FromArray(double[] deformations)
        {
            if (deformations.Length != 6) { throw new CSiException("Array has " + deformations.Length + " elements when 6 elements was expected."); }
            U1 = deformations[0];
            U2 = deformations[1];
            U3 = deformations[2];
            R1 = deformations[3];
            R2 = deformations[4];
            R3 = deformations[5];
        }

        /// <summary>
        /// Return a 1x6 matrix of fixity values of the corresponding degree of freedom:
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
            double[] deformations = { U1, U2, U3, R1, R2, R3};
            return deformations;
        }
    }
}
