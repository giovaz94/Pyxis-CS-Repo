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

        public Ball(int id, BallType type, ICoord position, IVector pace)
        {
            this.Id = id;
            this.Type = type;
            this.Position = position;
            this.Pace = pace;
            this.Hitbox = new BallHitbox(this);
        }
    }
}
