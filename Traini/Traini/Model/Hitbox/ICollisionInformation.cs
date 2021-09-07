using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traini.Model.Util;

namespace Traini.Model.Hitbox
{
    interface ICollisionInformation
    {
        /// <summary>
        /// The HitEdge of the collision
        /// </summary>
        HitEdge HitEdge { get; set; }
        /// <summary>
        /// The offset of the collision
        /// </summary>
        IDimension CollisionOffset { get; }
    }
}
