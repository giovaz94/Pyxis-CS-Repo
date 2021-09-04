using Antonioni.GameState;

namespace Antonioni.Controller.Linker
{
    
    public interface ILinker
    {
        IGameState GetGameState();

        void Render();
    }
}