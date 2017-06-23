
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Helpers
{
    /// <summary>
    /// Displacements or offsets along the Global degrees of freedom.
    /// </summary>
    public struct Displacements
    {
        /// <summary>
        /// Translational displacement/offset along the X-axis.
        /// </summary>
        public double UX { get; set; }

        /// <summary>
        /// Translational displacement/offset along the Y-axis.
        /// </summary>
        public double UY { get; set; }


        /// <summary>
        /// Translational displacement/offset along the Z-axis.
        /// </summary>
        public double UZ { get; set; }


        /// <summary>
        /// Rotational displacement/offset along the X-axis.
        /// </summary>
        public double RX { get; set; }

        /// <summary>
        /// Rotational displacement/offset along the Y-axis.
        /// </summary>
        public double RY { get; set; }

        /// <summary>
        /// Rotational displacement/offset along the Z-axis.
        /// </summary>
        public double RZ { get; set; }

        /// <summary>
        /// Assigns array values to struct properties.
        /// Array must have 6 entries.
        /// </summary>
        /// <param name="displacements">1x6 matrix of values of displacements/offsets along the corresponding degree of freedom:
        /// Value(0) = <see cref="UX"/>;
        /// Value(1) = <see cref="UY"/>;
        /// Value(2) = <see cref="UZ"/>;
        /// Value(3) = <see cref="RX"/>;
        /// Value(4) = <see cref="RY"/>;
        /// Value(5) = <see cref="RZ"/></param>
        public void FromArray(double[] displacements)
        {
            if (displacements.Length != 6) { throw new CSiException("Array has " + displacements.Length + " elements when 6 elements was expected."); }
            UX = displacements[0];
            UY = displacements[1];
            UZ = displacements[2];
            RX = displacements[3];
            RY = displacements[4];
            RZ = displacements[5];
        }

        /// <summary>
        /// Return a 1x6 matrix of booleans indicating inclusion of the corresponding degree of freedom:
        /// Value(0) = <see cref="UX"/>;
        /// Value(1) = <see cref="UY"/>;
        /// Value(2) = <see cref="UZ"/>;
        /// Value(3) = <see cref="RX"/>;
        /// Value(4) = <see cref="RY"/>;
        /// Value(5) = <see cref="RZ"/>
        /// </summary>
        /// <returns></returns>
        public double[] ToArray()
        {
            double[] displacements = { UX, UY, UZ, RX, RY, RZ};
            return displacements;
        }
    }
}
