using Antonioni.GameState;

namespace Antonioni.Controller.Linker
{
    
    public interface ILinker
    {
        /// <summary>
        /// Return the instance of the GameState
        /// </summary>
        /// <returns>The GameState</returns>
        IGameState GetGameState();

        /// <summary>
        /// Render the current view
        /// </summary>
        void Render();
    }
}