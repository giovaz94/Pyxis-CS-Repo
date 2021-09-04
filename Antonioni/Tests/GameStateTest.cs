using Antonioni.GameState;
using Antonioni.GameState.State;
using NUnit.Framework;

namespace Tests
{
    public class GameStateTest
    {
        private IGameState TestingGameState { get; set; }

        [SetUp]
        public void Setup()
        {
            this.TestingGameState = new GameState();
        }
        
        [Test]
        public void TestInitialGameStateConfiguration()
        {
            Assert.AreEqual(StateEnum.WaitingForNewGame, TestingGameState.GetState());
        }
        
        [Test]
        public void TestSwitchState()
        {
            TestingGameState.SetState(StateEnum.WaitingForStartingCommand);
            Assert.AreEqual(StateEnum.WaitingForStartingCommand, TestingGameState.GetState());
            TestingGameState.SetState(StateEnum.Run);
            Assert.AreEqual(StateEnum.Run, TestingGameState.GetState());
            TestingGameState.SetState(StateEnum.Pause);
            Assert.AreEqual(StateEnum.Pause, TestingGameState.GetState());
            TestingGameState.SetState(StateEnum.Stop);
            Assert.AreEqual(StateEnum.Stop, TestingGameState.GetState());
            TestingGameState.SetState(StateEnum.WaitingForNewGame);
            Assert.AreEqual(StateEnum.WaitingForNewGame, TestingGameState.GetState());
        }
    }
}