using Antonioni.Controller.Command;
using Antonioni.Level;

namespace Antonioni.Controller.Engine
{
    public interface IGameLoop
    {
        /// <summary>
        /// Adds a command in the queue.
        /// </summary>
        /// <param name="command"> The command to add in the queue. </param>
        void AddCommand(ICommand<ILevel> command);

        /// <summary>
        /// Processes the next command sent by the user to the application.
        /// </summary>
        void ProcessInput();

        /// <summary>
        /// Refreshes the current graphic view drawing the Element of the model
        /// </summary>
        void Render();
        
        /// <summary>
        /// Executes the main loop
        /// </summary>
        void Run();
        
        /// <summary>
        /// Updates the game model passing the elapsed time between two game loop's cycles.
        /// </summary>
        /// <param name="elapsed"></param>
        void Update(double elapsed);
    }
}