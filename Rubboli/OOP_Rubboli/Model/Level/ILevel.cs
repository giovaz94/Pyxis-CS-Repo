namespace OOP_Rubboli
{
    public interface ILevel
    {
        /// <summary>
        /// Please note that this interface, and the relative implementations, are not my competence
        /// in the project goals.
        /// </summary>
        
        /// <summary>
        /// Returns and sets the Level's Arena.
        /// </summary>
        IArena GetArena();

        /// <summary>
        /// Returns the Level's number.
        /// </summary>
        int GetLevelNumber();

        /// <summary>
        /// Returns the Level's status.
        /// </summary>
        LevelStatus GetLevelStatus();
    }
}