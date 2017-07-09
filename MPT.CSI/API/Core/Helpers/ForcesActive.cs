﻿
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Helpers
{
    /// <summary>
    /// Forces that are active based on the corresponding boolean value.
    /// </summary>
    public struct ForcesActive
    {
        /// <summary>
        /// Axial force. [F].
        /// </summary>
        public bool P { get; set; }

        /// <summary>
        /// Major axis shear. [F].
        /// </summary>
        public bool V2 { get; set; }


        /// <summary>
        /// Minor axis shear. [F].
        /// </summary>
        public bool V3 { get; set; }


        /// <summary>
        /// Torsion [F*L].
        /// </summary>
        public bool T { get; set; }

        /// <summary>
        /// Minor axis bending. [F*L].
        /// </summary>
        public bool M2 { get; set; }

        /// <summary>
        /// Major axis bending [F*L].
        /// </summary>
        public bool M3 { get; set; }

        /// <summary>
        /// Assigns array values to struct properties.
        /// Array must have 6 entries.
        /// </summary>
        /// <param name="forces">1x6 matrix of deformation values of the corresponding degree of freedom:
        /// Value(0) = <see cref="P"/>;
        /// Value(1) = <see cref="V2"/>;
        /// Value(2) = <see cref="V3"/>;
        /// Value(3) = <see cref="T"/>;
        /// Value(4) = <see cref="M2"/>;
        /// Value(5) = <see cref="M3"/></param>
        public void FromArray(bool[] forces)
        {
            if (forces.Length != 6) { throw new CSiException("Array has " + forces.Length + " elements when 6 elements was expected."); }
            P = forces[0];
            V2 = forces[1];
            V3 = forces[2];
            T = forces[3];
            M2 = forces[4];
            M3 = forces[5];
        }

        /// <summary>
        /// Return a 1x6 matrix of deformation values of the corresponding degree of freedom:
        /// Value(0) = <see cref="P"/>;
        /// Value(1) = <see cref="V2"/>;
        /// Value(2) = <see cref="V3"/>;
        /// Value(3) = <see cref="T"/>;
        /// Value(4) = <see cref="M2"/>;
        /// Value(5) = <see cref="M3"/>
        /// </summary>
        /// <returns></returns>
        public bool[] ToArray()
        {
            bool[] forces = { P, V2, V3, T, M2, M3};
            return forces;
        }
    }
}