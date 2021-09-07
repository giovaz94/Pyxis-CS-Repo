using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traini.Model.Hitbox;
using Traini.Model.Util;

namespace Traini.Model.Element
{
    class Ball : IBall
    {
        public int Id { get; set; }
        public BallType Type { get; }

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
