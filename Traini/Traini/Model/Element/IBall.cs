using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traini.Model.Element
{
    interface IBall : IElement
    {
        int Id { get; set; }
        BallType Type { get; }
    }
}
