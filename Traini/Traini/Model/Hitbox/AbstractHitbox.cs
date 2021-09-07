using Traini.Model.Element;
using Traini.Model.Util;

namespace Traini.Model.Hitbox
{
    public abstract class AbstractHitbox : IHitbox
    {
        public IElement Element { get; }

        public IDimension Dimension
        {
            get { return this.Element.Dimension; }
        }

        public ICoord Position
        {
            get { return this.Element.Position; }
        }

        public AbstractHitbox(IElement element)
        {
            this.Element = element;
        }

        /// <summary>
        /// Checks if the distance form the border is small enough
        /// to have a collision
        /// </summary>
        /// <param name="distanceFromBorder"> The passed border distance from the border</param>
        /// <param name="collisionDistance"> The passed distance from the colliding point</param>
        /// <returns>A true if there's a collision, false otherwise</returns>
        private bool CheckBorderCollision(double distanceFromBorder, double collisionDistance)
        {
            return distanceFromBorder <= collisionDistance;
        }

        /// <summary>
        /// Calculates the offset to apply to the hitbox after the collision
        /// </summary>
        /// <param name="distanceFromCenter"> The passed distance from the center of the hitbox</param>
        /// <returns>The offset to apply to the hitbox after the collision</returns>
        protected double WidthOffsetCalculation(double distanceFromCenter)
        {
            return this.Dimension.Width / 2 - distanceFromCenter;
        }

        /// <summary>
        /// Calculates the offset to apply to the hitbox after the collision
        /// </summary>
        /// <param name="distanceFromCenter"> The passed distance from the center of the hitbox</param>
        /// <returns>The offset to apply to the hitbox after the collision</returns>
        protected double HeightOffsetCalculation(double distanceFromCenter)
        {
            return this.Dimension.Height / 2 - distanceFromCenter;
        }

        /// <summary>
        /// Checks for a collision with the different hitbox
        /// </summary>
        /// <param name="hitbox"> The passed hitbox</param>
        /// <returns>A CollisionInformation with the relative information
        /// if there's a collision, null otherwise</returns>
        protected abstract ICollisionInformation CollidingInformationWithOtherHb(IHitbox hitbox);

        /// <summary>
        /// Checks for a collision with the same hitbox
        /// </summary>
        /// <param name="hitbox"> The passed hitbox</param>
        /// <returns>A CollisionInformation with the relative information
        /// if there's a collision, null otherwise</returns>
        protected abstract ICollisionInformation CollidingInformationWithSameHb(IHitbox hitbox);

        public ICollisionInformation CollidingInformationWithBorder(IDimension borderDimension)
        {
            double hbCenterX = this.Position.X;
            double hbCenterY = this.Position.Y;
            double hbHalvedWidth = this.Dimension.Width / 2;
            double hbHalvedHeight = this.Dimension.Height / 2;
            double borderWidth = borderDimension.Width;
            HitEdge? hitEdge = null;
            IDimension borderOffset = new Dimension();

            if (CheckBorderCollision(hbCenterX, hbHalvedWidth))
            {
                borderOffset.Width = WidthOffsetCalculation(hbCenterX);
                hitEdge = HitEdge.Vertical;
            }
            else if (CheckBorderCollision(borderWidth - hbCenterX, hbHalvedWidth))
            {
                borderOffset.Width = WidthOffsetCalculation(borderWidth - hbCenterX);
                hitEdge = HitEdge.Vertical;
            }
            if (CheckBorderCollision(hbCenterY, hbHalvedHeight))
            {
                borderOffset.Height = HeightOffsetCalculation(hbCenterY);
                hitEdge = !hitEdge.HasValue
                            ? HitEdge.Horizontal
                            : HitEdge.Corner;
            }
            return hitEdge.HasValue
                    ? new CollisionInformation(hitEdge.Value, borderOffset)
                    : null;
        }

        public bool IsCollidingWithLowerBorder(IDimension borderDimension)
        {
            return CheckBorderCollision(borderDimension.Height - this.Position.Y, this.Dimension.Height / 2);
        }

        public abstract ICollisionInformation CollidingInformationWithHb(IHitbox hitbox);

        public bool IsCollidingWithHb(IHitbox hitbox)
        {
            return this.CollidingInformationWithHb(hitbox) != null;
        }

        public bool IsCollidingWithPoint(ICoord point)
        {
            return IsCollidingWithPoint(point.X, point.Y);
        }

        public abstract bool IsCollidingWithPoint(double px, double py);
    }
}
