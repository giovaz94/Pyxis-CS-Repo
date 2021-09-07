using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traini.Model.Element;
using Traini.Model.Util;

namespace Traini.Model.Hitbox
{
    class RectHitbox : AbstractHitbox
    {
        public RectHitbox(IElement element) : base(element)
        {
        }

        private double ClosestPointComponentCalculation(double sHBCenterValue, double fHBCenterValue, double rHBEdgeLength)
        {
            return sHBCenterValue < fHBCenterValue - rHBEdgeLength / 2
                    ? fHBCenterValue - rHBEdgeLength / 2
                    : Math.Min(sHBCenterValue, fHBCenterValue + rHBEdgeLength / 2);
        }

        public override ICollisionInformation CollidingInformationWithHB(IHitbox hitbox)
        {
            return hitbox is RectHitbox
                    ? this.CollidingInformationWithSameHB(hitbox)
                    : this.CollidingInformationWithOtherHB(hitbox);
        }

        public override bool IsCollidingWithPoint(double px, double py)
        {
            return Math.Abs(px - this.Position.X) <= this.Dimension.Width / 2
                    && Math.Abs(py - this.Position.Y) <= this.Dimension.Height / 2;
        }

        protected override ICollisionInformation CollidingInformationWithSameHB(IHitbox hitbox)
        {
            double closestPointX;
            double closestPointY;
            HitEdge hitEdge;
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
                edgeOffset.Width = WidthOffsetCalculation(Math.Abs(bHBCenterX - closestPointX));
                edgeOffset.Height = HeightOffsetCalculation(Math.Abs(bHBCenterY - closestPointY));
                hitEdge = HitEdge.Corner;
            }
            else if (closestPointX != bHBCenterX && closestPointY == bHBCenterY)
            {
                edgeOffset.Width = WidthOffsetCalculation(Math.Abs(bHBCenterX - closestPointX));
                hitEdge = HitEdge.Vertical;
            }
            else if (closestPointX == bHBCenterX && closestPointY != bHBCenterY)
            {
                edgeOffset.Height = HeightOffsetCalculation(Math.Abs(bHBCenterY - closestPointY));
                hitEdge = HitEdge.Horizontal;
            }
            else
            {
                if (Math.Min(bHBCenterX, rHBWidth - bHBCenterX) <= Math.Min(bHBCenterY, rHBHeight - bHBCenterY))
                {
                    edgeOffset.Width = WidthOffsetCalculation(Math.Min(bHBCenterX, rHBWidth - bHBCenterX));
                    hitEdge = HitEdge.Vertical;
                }
                else
                {
                    edgeOffset.Height = HeightOffsetCalculation(Math.Min(bHBCenterY, rHBHeight - bHBCenterY));
                    hitEdge = HitEdge.Horizontal;
                }
            }
            return IsCollidingWithPoint(closestPointX, closestPointY)
                    ? new CollisionInformation(hitEdge, edgeOffset)
                    : null;
        }

        protected override ICollisionInformation CollidingInformationWithOtherHB(IHitbox hitbox)
        {
            return !(hitbox is RectHitbox)
                    ? hitbox.CollidingInformationWithHB(this)
                    : null;
        }
    }
}
