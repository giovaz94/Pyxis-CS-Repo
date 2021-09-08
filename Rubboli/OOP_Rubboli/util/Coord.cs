using System;
using System.Security.Cryptography;
using System.Text;

namespace OOP_Rubboli.util
{
    public class Coord : ICoord
    {
        private Pair<double, double> _internalPair;

        public Coord(double xCoord, double yCoord)
        {
            this._internalPair = new Pair<double, double>(xCoord, yCoord);
        }

        public Coord CopyOf()
        {
            return new Coord(this.X, this.Y);
        }

        public double Distance(Coord position)
        {
            double px = position.X - this.X;
            double py = position.Y - this.Y;
            return Math.Sqrt(px * px + py * py);
        }

        public double Distance(double x, double y)
        {
            double px = x - this.X;
            double py = y - this.Y;
            return Math.Sqrt(px * px + py * py);
        }

        public override bool Equals(Object o)
        {
            if (this == o)
            {
                return true; 
            }
            if (o == null || this.GetType() != o.GetType())
            {
                return false;
            }
            Coord coord = (Coord) o;
            return _internalPair.Equals(coord._internalPair);
        }

        public override int GetHashCode()
        {
            var md5Hasher = MD5.Create();
            var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(this.ToString()));
            var ivalue = BitConverter.ToInt32(hashed, 0);
            return ivalue;
        }

        public void SetXy(double xValue, double yValue)
        {
            this.X = xValue;
            this.Y = yValue;
        }
        
        public void SumCoord(Coord coord)
        {
            this.SumValues(coord.X, coord.Y);
        }

        public void SumValues(double xValue, double yValue)
        {
            this.SumXValue(xValue);
            this.SumYValue(yValue);
        }

        public void SumVector(Vector inputVector)
        {
            this.SumVector(inputVector, 1);
        }

        public void SumVector(Vector inputVector, double multiplier)
        {
            this.SumValues(inputVector.GetX() * multiplier, inputVector.GetY() * multiplier);
        }

        public void SumXValue(double xValue)
        {
            this._internalPair.SetFirst(this._internalPair.GetFirst() + xValue);
        }

        public void SumYValue(double yValue)
        {
            this._internalPair.SetSecond(this._internalPair.GetSecond() + yValue);
        }

        public double GetX()
        {
            return this.X;
        }

        public void SetX(double xValue)
        {
            this.X = xValue;
        }

        public double GetY()
        {
            return this.Y;
        }

        public void SetY(double yValue)
        {
            this.Y = yValue;
        }

        public override String ToString()
        {
            return "Position X: " + this._internalPair.GetFirst() + " and Y: " + this._internalPair.GetSecond();
        }

        private double X
        {
            get { return this._internalPair.GetFirst(); }
            set { this._internalPair.SetFirst(value); }
        }

        private double Y
        {
            get { return this._internalPair.GetSecond(); }
            set { this._internalPair.SetSecond(value); }
        }
    }
}