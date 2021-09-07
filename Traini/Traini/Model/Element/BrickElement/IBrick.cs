
namespace Traini.Model.Element.BrickElement
{
    /// <summary>
    /// Please note that this interface, and the relative implementations, are not my competence
    /// in the project goals.
    /// This is used only for simulating the interactions Arena and Hitbox.
    /// </summary>
    public interface IBrick : IElement
    {
        /// <summary>
        /// Checks if the Brick is indestructible
        /// </summary>
        /// <returns>true if it's indestructible, false otherwise</returns>
        bool IsIndestructible();
    }
}
