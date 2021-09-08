namespace OOP_Rubboli
{
    public interface IGameLoop
    {
        /// <summary>
        /// Adds a command in the queue.
        /// </summary>
        /// <param name="command">
        /// The command to add in the queue.
        /// </param>
        void AddCommand(ICommand<ILevel> command);
        
        /// <summary>
        /// Starts the game loop.
        /// </summary>
        void Start();
    }
}