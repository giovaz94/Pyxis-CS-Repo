using Antonioni.GameState;
using Antonioni.GameState.State;
using NUnit.Framework;

namespace Tests
{
    public class GameStateTest
    {
        private IGameState _testingGameState { get; set; }

        [SetUp]
        public void Setup()
        {
            this._testingGameState = new GameState();
        }
        
        [Test]
        public void TestInitialGameStateConfiguration()
        {
            Assert.AreEqual(StateEnum.WaitingForNewGame, _testingGameState.GetState());
        }
        
        [Test]
        public void TestSwitchState()
        {
            _testingGameState.SetState(StateEnum.WaitingForStartingCommand);
            Assert.AreEqual(StateEnum.WaitingForStartingCommand, _testingGameState.GetState());
            _testingGameState.SetState(StateEnum.Run);
            Assert.AreEqual(StateEnum.Run, _testingGameState.GetState());
            _testingGameState.SetState(StateEnum.Pause);
            Assert.AreEqual(StateEnum.Pause, _testingGameState.GetState());
            _testingGameState.SetState(StateEnum.Stop);
            Assert.AreEqual(StateEnum.Stop, _testingGameState.GetState());
            _testingGameState.SetState(StateEnum.WaitingForNewGame);
            Assert.AreEqual(StateEnum.WaitingForNewGame, _testingGameState.GetState());
        }
    }
}