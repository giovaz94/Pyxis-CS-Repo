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
        HitEdge HitEdge { get; set; }
        IDimension CollisionOffset { get; }
    }
}
