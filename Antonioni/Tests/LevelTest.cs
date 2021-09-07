using Antonioni.Arena;
using Antonioni.Level;
using Antonioni.Level.Status;
using NUnit.Framework;

namespace Tests
{
    public class LevelTest
    {
        private ILevel _testingLevel { get; set; }
        private IArena _testingArena { get; set; }
        
        [SetUp]
        public void Setup()
        {
            _testingArena = new Arena();
            _testingLevel = new Level(_testingArena);
        }
        
        [Test]
        public void TestInitialLevelConfiguration()
        {
            Assert.AreEqual(3, _testingLevel.GetLives());
            Assert.AreEqual(0, _testingLevel.GetScore());
            Assert.AreEqual(LevelStatus.Playing, _testingLevel.GetLevelStatus());
            Assert.AreEqual(1, _testingLevel.GetLevelNumber());
        }

        [Test]
        public void TestLevelStatusSwitch()
        {
            Assert.AreEqual(LevelStatus.Playing, _testingLevel.GetLevelStatus());
            _testingLevel.SetLevelStatus(LevelStatus.SuccessfullyCompleted);
            Assert.AreEqual(LevelStatus.SuccessfullyCompleted, _testingLevel.GetLevelStatus());
            _testingLevel.SetLevelStatus(LevelStatus.GameOver);
            Assert.AreEqual(LevelStatus.GameOver, _testingLevel.GetLevelStatus());
        }

        [Test]
        public void TestScoreIncrease()
        {
            Assert.AreEqual(0, _testingLevel.GetScore());
            _testingLevel.IncreaseScore(100);
            Assert.AreEqual(100, _testingLevel.GetScore());
        }

        [Test]
        public void TestLivesDecrease()
        {
            Assert.AreEqual(3, _testingLevel.GetLives());
            _testingLevel.DecreaseLife();
            Assert.AreEqual(2, _testingLevel.GetLives());
        }

        [Test]
        public void TestLevelArena()
        {
            Assert.AreEqual(_testingArena, _testingLevel.GetArena());
        }
    }
}