using System;

using NMath = System.Math;

namespace MPT.Math.Coordinates
{
    /// <summary>
    /// Represents an Angle based on a radian value.
    /// </summary>
    public struct Angle : IEquatable<Angle>
    {
        /// <summary>
        /// Default zero tolerance for operations.
        /// </summary>
        public double Tolerance { get; set; } 

        private double _radians;
        /// <summary>
        /// Gets or sets the radians, which is a value between -PI and +PI.
        /// </summary>
        public double Radians
        {
            get { return _radians; }
            set
            {
                _radians = WrapAngle(value); 
            }
        }
        /// <summary>
        /// Gets or sets the clockwise (inverted) radians.
        /// </summary>
        public double ClockwiseRadians { get { return -_radians; } set { Radians = -value; } }


        /// <summary>
        /// Gets or sets the degree.
        /// </summary>
        public double Degree { get { return ToDegrees(_radians); } set { Radians = ToRadians(value); } }
        /// <summary>
        /// Gets or sets the clockwise (inverted) degree.
        /// </summary>
        public double ClockwiseDegree { get { return ToDegrees(-_radians); } set { Radians = ToRadians(-value); } }

        /// <summary>
        /// Initializes a new instance of the <see cref="Angle"/> struct.
        /// </summary>
        /// <param name="radians">The radians.</param>
        public Angle(double radians)
        {
            _radians = WrapAngle(radians);
            Tolerance = Numbers.ZeroTolerance;
        }

        #region Static Methods

        /// <summary>
        /// Creates an <see cref="Angle"/> from degree.
        /// </summary>
        /// <param name="degree">The degree.</param>
        /// <returns></returns>
        public static Angle CreateFromDegree(double degree)
        {
            return new Angle(ToRadians(degree));
        }

        /// <summary>
        /// Creates an <see cref="Angle"/> from a direction vector.
        /// </summary>
        /// <param name="direction">The direction.</param>
        public static Angle CreateFromVector(Vector direction)
        {
            Angle a = new Angle(0);
            a.SetDirectionVector(direction);
            return a;
        }

        /// <summary>
        /// Reduces a given angle to a value between π and -π.
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static double WrapAngle(double radians)
        {
            int revolutions = (int)NMath.Floor(radians / Numbers.TwoPi);
            double wrappedAngle = radians - revolutions*Numbers.TwoPi;

            if (NMath.Abs(wrappedAngle) > Numbers.Pi)
            {
                return -NMath.Sign(wrappedAngle)*(Numbers.TwoPi - NMath.Abs(wrappedAngle));
            }
            return wrappedAngle;
        }

        /// <summary>
        /// Converts the radian angle to degrees.
        /// </summary>
        /// <param name="radians">The angle to convert [radians].</param>
        /// <returns>System.Double.</returns>
        public static double ToDegrees(double radians)
        {
            return (radians / Numbers.Pi);
        }

        /// <summary>
        /// Converts the degrees angle to radians.
        /// </summary>
        /// <param name="degrees">The angle to convert [degrees].</param>
        /// <returns>System.Double.</returns>
        public static double ToRadians(double degrees)
        {
            return (degrees * Numbers.Pi);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets the direction vector, which is a normalized vector pointing to the direction of this angle.
        /// </summary>
        public Vector GetDirectionVector()
        {
            return new Vector(NMath.Cos(ClockwiseRadians), NMath.Sin(ClockwiseRadians));
        }
        /// <summary>
        /// Sets the Angle by using a direction vector.
        /// </summary>
        /// <param name="direction">The direction vector.</param>
        public void SetDirectionVector(Vector direction)
        {
            ClockwiseRadians = NMath.Atan2(direction.Ycomponent, direction.Xcomponent);
        }

        /// <summary>
        /// Rotates the given Vector around the zero point.
        /// </summary>
        /// <param name="vector">The vector to rotate.</param>
        /// <returns>The rotated vector.</returns>
        public Vector RotateVector(Vector vector)
        {
            if (_radians == 0)
                return vector;

            Angle completeAngle = Angle.CreateFromVector(vector) + _radians;
            return completeAngle.GetDirectionVector() * vector.Magnitude;
        }

        #endregion




        #region Operators & Equals

        public bool Equals(Angle other)
        {
            return NMath.Abs(_radians - other._radians) < Tolerance;
        }

        public override bool Equals(object obj)
        {
            if (obj is Angle) { return Equals((Angle)obj); }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return _radians.GetHashCode();
        }


        public static bool operator ==(Angle a, Angle b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Angle a, Angle b)
        {
            return !a.Equals(b);
        }
        public static bool operator ==(Angle a, double b)
        {
            return a._radians == b;
        }
        public static bool operator !=(Angle a, double b)
        {
            return a._radians != b;
        }
        public static bool operator ==(double a, Angle b)
        {
            return a == b._radians;
        }
        public static bool operator !=(double a, Angle b)
        {
            return a != b._radians;
        }
       
        public static Angle operator +(Angle a, Angle b)
        {
            return new Angle(a._radians + b._radians);
        }
        /// <summary>
        /// Implements the operator + for an angle and a double which represents radians.
        /// </summary>
        /// <returns>The result of the operator.</returns>
        public static Angle operator +(Angle a, double b)
        {
            return new Angle(a._radians + b);
        }

        public static Angle operator -(Angle a, Angle b)
        {
            return new Angle(a._radians - b._radians);
        }
        /// <summary>
        /// Implements the operator - for an angle and a double which represents radians.
        /// </summary>
        /// <returns>The result of the operator.</returns>
        public static Angle operator -(Angle a, double b)
        {
            return new Angle(a._radians - b);
        }

        public static Angle operator *(Angle a, double b)
        {
            return new Angle(a._radians * b);
        }

        public static Angle operator /(Angle a, double b)
        {
            return new Angle(a._radians / b);
        }

        public static explicit operator double(Angle a)
        {
            return a.Radians;
        }

        public static implicit operator Angle(double b)
        {
            return new Angle(b);
        }

        #endregion


    }
}
