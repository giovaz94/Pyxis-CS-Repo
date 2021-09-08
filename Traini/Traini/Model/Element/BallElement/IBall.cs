
namespace Traini.Model.Element.BallElement
{
    /// <summary>
    /// Please note that this interface, and the relative implementations, are not my competence
    /// in the project goals.
    /// This is used only for simulating the interactions Arena and Hitbox.
    /// </summary>
    public interface IBall : IElement
    {
        /// <summary>
        /// The id of the Ball
        /// </summary>
        int Id { get; set; }
        /// <summary>
        /// The type of the Ball
        /// </summary>
        BallType Type { get; }
    }
}
