namespace OOP_Rubboli
{
    public interface IGameState
    {
        /// <summary>
        /// Please note that this interface, and the relative implementations, are not my competence
        /// in the project goals.
        /// </summary>
        ILevel GetCurrentLevel();

        /// <summary>
        /// Returns the GameState's LevelIterator.
        /// </summary>
        ILevelIterator GetLevelIterator();

        /// <summary>
        /// Resets the game.
        /// </summary>
        void Reset();
        
        /// <summary>
        /// Returns the GameState's State.
        /// </summary>
        StateEnum GetState();
        
        /// <summary>
        /// Sets the GameState's State.
        /// </summary>
        /// <param name="inputState">
        /// The input state.
        /// </param>
        void SetState(StateEnum inputState);

        /// <summary>
        /// Changes the current playing Level.
        /// If no other levels are available sets the GameState in a stopped mode.
        /// </summary>
        void SwitchLevel();

        /// <summary>
        /// Adds the Level score to the total score.
        /// </summary>
        void UpdateTotalScore();
    }
}