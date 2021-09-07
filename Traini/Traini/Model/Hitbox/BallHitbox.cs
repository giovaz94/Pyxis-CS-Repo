using System;
using Traini.Model.Element;
using Traini.Model.Util;

namespace Traini.Model.Hitbox
{
    class BallHitbox : AbstractHitbox
    {
        /// <summary>
        /// The Radius of the BallHitbox
        /// </summary>
        private double Radius
        {
            get { return this.Dimension.Height / 2; }
        }
        /// <summary>
        /// The Pace of the BallHitbox
        /// </summary>
        private IVector Pace
        {
            get { return this.Element.Pace; }
        }

        public BallHitbox(IElement element) : base(element)
        {
        }

        /// <summary>
        /// Calculation of the value of the closest point of the
        /// RectHitbox from the center of the BallHitbox
        /// </summary>
        /// <param name="bHbCenterValue"> The value of the center of the BallHitbox</param>
        /// <param name="rHbCenterValue"> The value of the center of the RectHitbox</param>
        /// <param name="rHbEdgeLength"> The length of the edge of the RectHitbox</param>
        /// <returns>bHBCenterValue if the center of the BallHitbox is inside the RectHitbox,
        /// the Coord value of the closest edge of the RectHitbox otherwise</returns>
        private double ClosestPointComponentCalculation(double bHbCenterValue, double rHbCenterValue, double rHbEdgeLength)
        {
            return bHbCenterValue < rHbCenterValue - rHbEdgeLength / 2
                    ? rHbCenterValue - rHbEdgeLength / 2
                    : Math.Min(bHbCenterValue, rHbCenterValue + rHbEdgeLength / 2);
        }

        /// <summary>
        /// Calculates the offset to apply to the hitbox after the collision
        /// </summary>
        /// <param name="distanceFromClosestPoint"> The distance from the closest point of the RectHitbox
        /// to the center of the BallHitbox</param>
        /// <param name="distanceComponent"> The component of the distance from the closest point
        /// of the RectHitbox to the center of the BallHitbox</param>
        /// <returns>The offset to apply to the hitbox after the collision</returns>
        private double CornerOffsetCalculation(double distanceFromClosestPoint, double distanceComponent)
        {
            return (this.Radius - distanceFromClosestPoint) * distanceComponent / this.Radius;
        }

        public override ICollisionInformation CollidingInformationWithHb(IHitbox hitbox)
        {
            return hitbox is BallHitbox
                    ? this.CollidingInformationWithSameHb(hitbox)
                    : this.CollidingInformationWithOtherHb(hitbox);
        }

        public override bool IsCollidingWithPoint(double px, double py)
        {
            return this.Position.Distance(px, py) <= this.Radius;
        }

        protected override ICollisionInformation CollidingInformationWithOtherHb(IHitbox hitbox)
        {
            double closestPointX;
            double closestPointY;
            HitEdge? hitEdge = null;
            IDimension edgeOffset = new Dimension();
            double bHbCenterX = this.Position.X;
            double bHbCenterY = this.Position.Y;
            double rHbCenterX = hitbox.Position.X;
            double rHbCenterY = hitbox.Position.Y;
            double rHbWidth = hitbox.Dimension.Width;
            double rHbHeight = hitbox.Dimension.Height;

            closestPointX = ClosestPointComponentCalculation(bHbCenterX, rHbCenterX, rHbWidth);
            closestPointY = ClosestPointComponentCalculation(bHbCenterY, rHbCenterY, rHbHeight);

            if (closestPointX != bHbCenterX && closestPointY != bHbCenterY)
            {
                double distanceFromClosestPoint = this.Position.Distance(closestPointX, closestPointY);
                edgeOffset.Width = CornerOffsetCalculation(distanceFromClosestPoint, Math.Abs(bHbCenterX - closestPointX));
                edgeOffset.Height = CornerOffsetCalculation(distanceFromClosestPoint, Math.Abs(bHbCenterY - closestPointY));
                if ((bHbCenterX <= rHbCenterX && this.Pace.X > 0) || (bHbCenterX > rHbCenterX && this.Pace.X < 0))
                {
                    hitEdge = HitEdge.Vertical;
                }
                if ((bHbCenterY <= rHbCenterY && this.Pace.Y > 0) || (bHbCenterY > rHbCenterY && this.Pace.Y < 0))
                {
                    hitEdge = !hitEdge.HasValue
                            ? HitEdge.Horizontal
                            : HitEdge.Corner;
                }
            }
            else if (closestPointX != bHbCenterX && closestPointY == bHbCenterY)
            {
                edgeOffset.Width = WidthOffsetCalculation(Math.Abs(bHbCenterX - closestPointX));
                hitEdge = HitEdge.Vertical;
            }
            else if (closestPointX == bHbCenterX && closestPointY != bHbCenterY)
            {
                edgeOffset.Height = HeightOffsetCalculation(Math.Abs(bHbCenterY - closestPointY));
                hitEdge = bHbCenterY > rHbCenterY
                        ? HitEdge.Horizontal
                        : HitEdge.Top;
            }
            else
            {
                if (Math.Min(bHbCenterX, rHbWidth - bHbCenterX) <= Math.Min(bHbCenterY, rHbHeight - bHbCenterY))
                {
                    edgeOffset.Width = WidthOffsetCalculation(Math.Min(bHbCenterX, rHbWidth - bHbCenterX));
                    hitEdge = HitEdge.Vertical;
                }
                else
                {
                    edgeOffset.Height = HeightOffsetCalculation(Math.Min(bHbCenterY, rHbHeight - bHbCenterY));
                    hitEdge = HitEdge.Horizontal;
                }
            }
            return this.IsCollidingWithPoint(closestPointX, closestPointY)
                    ? new CollisionInformation(hitEdge.Value, edgeOffset)
                    : null;
        }

        protected override ICollisionInformation CollidingInformationWithSameHb(IHitbox hitbox)
        {
            return this.Position.Distance(hitbox.Position) <= this.Radius + ((BallHitbox)hitbox).Radius
                    ? new CollisionInformation(HitEdge.Circle, new Dimension())
                    : null;
        }
    }
}
