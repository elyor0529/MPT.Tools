using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NMath = System.Math;

namespace MPT.Math.Coordinates
{
    public struct PolarCoordinate
    {

        public double Radius { get; set; }


        public Angle Rotation { get; set; }

        public CartesianCoordinate ToCartesian()
        {
            return new CartesianCoordinate
            {
                X = Radius * NMath.Cos(Rotation.Radians),
                Y = Radius * NMath.Sin(Rotation.Radians)
            };
        }
    }
}
