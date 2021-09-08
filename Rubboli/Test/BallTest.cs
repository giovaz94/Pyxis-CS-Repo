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

        private IBallBuilder _ballBuilder; 
        private ICoord _startingCoord;
        private IVector _startingPace;
        private int _dt;

        [SetUp]
        public void Setup()
        {
            this._ballBuilder = new BallBuilder();
            this._startingCoord = new Coord(1, 1);
            this._startingPace = new Vector(5, 10);
            this._dt = 200;
            this.TestingBall = this._ballBuilder.InitialPosition(this._startingCoord)
                .Pace(this._startingPace)
                .Id(1)
                .Build();
        }
        
        [Test]
        public void TestType() {
            Assert.AreEqual(this.TestingBall.GetType(), BallType.NormalBall);
            this.TestingBall.SetType(BallType.AtomicBall);
            Assert.AreEqual(this.TestingBall.GetType(), BallType.AtomicBall);
            this.TestingBall.SetType(BallType.SteelBall);
            Assert.AreNotEqual(this.TestingBall.GetType(), BallType.AtomicBall);
            Assert.AreEqual(this.TestingBall.GetType(), BallType.SteelBall);
        }
        
        [Test]
        public void testPace() {
            Assert.AreEqual(this.TestingBall.GetPace(), this._startingPace);
            IVector modifyPace = this.TestingBall.GetPace();
            modifyPace.SetX(4.0);
            modifyPace.SetY(6.2);
            Assert.AreNotEqual(this.TestingBall.GetPace(), modifyPace);
            this.TestingBall.SetPace(modifyPace);
            Assert.AreEqual(this.TestingBall.GetPace(), modifyPace);
        }
    }
}