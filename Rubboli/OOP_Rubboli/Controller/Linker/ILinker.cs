namespace OOP_Rubboli
{
    public interface ILinker
    {
        /// <summary>
        /// Sets the GameState's StateEnum to
        /// Pause and load the EndLevelView.
        /// </summary>
        void EndLevel();
        
        /// <summary>
        /// Returns the instance of GameState.
        /// </summary>
        IGameState GetGameState(); 

        /// <summary>
        /// Adds a Command to the list of commands that a player can input.
        /// </summary>
        /// <param name="command">
        /// The Command to add.
        /// </param>
        void InsertCommand(ICommand<IGameState> command);
        
        /// <summary>
        /// Adds a Command to the GameLoop input list.
        /// </summary>
        /// <param name="command">
        /// The Command to add.
        /// </param>
        void InsertGameCommand(ICommand<ILevel> command);
        
        /// <summary>
        /// Returns the maximum level reached by the player during the actual game session.
        /// </summary>
        int GetMaximumLevelReached();
        
        /// <summary>
        /// Sets the maximum level reached by the player during the actual game session.
        /// </summary>
        /// <param name="maxLevelReached">
        /// The maximum level reached.
        /// </param>
        void SetMaximumLevelReached(int maxLevelReached);
        
        /// <summary>
        /// Loads the MenuView.
        /// </summary>
        void Menu();
        
        /// <summary>
        /// Loads the PauseView and set the GameState's StateEnum to PAUSE.
        /// </summary>
        void Pause();
        
        /// <summary>
        /// Closes the application.
        /// </summary>
        void Quit();
        
        /// <summary>
        /// Renders the current View if RenderableView.
        /// </summary>
        void Render();
        
        /// <summary>
        /// Resumes a paused GameState.
        /// </summary>
        void Resume();
        
        /// <summary>
        /// Loads the GameView.
        /// </summary>
        void Run();
        
        /// <summary>
        /// Returns the SceneHandler.
        /// </summary>
        ISceneHandler GetSceneHandler();
        
        /// <summary>
        /// Sets the Linker's SceneHandler.
        /// </summary>
        /// <param name="inputSceneHandler">
        /// The SceneHandler.
        /// </param>
        void SetSceneHandler(ISceneHandler inputSceneHandler);
        
        /// <summary>
        /// Loads the SelectLevelView.
        /// </summary>
        void SelectLevel();
        
        /// <summary>
        /// Loads the SettingsView.
        /// </summary>
        void Settings();
        
        /// <summary>
        /// Loads, if present, the next Level.
        /// </summary>
        void SwitchLevel();
    }
}