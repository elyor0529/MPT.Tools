
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Helpers
{
    /// <summary>
    /// Reaction values associated with forces oriented along global axes.
    /// </summary>
    public struct Reactions
    {
        /// <summary>
        /// Translational force in the coordinate system X-axis direction [F].
        /// </summary>
        public double Fx { get; set; }

        /// <summary>
        /// Translational force in the coordinate system Y-axis direction [F].
        /// </summary>
        public double Fy { get; set; }


        /// <summary>
        /// Translational force in the coordinate system Z-axis direction [F].
        /// </summary>
        public double Fz { get; set; }


        /// <summary>
        /// Moment about the coordinate system X-axis [F*L].
        /// </summary>
        public double Mx { get; set; }

        /// <summary>
        /// Moment about the coordinate system Yaxis [F*L].
        /// </summary>
        public double My { get; set; }

        /// <summary>
        /// Moment about the coordinate system Z-axis [F*L].
        /// </summary>
        public double Mz { get; set; }

        /// <summary>
        /// Assigns array values to struct properties.
        /// Array must have 6 entries.
        /// </summary>
        /// <param name="forces">1x6 matrix of force values of the corresponding global axis:
        /// Value(0) = <see cref="Fx"/>;
        /// Value(1) = <see cref="Fy"/>;
        /// Value(2) = <see cref="Fz"/>;
        /// Value(3) = <see cref="Mx"/>;
        /// Value(4) = <see cref="My"/>;
        /// Value(5) = <see cref="Mz"/></param>
        public void FromArray(double[] forces)
        {
            if (forces.Length != 6) { throw new CSiException("Array has " + forces.Length + " elements when 6 elements was expected."); }
            Fx = forces[0];
            Fy = forces[1];
            Fz = forces[2];
            Mx = forces[3];
            My = forces[4];
            Mz = forces[5];
        }

        /// <summary>
        /// Return a 1x6 matrix of force values of the corresponding global axis:
        /// Value(0) = <see cref="Fx"/>;
        /// Value(1) = <see cref="Fy"/>;
        /// Value(2) = <see cref="Fz"/>;
        /// Value(3) = <see cref="Mx"/>;
        /// Value(4) = <see cref="My"/>;
        /// Value(5) = <see cref="Mz"/>
        /// </summary>
        /// <returns></returns>
        public double[] ToArray()
        {
            double[] forces = { Fx, Fy, Fz, Mx, My, Mz };
            return forces;
        }
    }
}
