using System.Text;
using Antonioni.GameState.State;
using Antonioni.Level;

namespace Antonioni.GameState
{
    public interface IGameState
    {
        StateEnum GetState();

        void SetState(StateEnum stateEnum);

        void Reset();

        void Update(double delta);
    }
}