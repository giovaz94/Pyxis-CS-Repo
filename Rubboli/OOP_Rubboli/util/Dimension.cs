using System;
using System.Security.Cryptography;
using System.Text;

namespace OOP_Rubboli.util
{
    public class Dimension : IDimension
    {
        private Pair<double, double> _internalPair;

        public Dimension(double width, double height)
        {
            this._internalPair = new Pair<double, double>(width, height);
        }

        public Dimension() : this(0, 0)
        {
        }
    
        public Dimension CopyOf()
        {
            return new Dimension(this.Width, this.Height);
        }

        public double GetHeight()
        {
            return this.Height;
        }

        public void SetHeight(double inputHeight)
        {
            this.Height = inputHeight;
        }

        public override bool Equals(Object o)
        {
            if (this == o)
            {
                return true;
            }
            if (!(o is Dimension))
            {
                return false;
            }
            Dimension dimension = (Dimension) o;
            return Object.Equals(this._internalPair, dimension._internalPair);
        }
    
        public override int GetHashCode()
        {
            var md5Hasher = MD5.Create();
            var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(this.ToString()));
            var ivalue = BitConverter.ToInt32(hashed, 0);
            return ivalue;
        }

        private double Height
        {
            get { return this._internalPair.GetSecond(); }
            set { this._internalPair.SetSecond(value); }
        }
    
        public void IncreaseHeight(double increaseValue)
        {
            this.Height = this.Height + increaseValue;
        }
    
        public void IncreaseWidth(double increaseValue)
        {
            this.Width = this.Width + increaseValue;
        }

        public double GetWidth()
        {
            return this.Width;
        }

        public void SetWidth(double inputWidth)
        {
            this.Width = inputWidth;
        }

        public override string ToString()
        {
            return "Dimension X: " + this._internalPair.GetFirst() + " and Y: " + 
                   this._internalPair.GetSecond();
        }

        private double Width
        {
            get { return this._internalPair.GetFirst(); }
            set { this._internalPair.SetFirst(value); }
        }
    }
}