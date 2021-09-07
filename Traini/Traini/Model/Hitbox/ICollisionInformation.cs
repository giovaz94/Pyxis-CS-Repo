using Traini.Model.Util;

namespace Traini.Model.Hitbox
{
    interface ICollisionInformation
    {
        /// <summary>
        /// The HitEdge of the collision
        /// </summary>
        HitEdge HitEdge { get; set; }
        /// <summary>
        /// The offset of the collision
        /// </summary>
        IDimension CollisionOffset { get; }
    }
}
