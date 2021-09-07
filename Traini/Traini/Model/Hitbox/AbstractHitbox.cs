using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traini.Model.Element;
using Traini.Model.Util;

namespace Traini.Model.Hitbox
{
    abstract class AbstractHitbox : IHitbox
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
        protected abstract ICollisionInformation CollidingInformationWithOtherHB(IHitbox hitbox);

        /// <summary>
        /// Checks for a collision with the same hitbox
        /// </summary>
        /// <param name="hitbox"> The passed hitbox</param>
        /// <returns>A CollisionInformation with the relative information
        /// if there's a collision, null otherwise</returns>
        protected abstract ICollisionInformation CollidingInformationWithSameHB(IHitbox hitbox);

        public ICollisionInformation CollidingInformationWithBorder(IDimension borderDimension)
        {
            double HBCenterX = this.Position.X;
            double HBCenterY = this.Position.Y;
            double HBHalvedWidth = this.Dimension.Width / 2;
            double HBHalvedHeight = this.Dimension.Height / 2;
            double borderWidth = borderDimension.Width;
            HitEdge? hitEdge = null;
            IDimension borderOffset = new Dimension();

            if (CheckBorderCollision(HBCenterX, HBHalvedWidth))
            {
                borderOffset.Width = WidthOffsetCalculation(HBCenterX);
                hitEdge = HitEdge.Vertical;
            }
            else if (CheckBorderCollision(borderWidth - HBCenterX, HBHalvedWidth))
            {
                borderOffset.Width = WidthOffsetCalculation(borderWidth - HBCenterX);
                hitEdge = HitEdge.Vertical;
            }
            if (CheckBorderCollision(HBCenterY, HBHalvedHeight))
            {
                borderOffset.Height = HeightOffsetCalculation(HBCenterY);
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

        public abstract ICollisionInformation CollidingInformationWithHB(IHitbox hitbox);

        public bool IsCollidingWithHB(IHitbox hitbox)
        {
            return this.CollidingInformationWithHB(hitbox) != null;
        }

        public bool IsCollidingWithPoint(ICoord point)
        {
            return IsCollidingWithPoint(point.X, point.Y);
        }

        public abstract bool IsCollidingWithPoint(double px, double py);
    }
}
