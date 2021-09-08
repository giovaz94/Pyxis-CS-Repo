namespace OOP_Rubboli
{
    public interface IPowerupHandler
    {
        /// <summary>
        /// Please note that this interface, and the relative implementations, are not my competence
        /// in the project goals.
        /// </summary>
        
        /// <summary>
        /// Pauses the execution PowerupHandler. The handler will continue to register new
        /// Powerup but these will be applied after a successive call of PowerupHandler#resume().
        /// All the active Powerups will be set to a paused state and they will continue their execution
        /// only when the PowerupHandler will be resumed. 
        /// This method should be called only when the GameState is paused.
        /// </summary>
        void Pause();

        /// <summary>
        /// Resumes the execution of the PowerupHandler.
        /// The active Powerups
        /// can continue their executions.
        /// </summary>
        void Resume();
    }
}