namespace OOP_Rubboli
{
    public interface ISceneHandler
    {
        /// <summary>
        /// Returns the SceneHandler's current Controller.
        /// </summary>
        IController GetCurrentController();

        /// <summary>
        /// Sets the SceneHandler's current Controller.
        /// </summary>
        /// <param name="inputController">
        /// The input Controller.
        /// </param>
        void SetCurrentController(IController inputController);

        /// <summary>
        /// Loads and shows the input Scene.
        /// </summary>
        /// <param name="inputSceneType">
        /// The SceneType to set.
        /// </param>
        void SwitchScene(SceneType inputSceneType);
    }
}