namespace OOP_Rubboli
{
    public interface IGameState
    {
        ILevel CurrentLevel
        {
            get;
        }

        ILevelIterator LevelIterator
        {
            get;
        }

        void Reset();
        
        StateEnum State
        {
            get;
            set;
        }

        void SwitchLevel();

        void UpdateTotalScore();
    }
}