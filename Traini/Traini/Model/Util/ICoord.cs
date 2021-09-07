
namespace Traini.Model.Util
{
    public interface ICoord
    {
        /// <summary>
        /// The X value of the Coord
        /// </summary>
        double X { get; set; }
        /// <summary>
        /// The Y value of the Coord
        /// </summary>
        double Y { get; set; }

        /// <summary>
        /// Calculates the distance with a Coord
        /// </summary>
        /// <param name="coord">The second Coord</param>
        /// <returns>The distance between the two Coords</returns>
        double Distance(ICoord coord);

        /// <summary>
        /// Calculates the distance with a Coord in component form
        /// </summary>
        /// <param name="px">The X component of the second Coord</param>
        /// <param name="py">The Y component of the second Coord</param>
        /// <returns>The distance between the two Coords</returns>
        double Distance(double px, double py);

        /// <summary>
        /// Sums an amount dx to the X value of the Coord
        /// </summary>
        /// <param name="dx">The amount to sum</param>
        void SumXValue(double dx);

        /// <summary>
        /// Returns a copy of the Coord
        /// </summary>
        ICoord CopyOf();
    }
}
