namespace OOP_Rubboli
{
    public interface ILevel
    {
        /// <summary>
        /// Returns and sets the Level's Arena.
        /// </summary>
        IArena Arena
        {
            get;
        }
        
        /// <summary>
        /// Returns the Level's number.
        /// </summary>
        int LevelNumber
        {
            get;
        }

        /// <summary>
        /// Returns the Level's status.
        /// </summary>
        LevelStatus LevelStatus
        {
            get;
        }
    }
}