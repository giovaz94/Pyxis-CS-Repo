using Antonioni.GameState.State;
using Antonioni.Level;

namespace Antonioni.GameState
{
    public class GameState: IGameState
    {
        
        private ILevel Level {get; set;}
        private StateEnum State { get; set; }
        
        public GameState(ILevel level)
        {
            this.Level = level;
            this.SetState(StateEnum.WaitingForNewGame);
        }

        public GameState() : this(new Level.Level(new Arena.Arena()))
        {
        }
        
        public ILevel GetLevel()
        {
            return this.Level;
        }

        public StateEnum GetState()
        {
            return this.State;
        }

        public void SetState(StateEnum stateEnum)
        {
            this.State = stateEnum;
        }

        public void Reset()
        {
            this.Level = new Level.Level(new Arena.Arena());
        }

        public void Update(double delta)
        {
            this.Level.Update(delta);
        }
    }
}