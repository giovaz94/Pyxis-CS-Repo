using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traini.Model.Element.BallElement
{
    interface IBall : IElement
    {
        /// <summary>
        /// The id of the Ball
        /// </summary>
        int Id { get; set; }
        /// <summary>
        /// The type of the Ball
        /// </summary>
        BallType Type { get; }
    }
}
