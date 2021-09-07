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

        public Dimension(IDimension dimension) : this(dimension.Width, dimension.Height)
        {
        }

        public Dimension(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public IDimension CopyOf()
        {
            return new Dimension(this);
        }

        public void IncreaseWidth(double amount)
        {
            this.Width += amount;
        }
    }
}
