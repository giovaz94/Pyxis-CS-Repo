using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traini.Model.Util;

namespace Traini.Model.Hitbox
{
    class CollisionInformation : ICollisionInformation
    {
        public HitEdge HitEdge { get; set; }
        public IDimension CollisionOffset { get; }

        public CollisionInformation(HitEdge hitEdge, IDimension collisionOffset)
        {
            this.HitEdge = hitEdge;
            this.CollisionOffset = collisionOffset;
        }
    }
}
