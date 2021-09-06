using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traini.Model.Element;
using Traini.Model.Util;

namespace Traini.Model.Hitbox
{
    class BallHitbox : AbstractHitbox
    {
        private double Radius
        {
            get { return this.Dimension.Height / 2; }
        }
        private IVector Pace
        {
            get { return this.Element.Pace; }
        }
        public BallHitbox(IElement element) : base(element)
        {
        }
        private double ClosestPointComponentCalculation(double bHBCenterValue, double rHBCenterValue, double rHBEdgeLength)
        {
            return bHBCenterValue < rHBCenterValue - rHBEdgeLength / 2
                    ? rHBCenterValue - rHBEdgeLength / 2
                    : Math.Min(bHBCenterValue, rHBCenterValue + rHBEdgeLength / 2);
        }
        private double CornerOffsetCalculation(double distanceFromClosestPoint, double distanceComponent)
        {
            return (this.Radius - distanceFromClosestPoint) * distanceComponent / this.Radius;
        }
        public override ICollisionInformation CollidingInformationWithHB(IHitbox hitbox)
        {
            return hitbox is BallHitbox
                    ? this.CollidingInformationWithSameHB(hitbox)
                    : this.CollidingInformationWithOtherHB(hitbox);
        }

        public override bool IsCollidingWithPoint(double px, double py)
        {
            return this.Position.Distance(px, py) <= this.Radius;
        }

        protected override ICollisionInformation CollidingInformationWithOtherHB(IHitbox hitbox)
        {
            double closestPointX;
            double closestPointY;
            HitEdge? hitEdge = null;
            IDimension edgeOffset = new Dimension();
            double bHBCenterX = this.Position.X;
            double bHBCenterY = this.Position.Y;
            double rHBCenterX = hitbox.Position.X;
            double rHBCenterY = hitbox.Position.Y;
            double rHBWidth = hitbox.Dimension.Width;
            double rHBHeight = hitbox.Dimension.Height;

            closestPointX = ClosestPointComponentCalculation(bHBCenterX, rHBCenterX, rHBWidth);
            closestPointY = ClosestPointComponentCalculation(bHBCenterY, rHBCenterY, rHBHeight);

            if (closestPointX != bHBCenterX && closestPointY != bHBCenterY)
            {
                double distanceFromClosestPoint = this.Position.Distance(closestPointX, closestPointY);
                edgeOffset.Width = CornerOffsetCalculation(distanceFromClosestPoint, Math.Abs(bHBCenterX - closestPointX));
                edgeOffset.Height = CornerOffsetCalculation(distanceFromClosestPoint, Math.Abs(bHBCenterY - closestPointY));
                if ((bHBCenterX <= rHBCenterX && this.Pace.X > 0) || (bHBCenterX > rHBCenterX && this.Pace.X < 0))
                {
                    hitEdge = HitEdge.VERTICAL;
                }
                if ((bHBCenterY <= rHBCenterY && this.Pace.Y > 0) || (bHBCenterY > rHBCenterY && this.Pace.Y < 0))
                {
                    hitEdge = !hitEdge.HasValue
                            ? HitEdge.HORIZONTAL
                            : HitEdge.CORNER;
                }
            }
            else if (closestPointX != bHBCenterX && closestPointY == bHBCenterY)
            {
                edgeOffset.Width = WidthOffsetCalculation(Math.Abs(bHBCenterX - closestPointX));
                hitEdge = HitEdge.VERTICAL;
            }
            else if (closestPointX == bHBCenterX && closestPointY != bHBCenterY)
            {
                edgeOffset.Height = HeightOffsetCalculation(Math.Abs(bHBCenterY - closestPointY));
                hitEdge = bHBCenterY > rHBCenterY
                        ? HitEdge.HORIZONTAL
                        : HitEdge.TOP;
            }
            else
            {
                if (Math.Min(bHBCenterX, rHBWidth - bHBCenterX) <= Math.Min(bHBCenterY, rHBHeight - bHBCenterY))
                {
                    edgeOffset.Width = WidthOffsetCalculation(Math.Min(bHBCenterX, rHBWidth - bHBCenterX));
                    hitEdge = HitEdge.VERTICAL;
                }
                else
                {
                    edgeOffset.Height = HeightOffsetCalculation(Math.Min(bHBCenterY, rHBHeight - bHBCenterY));
                    hitEdge = HitEdge.HORIZONTAL;
                }
            }
            return this.IsCollidingWithPoint(closestPointX, closestPointY)
                    ? new CollisionInformation(hitEdge.Value, edgeOffset)
                    : null;
        }

        protected override ICollisionInformation CollidingInformationWithSameHB(IHitbox hitbox)
        {
            return this.Position.Distance(hitbox.Position) <= this.Radius + ((BallHitbox)hitbox).Radius
                    ? new CollisionInformation(HitEdge.CIRCLE, new Dimension())
                    : null;
        }
    }
}
