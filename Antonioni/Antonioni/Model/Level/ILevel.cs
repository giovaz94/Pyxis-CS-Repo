using Antonioni.Arena;
using Antonioni.Level.Status;

namespace Antonioni.Level
{
    public interface ILevel
    {
        /// <summary>
        /// Decrease a life 
        /// </summary>
        void DecreaseLife();

        /// <summary>
        /// Return the current level number
        /// </summary>
        /// <returns>The number of the current level</returns>
        int GetLevelNumber();

        /// <summary>
        /// Return the current lives of the player
        /// </summary>
        /// <returns>Number of lives</returns>
        int GetLives();

        /// <summary>
        /// Return the score of the level
        /// </summary>
        /// <returns></returns>
        int GetScore();

        /// <summary>
        /// Increase the score of the level
        /// </summary>
        /// <param name="score"> The passed score</param>
        void IncreaseScore(int score);

        /// <summary>
        /// Return the current LevelStatus
        /// </summary>
        /// <returns>A value of LevelStatus</returns>
        LevelStatus GetLevelStatus();

        /// <summary>
        /// Set a new status for the current Level
        /// </summary>
        /// <param name="status">Passed status</param>
        void SetLevelStatus(LevelStatus status);
        
        /// <summary>
        /// Return the linked Arena
        /// </summary>
        /// <returns>The current arena of the game</returns>
        IArena GetArena();

        /// <summary>
        /// Updates the game
        /// </summary>
        /// <param name="delta">elapsed time</param>
        void Update(double delta);
    }
}