using System;
using Traini.Model.Element.BallElement;
using Traini.Model.Util;

namespace Traini.Model.Element
{
    public class ElementFactory : IElementFactory
    {
        private static int FLAT_ANGLE = 180;
        private static IDimension RANDOM_BALL_DIMENSION = new Dimension(10, 10);

        public IBall CreateBallWithRandomAngle(int id, BallType type, ICoord position, double module)
        {
            var randomAngleInRad = new Random().Next(FLAT_ANGLE) * Math.PI / FLAT_ANGLE;
            var randomVector = new Vector(module * Math.Cos(randomAngleInRad), module * Math.Sin(randomAngleInRad));
            return new Ball(id, type, position, RANDOM_BALL_DIMENSION, randomVector);
        }
    }
}
