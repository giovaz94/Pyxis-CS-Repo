using System;
using System.Security.Cryptography;
using System.Text;
using OOP_Rubboli.util;

namespace OOP_Rubboli
{
    public class Ball : AbstractElement, IBall
    {
        private static Dimension DIMENSION = new Dimension(14, 14);
        private IVector _pace;

        public Ball(IVector inputPace, ICoord position, BallType type, int inputId)
            : base(DIMENSION, position) {
            this.Type = type;
            this.Pace = inputPace;
            this.Id = inputId;
        }

        private int Id { get; }

        private BallType Type { get; set; }

        public int GetId()
        {
            return this.Id;
        }

        private IVector Pace
        {
            get { return this._pace.CopyOf(); }
            set { this._pace = value; }
        }

        public override IVector GetPace()
        {
            return this.Pace;
        }

        public override void SetPace(IVector inputPace)
        {
            this.Pace = inputPace;
        }

        public new void Update(double dt)
        {
            this.GetPosition().SetX(this.GetPosition().GetX() + dt * this.Pace.GetX() * this.GetUpdateTimeMultiplier());
            this.GetPosition().SetY(this.GetPosition().GetY() + dt * this.Pace.GetY() * this.GetUpdateTimeMultiplier());
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
            bool testId = this.Id == ball.Id;
            bool testType = this.Type == ball.Type;
            return testId && testType && Pace.Equals(ball.Pace);
        }

        public override int GetHashCode()
        {
            var md5Hasher = MD5.Create();
            var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(this.ToString()));
            var ivalue = BitConverter.ToInt32(hashed, 0);
            return ivalue;
        }

        public new BallType GetType()
        {
            return this.Type;
        }

        public void SetType(BallType inputType)
        {
            this.Type = inputType;
        }

        public override string ToString()
        {
            return "Ball{" + "type=" + this.Type + ", pace=" + this.Pace + ", id=" + this.Id + "}";
        }
        
    }
}