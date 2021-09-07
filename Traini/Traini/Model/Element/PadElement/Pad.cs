using Traini.Model.Hitbox;
using Traini.Model.Util;

namespace Traini.Model.Element.PadElement
{
    class Pad : IPad
    {
        private ICoord _position;
        private IDimension _dimension;
        public ICoord Position
        {
            get { return this._position.CopyOf(); }
            set { this._position = value; }
        }

        public IDimension Dimension
        {
            get { return this._dimension.CopyOf(); }
            set { this._dimension = value; }
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
