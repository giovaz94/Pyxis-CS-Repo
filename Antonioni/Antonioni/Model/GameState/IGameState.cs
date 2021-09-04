using System.Text;
using Antonioni.GameState.State;
using Antonioni.Level;

namespace Antonioni.GameState
{
    public interface IGameState
    {
        /// <summary>
        /// Return the current playing level of the game
        /// </summary>
        /// <returns>The current playing level</returns>
        ILevel GetLevel();
        
        /// <summary>
        /// Return the current state of the game
        /// </summary>
        /// <returns></returns>
        StateEnum GetState();

        /// <summary>
        /// Set a new status of the game
        /// </summary>
        /// <param name="stateEnum"></param>
        void SetState(StateEnum stateEnum);

        /// <summary>
        /// Reset the state of the game
        /// </summary>
        void Reset();

        /// <summary>
        /// Update the game
        /// </summary>
        /// <param name="delta"></param>
        void Update(double delta);
    }
}