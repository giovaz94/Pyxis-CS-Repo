namespace Antonioni.Arena
{
    
    /// <summary>
    /// Please note that this interface, and the relative implementations, are not my competence
    /// in the project goals.
    /// This is used only for simulating the interactions Level.
    /// </summary>
    public interface IArena
    {
        /// <summary>
        /// Update the current Arena
        /// </summary>
        /// <param name="delta"> Elapsed time</param>
        void Update(double delta);
    }
}