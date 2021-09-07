using System;
using Antonioni.GameState;

namespace Antonioni.Controller.Linker
{
    /// <summary>
    /// Please note that this interface, and the relative implementations, are not my competence
    /// in the project goals.
    /// </summary>
    public class Linker: ILinker
    {
        private IGameState _gameState { get; }
        
        public Linker()
        {
            this._gameState = new GameState.GameState(); 
        }

        public IGameState GetGameState()
        {
            return this._gameState;
        }

        public void Render()
        {
            Console.WriteLine("Rendering View");
        }
    }
}