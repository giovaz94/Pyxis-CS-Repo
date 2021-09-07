using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traini.Model.Util;
using Traini.Model.Hitbox;

namespace Traini.Model.Element
{
    interface IElement
    {
        ICoord Position { get; set; }
        IDimension Dimension { get; set; }
        IHitbox Hitbox { get; }
        IVector Pace { get; set; }
    }
}
