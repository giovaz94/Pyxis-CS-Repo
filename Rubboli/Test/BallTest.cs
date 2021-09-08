using NUnit.Framework;
using OOP_Rubboli;
using OOP_Rubboli.util;

namespace Test
{
    public class BallTest
    {
        private IBall TestingBall
        {
            get;
            set;
        }

        private ICoord _startingCoord;
        private IVector _startingPace;
        private int dt;

        [SetUp]
        public void Setup()
        {
            this._startingCoord = new Coord(1, 1);
            this._startingPace = new Vector(5, 10);
            this.dt = 200;
            this.TestingBall = new BallBuilder().InitialPosition(this._startingCoord)
                .Pace(this._startingPace)
                .Id(1)
                .Build();
        }
        
        [Test]
        public void TestType() {
            Assert.AreEqual(this.TestingBall.Type, BallType.NormalBall);
            this.TestingBall.Type = BallType.AtomicBall;
            Assert.AreEqual(this.TestingBall.Type, BallType.AtomicBall);
            this.TestingBall.Type = BallType.SteelBall;
            Assert.AreNotEqual(this.TestingBall.Type, BallType.AtomicBall);
            Assert.AreEqual(this.TestingBall.Type, BallType.SteelBall);
        }
        
        [Test]
        public void testPace() {
            Assert.AreEqual(this.TestingBall.Pace, this._startingPace);
            IVector modifyPace = this.TestingBall.Pace;
            modifyPace.X = 4.0;
            modifyPace.Y = 6.2;
            Assert.AreNotEqual(this.TestingBall.Pace, modifyPace);
            this.TestingBall.Pace = modifyPace;
            Assert.AreEqual(this.TestingBall.Pace, modifyPace);
        }
        
        [Test]
        public void testUpdate() {
            ICoord coordinates = this.TestingBall.Position;
            assertEquals(this.ball1.getPosition(), coordinates);
            this.ball1.update(this.dt);
            final double multiplier = this.ball1.getType().getPaceMultiplier();
            final double modX = coordinates.getX() + (this.ball1.getPace().getX() * multiplier * this.dt * this.ball1.getUpdateTimeMultiplier());
            final double modY = coordinates.getY() + (this.ball1.getPace().getY() * multiplier * this.dt * this.ball1.getUpdateTimeMultiplier());
            Coord updatedCoordinates = new CoordImpl(modX, modY);
            assertNotEquals(this.ball1.getPosition(), coordinates);
            assertEquals(this.ball1.getPosition(), updatedCoordinates);
        }
    }
}