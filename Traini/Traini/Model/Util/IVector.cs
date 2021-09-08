
namespace Traini.Model.Util
{
    /// <summary>
    /// Please note that this interface, and the relative implementations, are not my competence
    /// in the project goals.
    /// This is used only for simulating the interactions Arena and Hitbox.
    /// </summary>
    public interface IVector
    {
        /// <summary>
        /// The X value of the vector
        /// </summary>
        double X { get; set; }
        /// <summary>
        /// The Y value of the vector
        /// </summary>
        double Y { get; set; }
    }
}
