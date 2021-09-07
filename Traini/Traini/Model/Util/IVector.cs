using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traini.Model.Util
{
    interface IVector
    {
        /// <summary>
        /// The X value of the vector
        /// </summary>
        double X { get; set; }
        /// <summary>
        /// The Y value of the vector
        /// </summary>
        double Y { get; set; }
    }
}
