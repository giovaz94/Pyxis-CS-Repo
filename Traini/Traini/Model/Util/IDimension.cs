using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traini.Model.Util
{
    interface IDimension
    {
        double Width { get; set; }
        double Height { get; set; }
        IDimension CopyOf();
        void IncreaseWidth(double amount);
    }
}
