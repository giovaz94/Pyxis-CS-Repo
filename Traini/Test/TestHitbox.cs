using NUnit.Framework;
using NUnit.Framework.Constraints;
using Traini.Model.Element.BallElement;
using Traini.Model.Element.PadElement;
using Traini.Model.Hitbox;
using Traini.Model.Util;

namespace Test
{
    public class TestHitbox
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCollidingWithPoint()
        {
            var coord = new Coord(10, 10);
            var dimension = new Dimension(3, 5);
            var rectBox = new Pad(coord, dimension).Hitbox;
            Assert.True(rectBox.IsCollidingWithPoint(new Coord(11, 8)));
            Assert.True(rectBox.IsCollidingWithPoint(new Coord(11.5, 7.5)));
            Assert.False(rectBox.IsCollidingWithPoint(new Coord(11.6, 7.5)));
            Assert.False(rectBox.IsCollidingWithPoint(new Coord(11, 7)));
        }

        [Test]
        public void TestCollidingWithHb()
        {
            var coord1 = new Coord(10, 10);
            var coord2 = new Coord(10, 11);
            var coord3 = new Coord(10, 1);

            var dimension1 = new Dimension(3,5);
            var dimension2 = new Dimension(2,1);

            var rectHb = new Pad(coord1, dimension1).Hitbox;
            var rectHbToHit = new Pad(coord2, dimension2).Hitbox;
            var rectHbToMiss = new Pad(coord3, dimension2).Hitbox;

            Assert.True(rectHb.IsCollidingWithHb(rectHbToHit));
            Assert.False(rectHb.IsCollidingWithHb(rectHbToMiss));
        }

        [Test]
        public void TestCollidingInformationWithHb()
        {
            var coord1 = new Coord(10, 10);
            var coord2 = new Coord(15, 17);
            var coord3 = new Coord(15.5, 10);
            var coord4 = new Coord(10, 19.5);
            var coord5 = new Coord(7, 15);
            var coord6 = new Coord(11, 3);
            var coord7 = new Coord(17.5, 17.5);

            var dimension1 = new Dimension(3, 5);
            var dimension2 = new Dimension(9, 10);
            var ballDimension = new Dimension(14, 14);

            var rectHb = new Pad(coord1, dimension1).Hitbox;
            var rectHbToHitCorner = new Pad(coord2, dimension2).Hitbox;
            var ballHbToHitVertical = new Ball(coord3, ballDimension).Hitbox;
            var ballHbToHitHorizontal = new Ball(coord4, ballDimension).Hitbox;
            var ballHbToHitCorner = new Ball(coord5, ballDimension, new Vector(1, -1)).Hitbox;
            var ballHbToHitTop = new Ball(coord6, ballDimension).Hitbox;
            var ballHbToMiss = new Ball(coord7, ballDimension).Hitbox;

            var result = rectHb.CollidingInformationWithHb(rectHbToHitCorner);
            Assert.True(result != null);
            Assert.AreEqual(HitEdge.Corner, result.HitEdge);
            Assert.True(new Dimension(1, 0.5).Equals(result.CollisionOffset));

            result = rectHb.CollidingInformationWithHb(ballHbToHitVertical);
            Assert.True(result != null);
            Assert.AreEqual(HitEdge.Vertical, result.HitEdge);
            Assert.True(new Dimension(3, 0).Equals(result.CollisionOffset));

            result = rectHb.CollidingInformationWithHb(ballHbToHitHorizontal);
            Assert.True(result != null);
            Assert.AreEqual(HitEdge.Horizontal, result.HitEdge);
            Assert.True(new Dimension().Equals(result.CollisionOffset));

            result = rectHb.CollidingInformationWithHb(ballHbToHitCorner);
            Assert.True(result != null);
            Assert.AreEqual(HitEdge.Corner, result.HitEdge);

            result = rectHb.CollidingInformationWithHb(ballHbToHitTop);
            Assert.True(result != null);
            Assert.AreEqual(HitEdge.Top, result.HitEdge);
            Assert.True(new Dimension(0, 2.5).Equals(result.CollisionOffset));

            result = rectHb.CollidingInformationWithHb(ballHbToMiss);
            Assert.False(result != null);
        }

        [Test]
        public void TestCollidingInformationWithBorder()
        {
            var coord1 = new Coord(3, 3);
            var coord2 = new Coord(6, 5);
            var coord3 = new Coord(5, 25);
            var coord4 = new Coord(13, 19);
            var coord5 = new Coord(16, 15);

            var borderDimension = new Dimension(20, 30);
            var dimension1 = new Dimension(4, 7);
            var dimension2 = new Dimension(12, 10);
            var dimension3 = new Dimension(12, 9.9);
            var dimension4 = new Dimension(12, 10);
            var ballDimension = new Dimension(14, 14);

            var rectHbToHitUp = new Pad(coord1, dimension1).Hitbox;
            var rectHbToHitCorner = new Pad(coord2, dimension2).Hitbox;
            var rectHbToHitLeft = new Pad(coord3, dimension3).Hitbox;
            var rectHbToMiss = new Pad(coord4, dimension4).Hitbox;
            var ballHbToHitRight = new Ball(coord5, ballDimension).Hitbox;

            var result = rectHbToHitUp.CollidingInformationWithBorder(borderDimension);
            Assert.True(result != null);
            Assert.AreEqual(HitEdge.Horizontal, result.HitEdge);
            Assert.True(new Dimension(0, 0.5).Equals(result.CollisionOffset));

            result = rectHbToHitCorner.CollidingInformationWithBorder(borderDimension);
            Assert.True(result != null);
            Assert.AreEqual(HitEdge.Corner, result.HitEdge);
            Assert.True(new Dimension().Equals(result.CollisionOffset));

            result = rectHbToHitLeft.CollidingInformationWithBorder(borderDimension);
            Assert.True(result != null);
            Assert.AreEqual(HitEdge.Vertical, result.HitEdge);
            Assert.True(new Dimension(1, 0).Equals(result.CollisionOffset));

            result = rectHbToMiss.CollidingInformationWithBorder(borderDimension);
            Assert.False(result != null);

            result = ballHbToHitRight.CollidingInformationWithBorder(borderDimension);
            Assert.True(result != null);
            Assert.AreEqual(HitEdge.Vertical, result.HitEdge);
            Assert.True(new Dimension(3, 0).Equals(result.CollisionOffset));
        }

        [Test]
        public void TestCollidingWithLowerBorder()
        {
            var coord1 = new Coord(9, 27);

            var coord2 = new Coord(5, 26);

            var borderDimension = new Dimension(20, 30);
            var dimension1 = new Dimension(5, 6);

            var dimension2 = new Dimension(10, 7.9);

            var rectHbToHit = new Pad(coord1, dimension1).Hitbox;
            var rectHbToMiss = new Pad(coord2, dimension2).Hitbox;

            Assert.True(rectHbToHit.IsCollidingWithLowerBorder(borderDimension));
            Assert.False(rectHbToMiss.IsCollidingWithLowerBorder(borderDimension));
        }
    }
}