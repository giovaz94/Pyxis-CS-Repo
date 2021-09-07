
namespace Traini.Model.Element.BrickElement
{
    public interface IBrick : IElement
    {
        /// <summary>
        /// Checks if the Brick is indestructible
        /// </summary>
        /// <returns>true if it's indestructible, false otherwise</returns>
        bool IsIndestructible();
    }
}
