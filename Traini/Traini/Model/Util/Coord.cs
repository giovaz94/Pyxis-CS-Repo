using System;

namespace Traini.Model.Util
{
    public class Coord : ICoord
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Coord() : this(0, 0)
        {
        }

        public Coord(ICoord coord) : this(coord.X, coord.Y)
        {
        }

        public Coord(double xCoord, double yCoord)
        {
            this.X = xCoord;
            this.Y = yCoord;
        }

        public double Distance(ICoord coord)
        {
            return this.Distance(coord.X, coord.Y);
        }

        public double Distance(double x, double y)
        {
            var px = x - this.X;
            var py = y - this.Y;
            return Math.Sqrt(px * px + py * py);
        }

        public void SumXValue(double dx)
        {
            this.X += dx;
        }

        public ICoord CopyOf()
        {
            return new Coord(this);
        }
    }
}
