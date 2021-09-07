using System;
using System.Security.Cryptography;
using System.Text;

namespace OOP_Rubboli.util
{
    public class Dimension
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

        public double Height
        {
            get { return this._internalPair.Second; }
            set { this._internalPair.Second = value; }
        }
    
        public void IncreaseHeight(double increaseValue)
        {
            this.Height = this.Height + increaseValue;
        }
    
        public void IncreaseWidth(double increaseValue)
        {
            this.Width = this.Width + increaseValue;
        }
    
        public override string ToString()
        {
            return "Dimension X: " + this._internalPair.First + " and Y: " + this._internalPair.Second;
        }

        public double Width
        {
            get { return this._internalPair.First; }
            set { this._internalPair.First = value; }
        }
    }
}