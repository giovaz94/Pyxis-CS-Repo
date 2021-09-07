using NUnit.Framework;
using Traini.Model.Arena;
using Traini.Model.Element.BallElement;
using Traini.Model.Element.PadElement;
using Traini.Model.Hitbox;
using Traini.Model.Util;

namespace Test
{
    public class TestArena
    {
        private IArena _testArena;
        [SetUp]
        public void Setup()
        {
            this._testArena = new Arena(new Dimension(500, 500));
        }

        [Test]
        public void TestPadMovementLeft()
        {
            this._testArena.Pad = new Pad(new Coord(250, 8), new Dimension(70, 12));
            Assert.True(250 == this._testArena.Pad.Position.X);
            this._testArena.MovePadLeft();
            Assert.True(240 == this._testArena.Pad.Position.X);
        }

        [Test]
        public void TestPadMovementRight()
        {
            this._testArena.Pad = new Pad(new Coord(250, 8), new Dimension(70, 12));
            Assert.True(250 == this._testArena.Pad.Position.X);
            this._testArena.MovePadRight();
            Assert.True(260 == this._testArena.Pad.Position.X);
        }

        [Test]
        public void TestModifyPadDimension()
        {
            this._testArena.Pad = new Pad(new Coord(7, 8), new Dimension(70, 12));
            Assert.True(70 == this._testArena.Pad.Dimension.Width);
            this._testArena.IncreasePadWidth(10);
            Assert.True(80 == this._testArena.Pad.Dimension.Width);
            this._testArena.IncreasePadWidth(-30);
            Assert.True(50 == this._testArena.Pad.Dimension.Width);
        }

        [Test]
        public void TestRestorePadDimension()
        {
            this._testArena.Pad = new Pad(new Coord(7, 8), new Dimension(70, 12));
            Assert.True(70 == this._testArena.Pad.Dimension.Width);
            this._testArena.IncreasePadWidth(10);
            this._testArena.RestorePadDimension();
            Assert.True(70 == this._testArena.Pad.Dimension.Width);
        }

        [Test]
        public void TestAddBall()
        {
            Assert.True(0 == this._testArena.Balls.Count);
            this._testArena.AddBall(new Ball(new Coord(10, 10), new Dimension(14, 14)));
            Assert.True(1 == this._testArena.Balls.Count);
        }
    }
}