namespace OOP_Rubboli
{
    public interface ISceneHandler
    {
        IController CurrentController
        {
            get;
            set;
        }

        void SwitchScene(SceneType inputSceneType);
    }
}