﻿using System;
using Traini.Model.Element;
using Traini.Model.Util;

namespace Traini.Model.Hitbox
{
    class RectHitbox : AbstractHitbox
    {
        public RectHitbox(IElement element) : base(element)
        {
        }

        /// <summary>
        /// Calculation of the value of the closest point of the
        /// RectHitbox from the center of the BallHitbox
        /// </summary>
        /// <param name="fHbCenterValue"> The value of the center of the first RectHitbox</param>
        /// <param name="sHbCenterValue"> The value of the center of the second RectHitbox</param>
        /// <param name="rHbEdgeLength"> The length of the edge of the RectHitbox</param>
        /// <returns>bHBCenterValue if the center of the BallHitbox is inside the RectHitbox,
        /// the Coord value of the closest edge of the RectHitbox otherwise</returns>
        private double ClosestPointComponentCalculation(double sHbCenterValue, double fHbCenterValue, double rHbEdgeLength)
        {
            return sHbCenterValue < fHbCenterValue - rHbEdgeLength / 2
                    ? fHbCenterValue - rHbEdgeLength / 2
                    : Math.Min(sHbCenterValue, fHbCenterValue + rHbEdgeLength / 2);
        }

        public override ICollisionInformation CollidingInformationWithHb(IHitbox hitbox)
        {
            return hitbox is RectHitbox
                    ? this.CollidingInformationWithSameHb(hitbox)
                    : this.CollidingInformationWithOtherHb(hitbox);
        }

        public override bool IsCollidingWithPoint(double px, double py)
        {
            return Math.Abs(px - this.Position.X) <= this.Dimension.Width / 2
                    && Math.Abs(py - this.Position.Y) <= this.Dimension.Height / 2;
        }

        protected override ICollisionInformation CollidingInformationWithSameHb(IHitbox hitbox)
        {
            double closestPointX;
            double closestPointY;
            HitEdge hitEdge;
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
                edgeOffset.Width = WidthOffsetCalculation(Math.Abs(bHbCenterX - closestPointX));
                edgeOffset.Height = HeightOffsetCalculation(Math.Abs(bHbCenterY - closestPointY));
                hitEdge = HitEdge.Corner;
            }
            else if (closestPointX != bHbCenterX && closestPointY == bHbCenterY)
            {
                edgeOffset.Width = WidthOffsetCalculation(Math.Abs(bHbCenterX - closestPointX));
                hitEdge = HitEdge.Vertical;
            }
            else if (closestPointX == bHbCenterX && closestPointY != bHbCenterY)
            {
                edgeOffset.Height = HeightOffsetCalculation(Math.Abs(bHbCenterY - closestPointY));
                hitEdge = HitEdge.Horizontal;
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
            return IsCollidingWithPoint(closestPointX, closestPointY)
                    ? new CollisionInformation(hitEdge, edgeOffset)
                    : null;
        }

        protected override ICollisionInformation CollidingInformationWithOtherHb(IHitbox hitbox)
        {
            return !(hitbox is RectHitbox)
                    ? hitbox.CollidingInformationWithHb(this)
                    : null;
        }
    }
}
