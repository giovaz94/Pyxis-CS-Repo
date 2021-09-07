using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traini.Model.Util;

namespace Traini.Model.Element
{
    class ElementFactory : IElementFactory
    {
        private static int FLAT_ANGLE = 180;
        private static IDimension RANDOM_BALL_DIMENSION = new Dimension(10, 10);

        public IBall createBallWithRandomAngle(int id, BallType type, ICoord position, double module)
        {
            var randomAngleInRad = new Random().Next(FLAT_ANGLE) * Math.PI / FLAT_ANGLE;
            var randomVector = new Vector(module * Math.Cos(randomAngleInRad), module * Math.Sin(randomAngleInRad));
            return new Ball(id, type, position, RANDOM_BALL_DIMENSION, randomVector);
        }
    }
}
