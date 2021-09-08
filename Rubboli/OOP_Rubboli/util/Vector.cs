using System;
using System.Security.Cryptography;
using System.Text;

namespace OOP_Rubboli.util
{
    public class Vector : IVector
    {
        private Pair<double, double> _components;

        public Vector(Pair<double, double> initialComponents)
        {
            this._components = initialComponents;
        }
        public Vector(double x, double y) : this(new Pair<double, double>(x, y))
        {
        }

        public Vector CopyOf()
        {
            double firstComponent = this._components.GetFirst();
            double secondComponent = this._components.GetSecond();
            return new Vector(firstComponent, secondComponent);
        }

        public override bool Equals(Object o)
        {
            if (this == o)
            {
                return true;
            }
            if (!(o is Vector))
            {
                return false;
            }
            Vector vector = (Vector) o;
            return Object.Equals(this._components, vector._components);
        }
    
        public double GetModule()
        {
            return Math.Sqrt(Math.Pow(this._components.GetFirst(), 2)
                    + Math.Pow(this._components.GetSecond(), 2));
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

        public override int GetHashCode()
        {
            var md5Hasher = MD5.Create();
            var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(this._components.ToString()));
            var ivalue = BitConverter.ToInt32(hashed, 0);
            return ivalue;
        }
    
        public Vector CreateVectorWithSameModule(double rotationAngle)
        {
            double cos = Math.Cos(rotationAngle);
            double sin = Math.Sin(rotationAngle);
            double module = this.GetModule();
            return new Vector(module * cos, module * sin);
        }

        private double X
        {
            get { return this._components.GetFirst(); }
            set { this._components.SetFirst(value); }
        }

        private double Y
        {
            get { return this._components.GetSecond(); }
            set { this._components.SetSecond(value); }
        }
    }
}