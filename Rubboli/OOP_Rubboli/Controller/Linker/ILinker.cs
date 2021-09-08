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
        IGameState GameState 
        {
            get;
        }

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
        int MaximumLevelReached
        {
            get;
            set;
        }
        
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
        /// Sets and returns the SceneHandler.
        /// </summary>
        ISceneHandler SceneHandler
        {
            get;
            set;
        }
        
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