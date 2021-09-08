namespace OOP_Rubboli
{
    public interface ISceneHandler
    {
        /// <summary>
        /// Returns and sets the SceneHandler's current Controller.
        /// </summary>
        IController CurrentController
        {
            get;
            set;
        }

        /// <summary>
        /// Loads and shows the input Scene.
        /// </summary>
        /// <param name="inputSceneType">
        /// The SceneType to set.
        /// </param>
        void SwitchScene(SceneType inputSceneType);
    }
}