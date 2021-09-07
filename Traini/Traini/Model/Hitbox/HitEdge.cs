
namespace Traini.Model.Hitbox
{
    enum HitEdge
    {
        /// <summary>
        /// Collision between two BallHitboxes
        /// </summary>
        Circle,
        /// <summary>
        /// Collision between a BallHitbox
        /// and the corner of a RectHitbox or of a border
        /// </summary>
        Corner,
        /// <summary>
        /// Collision between a Ballhitbox
        /// and the horizontal edge of a RectHitbox
        /// </summary>
        Horizontal,
        /// <summary>
        /// Collision between a BallHitbox
        /// and the top edge of a RectHitbox
        /// </summary>
        Top,
        /// <summary>
        /// Collision between a Ballhitbox
        /// and the vertical edge of a RectHitbox
        /// </summary>
        Vertical
    }
}
