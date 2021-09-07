using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traini.Model.Element
{
    interface IBrick : IElement
    {
        /// <summary>
        /// Checks if the Brick is indestructible
        /// </summary>
        /// <returns>true if it's indestructible, false otherwise</returns>
        bool IsIndestructible();
    }
}
