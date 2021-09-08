namespace OOP_Rubboli.util
{
    public interface ICoord
    {
        /// <summary>
        /// Returns a copy of the Coord.
        /// </summary>
        /// <returns>
        /// The Coord.
        /// </returns>
        Coord CopyOf();

        /// <summary>
        /// Returns the distance with the specified Coord.
        /// </summary>
        /// <param name="coord">
        /// The {@link Coord}.
        /// </param>
        /// <returns>
        /// The distance with the specified {@link Coord}.
        /// </returns>
        double Distance(Coord coord);

        /// <summary>
        /// Returns the distance with the specified Coord in its value form.
        /// </summary>
        /// <param name="px">
        /// The X value of the Coord.
        /// </param>
        /// <param name="py">
        /// The Y value of the Coord.
        /// </param>
        /// <returns>
        /// The distance with the specified {@link Coord}.
        /// </returns>
        double Distance(double px, double py);

        /// <summary>
        /// Sets the X and Y value.
        /// </summary>
        /// <param name="xValue">
        /// The X value to set.
        /// </param>
        /// <param name="yValue">
        /// The Y value to set.
        /// </param>
        void SetXy(double xValue, double yValue);

        /// <summary>
        /// Sums the X and Y values of of the input Coord.
        /// </summary>
        /// <param name="coord">
        /// The input Coord to add components.
        /// </param>
        void SumCoord(Coord coord);

        /// <summary>
        /// Sums the xValue and the yValue to the internal values of the Coord.
        /// </summary>
        /// <param name="xValue">
        /// The X value of the Coord to sum.
        /// </param>
        /// <param name="yValue">
        /// The Y value of the Coord to sum.
        /// </param>
        void SumValues(double xValue, double yValue);

        /// <summary>
        /// Sums the X and Y components of the Vector to the X and Y values of a Coord.
        /// </summary>
        /// <param name="vector">
        /// The Vector to sum.
        /// </param>
        void SumVector(Vector vector);

        /// <summary>
        /// Sums the X and Y components of a Vector, multiplied by a certain value,
        /// to the X and Y values of the Coord.
        /// </summary>
        /// <param name="vector">
        /// The Vector to sum.
        /// </param>
        /// <param name="multiplier">
        /// The multiplier value.
        /// </param>
        void SumVector(Vector vector, double multiplier);

        /// <summary>
        /// Sums the xValue to the internal X value of the Coord.
        /// </summary>
        /// <param name="xValue">
        /// The value to sum.
        /// </param>
        void SumXValue(double xValue);

        /// <summary>
        /// Sums the yValue to the internal Y value of the Coord.
        /// </summary>
        /// <param name="yValue">
        /// The value to sum.
        /// </param>
        void SumYValue(double yValue);

        /// <summary>
        /// Returns and sets the X value.
        /// </summary>
        double X
        {
            get;
            set;
        }
        
        /// <summary>
        /// Returns and sets the Y value.
        /// </summary>
        double Y
        {
            get;
            set;
        }
    }
}