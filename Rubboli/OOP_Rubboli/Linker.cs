using System;

namespace OOP_Rubboli
{
    public class LinkerImpl : Linker
    {
        private IGameLoop _gameLoop;
        private IGameState _gameState;
        private int _maximumLevelReached;
        private ISceneHandler _sceneHandler;

        public LinkerImpl()
        {
            this.CreateGameState();
            this.CreateGameLoop();
            this._maximumLevelReached = 1;
        }

        private bool ConditionInsertCommand()
        {
            bool isRunning = this._gameState.State == StateEnum.RUN;
            bool isWaitingForStartingCommand = this._gameState.State
                                                  == StateEnum.WAITING_FOR_STARTING_COMMAND;
            return isRunning || isWaitingForStartingCommand;
        }

        private void CreateGameLoop()
        {
            this._gameLoop = new GameLoop(this);
            this._gameLoop.Start();
        }
        
        private void CreateGameState() {
            this._gameState = new GameState();
        }

        private void SwitchScene(SceneType inputSceneType)
        {
            this._sceneHandler.SwitchScene(inputSceneType);
        }
        
        public void EndLevel()
        {
            if (this._gameState.State != StateEnum.PAUSE) {
                this._gameState.State(StateEnum.PAUSE);
            }
            this._gameState.UpdateTotalScore();
            this.SwitchScene(SceneType.END_LEVEL_SCENE);
        }

        public IGameState GameState { get; }
        
        public int GetMaximumLevelReached()
        {
            return this._maximumLevelReached;
        }

        public void InsertCommand(ICommand<IGameState> command)
        {
            if (this.ConditionInsertCommand())
            {
                command.Execute(this._gameState);
            }
        }

        public void InsertGameCommand(ICommand<ILevel> command)
        {
            this._gameLoop.AddCommand(command);
        }

        public void Menu()
        {
            this.SwitchScene(SceneType.MENU_SCENE);
            if (this._gameState.State == StateEnum.PAUSE)
            {
                int actualLevelReached = this._gameState.CurrentLevel.LevelNumber;
                bool levelCompleted = this._gameState.CurrentLevel.LevelStatus
                                         == LevelStatus.SUCCESSFULLY_COMPLETED;
                bool isLastLevel = actualLevelReached == this._gameState.
                    LevelIterator.Size();
                if (!isLastLevel && levelCompleted)
                {
                    actualLevelReached++;
                }
                this._maximumLevelReached = Math.Max(this._maximumLevelReached,
                    actualLevelReached);
                this._gameState.Reset();
                this._gameState.State(StateEnum.WAITING_FOR_NEW_GAME);
            }
        }

        public void Pause()
        {
            if (this._gameState.State != StateEnum.PAUSE) {
                this._gameState.State(StateEnum.PAUSE);
                this._gameState.CurrentLevel.Arena.PowerupHandler.Pause();
            }
            this.SwitchScene(SceneType.PAUSE_SCENE);
        }

        public void Quit()
        {
            Environment.Exit(0);
        }

        public void Render()
        {
            if (this._sceneHandler.CurrentController.View is RenderableView) {
                ((RenderableView) this._sceneHandler.CurrentController.View).Render();
            }
        }

        public void Resume()
        {
            this.SwitchScene(SceneType.GAME_SCENE);
            this._gameState.State(StateEnum.WAITING_FOR_STARTING_COMMAND);
            this._gameState.CurrentLevel.Arena.PowerupHandler.Resume();
        }

        public void Run()
        {
            this.SwitchScene(SceneType.GAME_SCENE);
            this.Render();
            this._gameState.State(StateEnum.WAITING_FOR_STARTING_COMMAND);
        }

        public ISceneHandler SceneHandler { get; set; }
        
        public void SelectLevel()
        {
            this.SwitchScene(SceneType.SELECT_LEVEL_SCENE);
        }

        public void Settings()
        {
            this.SwitchScene(SceneType.SETTINGS_SCENE);
        }

        public void SwitchLevel()
        {
            this._gameState.SwitchLevel();
            this.Run();
        }
    }
}