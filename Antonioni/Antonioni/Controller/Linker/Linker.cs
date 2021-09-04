using System;
using Antonioni.GameState;

namespace Antonioni.Controller.Linker
{
    public class Linker: ILinker
    {
        private IGameState GameState { get; set; }
        
        public Linker()
        {
            this.GameState = new GameState.GameState(); 
        }

        public IGameState GetGameState()
        {
            return this.GameState;
        }

        public void Render()
        {
            Console.WriteLine("Rendering View");
        }
    }
}