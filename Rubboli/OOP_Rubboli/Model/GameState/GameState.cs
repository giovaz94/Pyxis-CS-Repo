namespace OOP_Rubboli
{
    public class GameState : IGameState
    {
        public ILevel CurrentLevel { get; }
        public ILevelIterator LevelIterator { get; }
        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public StateEnum State { get; set; }
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