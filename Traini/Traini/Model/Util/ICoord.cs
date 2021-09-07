using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traini.Model.Util
{
    interface ICoord
    {
        double X { get; set; }
        double Y { get; set; }
        double Distance(ICoord coord);
        double Distance(double px, double py);
        void SumXValue(double dx);
        ICoord CopyOf();
    }
}
