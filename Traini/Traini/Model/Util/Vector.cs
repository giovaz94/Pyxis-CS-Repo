using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traini.Model.Util
{
    class Vector : IVector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Vector() : this(0, 0)
        {
        }
        public Vector(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
