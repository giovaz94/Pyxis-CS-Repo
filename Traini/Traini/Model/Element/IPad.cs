﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traini.Model.Element
{
    interface IPad : IElement
    {
        void IncreaseWidth(double amount);
    }
}
