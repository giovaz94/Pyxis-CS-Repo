using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traini.Model.Util;

namespace Traini.Model.Element
{
    interface IElementFactory
    {
        IBall createBallWithRandomAngle(int id, BallType type, ICoord position, double module);
    }
}
