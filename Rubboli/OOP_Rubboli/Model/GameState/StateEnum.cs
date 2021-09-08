namespace OOP_Rubboli
{
    public enum StateEnum
    {
        /// <summary>
        /// The game is in the pause status.
        /// </summary>
        Pause,
        /// <summary>
        /// The game is currently running.
        /// </summary>
        Run,
        /// <summary>
        /// The game is in the stop status.
        /// </summary>
        Stop,
        /// <summary>
        /// The game is waiting for a new game.
        /// </summary>
        WaitingForNewGame,
        /// <summary>
        /// The game is currently in a new game, but it's waiting to receive the starting
        /// command.
        /// </summary>
        WaitingForStartingCommand
    }
}