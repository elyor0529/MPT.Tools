using NMath = System.Math;
using NVector = System.Windows.Vector;

namespace MPT.Math.Coordinates
{
    public struct CartesianCoordinate
    {

        public double X { get; set; }


        public double Y { get; set; }


        public PolarCoordinate ToPolar()
        {
            return new PolarCoordinate
            {
                Radius = Algebra.SRSS(X, Y),
                Rotation = new Angle(NMath.Atan(Y/X))
            };
        }

        public BarycentricCoordinate ToBarycentric(NVector vertexA, NVector vertexB, NVector vertexC)
        {
            double determinate = (vertexB.Y - vertexC.Y) * (vertexA.X - vertexC.X) +
                                 (vertexC.X - vertexB.X) * (vertexA.Y - vertexC.Y);

            double alpha = ((vertexB.Y = vertexC.Y) * (X - vertexC.X) +
                            (vertexC.X - vertexB.X) * (Y - vertexC.Y)) / determinate;

            double beta = ((vertexC.Y = vertexA.Y) * (X - vertexC.X) +
                            (vertexA.X - vertexC.X) * (Y - vertexC.Y)) / determinate;

            double gamma = 1 - alpha - beta;

            return new BarycentricCoordinate
            {
                Alpha = alpha,
                Beta = beta,
                Gamma = gamma
            };
        }

        public TrilinearCoordinate ToTrilinear(NVector vertexA, NVector vertexB, NVector vertexC)
        {
            BarycentricCoordinate barycentric = ToBarycentric(vertexA, vertexB, vertexC);
            return barycentric.ToTrilinear(vertexA, vertexB, vertexC);
        }

    }
}
