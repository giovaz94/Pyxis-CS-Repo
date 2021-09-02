using Antonioni.Arena;
using Antonioni.Level;
using Antonioni.Level.Status;
using NUnit.Framework;

namespace Tests
{
    public class LevelTest
    {
        private ILevel TestingLevel { get; set; }
        private IArena TestingArena { get; set; }
        
        [SetUp]
        public void Setup()
        {
            TestingArena = new Arena();
            TestingLevel = new Level(TestingArena);
        }
        
        [Test]
        public void TestInitialLevelConfiguration()
        {
            Assert.AreEqual(3, TestingLevel.GetLives());
            Assert.AreEqual(0, TestingLevel.GetScore());
            Assert.AreEqual(LevelStatus.Playing, TestingLevel.GetLevelStatus());
            Assert.AreEqual(1, TestingLevel.GetLevelNumber());
        }

        [Test]
        public void TestLevelStatusSwitch()
        {
            Assert.AreEqual(LevelStatus.Playing, TestingLevel.GetLevelStatus());
            TestingLevel.SetLevelStatus(LevelStatus.SuccessfullyCompleted);
            Assert.AreEqual(LevelStatus.SuccessfullyCompleted, TestingLevel.GetLevelStatus());
            TestingLevel.SetLevelStatus(LevelStatus.GameOver);
            Assert.AreEqual(LevelStatus.GameOver, TestingLevel.GetLevelStatus());
        }

        [Test]
        public void TestScoreIncrease()
        {
            Assert.AreEqual(0, TestingLevel.GetScore());
            TestingLevel.IncreaseScore(100);
            Assert.AreEqual(100, TestingLevel.GetScore());
        }

        [Test]
        public void TestLivesDecrease()
        {
            Assert.AreEqual(3, TestingLevel.GetLives());
            TestingLevel.DecreaseLife();
            Assert.AreEqual(2, TestingLevel.GetLives());
        }

        [Test]
        public void TestLevelArena()
        {
            Assert.AreEqual(TestingArena, TestingLevel.GetArena());
        }
    }
}