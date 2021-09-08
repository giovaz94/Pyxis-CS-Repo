namespace OOP_Rubboli
{
    public class GameState : IGameState
    {
        private ILevel CurrentLevel { get; }
        public ILevel GetCurrentLevel()
        {
            return this.CurrentLevel;
        }

        private ILevelIterator LevelIterator { get; }
        public ILevelIterator GetLevelIterator()
        {
            return this.LevelIterator;
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        private StateEnum State { get; set; }
        public StateEnum GetState()
        {
            return this.State;
        }

        public void SetState(StateEnum inputState)
        {
            this.State = inputState;
        }

        public void SwitchLevel()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateTotalScore()
        {
            throw new System.NotImplementedException();
        }
    }
}