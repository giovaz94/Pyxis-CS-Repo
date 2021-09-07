using Antonioni.GameState.State;
using Antonioni.Level;

namespace Antonioni.GameState
{
    public class GameState: IGameState
    {
        
        private ILevel _level {get; set;}
        private StateEnum _state { get; set; }
        
        public GameState(ILevel level)
        {
            this._level = level;
            this.SetState(StateEnum.WaitingForNewGame);
        }

        public GameState() : this(new Level.Level(new Arena.Arena()))
        {
        }
        
        public ILevel GetLevel()
        {
            return this._level;
        }

        public StateEnum GetState()
        {
            return this._state;
        }

        public void SetState(StateEnum stateEnum)
        {
            this._state = stateEnum;
        }

        public void Reset()
        {
            this._level = new Level.Level(new Arena.Arena());
        }

        public void Update(double delta)
        {
            this._level.Update(delta);
        }
    }
}