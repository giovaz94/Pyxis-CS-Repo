namespace OOP_Rubboli
{
    public interface IController
    {
        /// <summary>
        /// Returns the View attached to the Controller.
        /// </summary>
        IView View
        {
            get;
        }
    }
}