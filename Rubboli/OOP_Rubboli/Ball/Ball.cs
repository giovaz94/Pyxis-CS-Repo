using System;
using System.Security.Cryptography;
using System.Text;
using OOP_Rubboli.util;

namespace OOP_Rubboli
{
    public class Ball : AbstractElement, IBall
    {
        private static Dimension DIMENSION = new Dimension(14, 14);
        private BallType _type;
        private Vector _pace;
        private int _id;

        public Ball(Vector inputPace, Coord position, BallType type, int inputId)
            : base(DIMENSION, position) {
            this._type = type;
            this._pace = inputPace;
            this._id = inputId;
        }

        public int Id { get; }

        public Vector Pace
        {
            get;
            set;
        }

        public BallType Type { get; set; }

        public new void Update(double dt)
        {
            this.Position.X = this.Position.X + dt * this.Pace.X * UpdateTimeMultiplier;
            this.Position.Y = this.Position.Y + dt * this.Pace.Y * UpdateTimeMultiplier;
        }

        public override bool Equals(Object o)
        {
            if (this == o)
            {
                return true;
            }
            if (!(o is Ball))
            {
                return false;
            }
            Ball ball = (Ball) o;
            bool testId = this._id == ball._id;
            bool testType = this._type == ball.Type;
            return testId && testType && Pace.Equals(ball.Pace);
        }

        public override int GetHashCode()
        {
            var md5Hasher = MD5.Create();
            var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(this.ToString()));
            var ivalue = BitConverter.ToInt32(hashed, 0);
            return ivalue;
        }

        public override string ToString()
        {
            return "Ball{" + "type=" + this._type + ", pace=" + _pace + ", id=" + _id + "}";
        }
        
    }
}