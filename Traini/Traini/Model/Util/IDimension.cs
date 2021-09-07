
namespace Traini.Model.Util
{
    interface IDimension
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
    }
}
