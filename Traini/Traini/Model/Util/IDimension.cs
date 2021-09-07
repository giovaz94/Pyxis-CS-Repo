
namespace Traini.Model.Util
{
    public interface IDimension
    {
        double Width { get; set; }
        double Height { get; set; }

        /// <summary>
        /// Returns a copy of the dimension
        /// </summary>
        IDimension CopyOf();

        /// <summary>
        /// Increases the Width component of the dimension
        /// by an amount
        /// </summary>
        /// <param name="amount">The amount to add to the Width</param>
        void IncreaseWidth(double amount);

        /// <summary>
        /// Checks if two Dimension are equal
        /// </summary>
        /// <param name="dimension">The Dimension to Compare</param>
        /// <returns>true if they have the same values, false otherwise</returns>
        bool Equals(IDimension dimension);
    }
}
