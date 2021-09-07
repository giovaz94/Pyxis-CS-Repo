using Traini.Model.Element;
using Traini.Model.Util;

namespace Traini.Model.Hitbox
{
    interface IHitbox
    {
        /// <summary>
        /// The dimension of the hitbox
        /// </summary>
        IDimension Dimension { get; }
        /// <summary>
        /// The Element attached to the hitbox
        /// </summary>
        IElement Element { get; }
        /// <summary>
        /// The Coord of the hitbox
        /// </summary>
        ICoord Position { get; }

        /// <summary>
        /// Checks for a collision with a hitbox
        /// </summary>
        /// <param name="hitbox"> The passed hitbox</param>
        /// <returns>true if they are colliding, false otherwise</returns>
        bool IsCollidingWithHb(IHitbox hitbox);

        /// <summary>
        /// Checks for a collision with a lower border of a dimension
        /// </summary>
        /// <param name="borderDimension"> The passed border dimensions</param>
        /// <returns>true if it's colliding with the lower border, false otherwise</returns>
        bool IsCollidingWithLowerBorder(IDimension borderDimension);

        /// <summary>
        /// Checks for a collision with a point
        /// </summary>
        /// <param name="point"> The passed point</param>
        /// <returns>true if they are colliding, false otherwise</returns>
        bool IsCollidingWithPoint(ICoord point);

        /// <summary>
        /// Checks for a collision with a point
        /// </summary>
        /// <param name="px"> The passed point X value</param>
        /// <param name="py"> The passed point Y value</param>
        /// <returns>true if they are colliding, false otherwise</returns>
        bool IsCollidingWithPoint(double px, double py);

        /// <summary>
        /// Checks for a collision with a border
        /// </summary>
        /// <param name="borderDimension"> The passed border dimensions</param>
        /// <returns>A CollisionInformation with the relative information
        /// if there's a collision, null otherwise</returns>
        ICollisionInformation CollidingInformationWithBorder(IDimension borderDimension);

        /// <summary>
        /// Checks for a collision with a border
        /// </summary>
        /// <param name="hitbox"> The passed border hitbox</param>
        /// <returns>A CollisionInformation with the relative information
        /// if there's a collision, null otherwise</returns>
        ICollisionInformation CollidingInformationWithHb(IHitbox hitbox);
    }
}
