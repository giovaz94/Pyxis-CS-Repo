using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traini.Model.Hitbox;
using Traini.Model.Util;

namespace Traini.Model.Element.BallElement
{
    class Ball : IBall
    {
        private ICoord _position;
        private IDimension _dimension;
        public int Id { get; set; }
        public BallType Type { get; }

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

        public Ball(ICoord position, IDimension dimension) : this(position, dimension, new Vector())
        {
        }

        public Ball(ICoord position, IDimension dimension, IVector pace) : this(1, BallType.NormalBall, position, dimension, pace)
        {
        }

        public Ball(int id, BallType type, ICoord position, IDimension dimension, IVector pace)
        {
            this.Id = id;
            this.Type = type;
            this.Position = position;
            this.Dimension = dimension;
            this.Pace = pace;
            this.Hitbox = new BallHitbox(this);
        }
    }
}
