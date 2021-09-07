﻿using System;
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
        /// <summary>
        /// The position of the Element
        /// </summary>
        ICoord Position { get; set; }
        /// <summary>
        /// The Dimension of the Element
        /// </summary>
        IDimension Dimension { get; set; }
        /// <summary>
        /// The Hitbox of the Element
        /// </summary>
        IHitbox Hitbox { get; }
        /// <summary>
        /// The Pace of the Element
        /// </summary>
        IVector Pace { get; set; }
    }
}