
namespace Traini.Model.Element.PadElement
{
    /// <summary>
    /// Please note that this interface, and the relative implementations, are not my competence
    /// in the project goals.
    /// This is used only for simulating the interactions Level.
    /// </summary>
    public interface IPad : IElement
    {
        /// <summary>
        /// Increases the Width of the Pad
        /// </summary>
        /// <param name="amount">The amount to increase</param>
        void IncreaseWidth(double amount);
    }
}
