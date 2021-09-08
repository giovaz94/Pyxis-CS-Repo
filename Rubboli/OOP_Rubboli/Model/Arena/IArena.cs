namespace OOP_Rubboli
{
    public interface IArena
    {
        /// <summary>
        /// Returns the Arena's PowerupHandler.
        /// </summary>
        IPowerupHandler PowerupHandler
        {
            get;
        }
    }
}