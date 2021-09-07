using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traini.Model.Hitbox;
using Traini.Model.Util;

namespace Traini.Model.Element.Pad
{
    class Pad : IPad
    {
        public ICoord Position
        {
            get { return this.Position.CopyOf(); }
            set { this.Position = value; }
        }

        public IDimension Dimension
        {
            get { return this.Dimension.CopyOf(); }
            set { this.Dimension = value; }
        }

        public IHitbox Hitbox { get; }

        public IVector Pace { get; set; }

        public Pad(ICoord position, IDimension dimension)
        {
            this.Position = position;
            this.Dimension = dimension;
            this.Pace = new Vector();
            this.Hitbox = new RectHitbox(this);
        }

        public void IncreaseWidth(double amount)
        {
            var newDimension = this.Dimension;
            newDimension.IncreaseWidth(amount);
            this.Dimension = newDimension;
        }
    }
}
