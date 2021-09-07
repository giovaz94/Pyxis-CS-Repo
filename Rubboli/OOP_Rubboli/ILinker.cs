namespace OOP_Rubboli
{
    public interface Linker
    {
        void EndLevel();
        
        IGameState GameState 
        {
            get;
        }
        
        int GetMaximumLevelReached();
        
        void InsertCommand(ICommand<IGameState> command);
        
        void InsertGameCommand(ICommand<ILevel> command);
        
        void Menu();
        
        void Pause();
        
        void Quit();
        
        void Render();
        
        void Resume();
        
        void Run();
        
        ISceneHandler SceneHandler
        {
            set;
        }
        
        void SelectLevel();
        
        void Settings();
        
        void SwitchLevel();
    }
}