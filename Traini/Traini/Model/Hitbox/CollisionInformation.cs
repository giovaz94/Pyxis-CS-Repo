using Traini.Model.Util;

namespace Traini.Model.Hitbox
{
    public class CollisionInformation : ICollisionInformation
    {
        public HitEdge HitEdge { get; set; }
        public IDimension CollisionOffset { get; }

        public CollisionInformation(HitEdge hitEdge, IDimension collisionOffset)
        {
            this.HitEdge = hitEdge;
            this.CollisionOffset = collisionOffset;
        }
    }
}
