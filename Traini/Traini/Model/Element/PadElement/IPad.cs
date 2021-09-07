
namespace Traini.Model.Element.PadElement
{
    interface IPad : IElement
    {
        /// <summary>
        /// Increases the Width of the Pad
        /// </summary>
        /// <param name="amount">The amount to increase</param>
        void IncreaseWidth(double amount);
    }
}
