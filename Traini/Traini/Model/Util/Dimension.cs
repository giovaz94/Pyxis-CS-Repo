using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traini.Model.Util
{
    class Dimension : IDimension
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Dimension() : this(0, 0)
        {
        }
        public Dimension(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
