using Traini.Model.Element.BallElement;
using Traini.Model.Util;

namespace Traini.Model.Element
{
    /// <summary>
    /// Please note that this interface, and the relative implementations, are not my competence
    /// in the project goals.
    /// This is used only for simulating the interactions Arena and Hitbox.
    /// </summary>
    public interface IElementFactory
    {
        /// <summary>
        /// Creates a Ball with a random angled pace
        /// </summary>
        /// <param name="id">The id of the Ball</param>
        /// <param name="type">The type of the Ball</param>
        /// <param name="position">The position of the Ball</param>
        /// <param name="module">The module of the pace of the Ball</param>
        /// <returns>A Ball with a random angled pace</returns>
        IBall CreateBallWithRandomAngle(int id, BallType type, ICoord position, double module);
    }
}
