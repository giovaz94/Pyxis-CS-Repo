using Traini.Model.Hitbox;
using Traini.Model.Util;

namespace Traini.Model.Element
{
    /// <summary>
    /// Please note that this interface, and the relative implementations, are not my competence
    /// in the project goals.
    /// This is used only for simulating the interactions Arena and Hitbox.
    /// </summary>
    public interface IElement
    {
        /// <summary>
        /// The position of the Element
        /// </summary>
        ICoord Position { get; set; }
        /// <summary>
        /// The Dimension of the Element
        /// </summary>
        IDimension Dimension { get; set; }
        /// <summary>
        /// The Hitbox of the Element
        /// </summary>
        IHitbox Hitbox { get; }
        /// <summary>
        /// The Pace of the Element
        /// </summary>
        IVector Pace { get; set; }
    }
}
