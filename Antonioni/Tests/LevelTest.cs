using Antonioni.Level;
using Antonioni.Level.Status;
using NUnit.Framework;

namespace Tests
{
    public class LevelTest
    {
        public ILevel TestingLevel { get; set; }

        [Test]
        public void TestInitialLevelConfiguration()
        {
            Assert.Equals(3, TestingLevel.GetLives());
            Assert.Equals(0, TestingLevel.GetScore());
            Assert.Equals(LevelStatus.Playing, TestingLevel.GetLevelStatus());
        }

        [Test]
        public void TestLevelStatusSwitch()
        {
            Assert.Equals(LevelStatus.Playing, TestingLevel.GetLevelStatus());
            TestingLevel.SetLevelStatus(LevelStatus.SuccessfullyCompleted);
            Assert.Equals(LevelStatus.SuccessfullyCompleted, TestingLevel.GetLevelStatus());
            TestingLevel.SetLevelStatus(LevelStatus.GameOver);
            Assert.Equals(LevelStatus.GameOver, TestingLevel.GetLevelStatus());
        }

        [Test]
        public void TestScoreIncrease()
        {
            Assert.Equals(0, TestingLevel.GetScore());
            TestingLevel.IncreaseScore(100);
            Assert.Equals(100, TestingLevel.GetScore());
        }
    }
}