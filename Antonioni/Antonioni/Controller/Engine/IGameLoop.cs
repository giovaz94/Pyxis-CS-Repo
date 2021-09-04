using Antonioni.Controller.Command;
using Antonioni.Level;

namespace Antonioni.Controller.Engine
{
    public interface IGameLoop
    {
        void AddCommand(ICommand<ILevel> command);

        void ProcessInput();

        void Render();
        
        void Run();
        
        void Update(double elapsed);
    }
}