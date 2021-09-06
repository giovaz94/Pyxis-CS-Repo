using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traini.Model.Util;
using Traini.Model.Element;

namespace Traini.Model.Hitbox
{
    interface IHitbox
    {
        IDimension Dimension { get; }
        IElement Element { get; }
        ICoord Position { get; }
        bool IsCollidingWithHB(IHitbox hitbox);
        bool IsCollidingWithLowerBorder(IDimension borderDimension);
        bool IsCollidingWithPoint(ICoord position);
        bool IsCollidingWithPoint(double px, double py);
        ICollisionInformation? CollidingInformationWithBorder(IDimension borderDimension);
        ICollisionInformation? CollidingInformationWithHB(IHitbox hitbox);
    }
}
