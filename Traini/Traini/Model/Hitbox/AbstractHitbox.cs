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
        private bool CheckBorderCollision(double distanceFromBorder, double collisionDistance)
        {
            return distanceFromBorder <= collisionDistance;
        }
        protected double WidthOffsetCalculation(double distanceFromCenter)
        {
            return this.Dimension.Width / 2 - distanceFromCenter;
        }
        protected double HeightOffsetCalculation(double distanceFromCenter)
        {
            return this.Dimension.Height / 2 - distanceFromCenter;
        }
        protected abstract ICollisionInformation CollidingInformationWithOtherHB(IHitbox hitbox);
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
                hitEdge = HitEdge.VERTICAL;
            }
            else if (CheckBorderCollision(borderWidth - HBCenterX, HBHalvedWidth))
            {
                borderOffset.Width = WidthOffsetCalculation(borderWidth - HBCenterX);
                hitEdge = HitEdge.VERTICAL;
            }
            if (CheckBorderCollision(HBCenterY, HBHalvedHeight))
            {
                borderOffset.Height = HeightOffsetCalculation(HBCenterY);
                hitEdge = !hitEdge.HasValue
                            ? HitEdge.HORIZONTAL
                            : HitEdge.CORNER;
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
        public bool IsCollidingWithPoint(ICoord position)
        {
            return IsCollidingWithPoint(position.X, position.Y);
        }
        public abstract bool IsCollidingWithPoint(double px, double py);
    }
}
