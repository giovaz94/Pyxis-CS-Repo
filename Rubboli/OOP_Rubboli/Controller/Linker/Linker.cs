using System;

namespace OOP_Rubboli
{
    public class Linker : ILinker
    {
        private IGameLoop _gameLoop;
        private IGameState _gameState;
        private ISceneHandler _sceneHandler;

        public Linker()
        {
            this.CreateGameState();
            this.CreateGameLoop();
            this.MaximumLevelReached = 1;
        }

        private bool ConditionInsertCommand()
        {
            bool isRunning = this._gameState.GetState() == StateEnum.Run;
            bool isWaitingForStartingCommand = this._gameState.GetState()
                                                  == StateEnum.WaitingForStartingCommand;
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
            if (this._gameState.GetState() != StateEnum.Pause) {
                this._gameState.SetState(StateEnum.Pause);
            }
            this._gameState.UpdateTotalScore();
            this.SwitchScene(SceneType.EndLevelScene);
        }

        public IGameState GetGameState()
        {
            return this.GameState;
        }

        private IGameState GameState
        {
            get { return this._gameState; }
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

        public int GetMaximumLevelReached()
        {
            return this.MaximumLevelReached;
        }

        public void SetMaximumLevelReached(int maxLevelReached)
        {
            this.MaximumLevelReached = maxLevelReached;
        }

        private int MaximumLevelReached
        {
            get;
            set;
        }

        public void Menu()
        {
            this.SwitchScene(SceneType.MenuScene);
            if (this._gameState.GetState() == StateEnum.Pause)
            {
                int actualLevelReached = this._gameState.GetCurrentLevel().GetLevelNumber();
                bool levelCompleted = this._gameState.GetCurrentLevel().GetLevelStatus()
                                         == LevelStatus.SuccessfullyCompleted;
                bool isLastLevel = actualLevelReached == this._gameState.
                    GetLevelIterator().Size();
                if (!isLastLevel && levelCompleted)
                {
                    actualLevelReached++;
                }
                this.MaximumLevelReached = Math.Max(this.MaximumLevelReached,
                    actualLevelReached);
                this._gameState.Reset();
                this._gameState.SetState(StateEnum.WaitingForNewGame);
            }
        }

        public void Pause()
        {
            if (this._gameState.GetState() != StateEnum.Pause) {
                this._gameState.SetState(StateEnum.Pause);
                this._gameState.GetCurrentLevel().GetArena().GetPowerupHandler().Pause();
            }
            this.SwitchScene(SceneType.PauseScene);
        }

        public void Quit()
        {
            Environment.Exit(0);
        }

        public void Render()
        {
            if (this._sceneHandler.GetCurrentController().GetView() is IRenderableView) {
                ((IRenderableView) this._sceneHandler.GetCurrentController().GetView()).Render();
            }
        }

        public void Resume()
        {
            this.SwitchScene(SceneType.GameScene);
            this._gameState.SetState(StateEnum.WaitingForStartingCommand);
            this._gameState.GetCurrentLevel().GetArena().GetPowerupHandler().Resume();
        }

        public void Run()
        {
            this.SwitchScene(SceneType.GameScene);
            this.Render();
            this._gameState.SetState(StateEnum.WaitingForStartingCommand);
        }

        public ISceneHandler GetSceneHandler()
        {
            return this.SceneHandler;
        }

        public void SetSceneHandler(ISceneHandler inputSceneHandler)
        {
            this.SceneHandler = inputSceneHandler;
        }

        private ISceneHandler SceneHandler
        {
            get { return this._sceneHandler; }
            set { this._sceneHandler = value; }
        }
        
        public void SelectLevel()
        {
            this.SwitchScene(SceneType.SelectLevelScene);
        }

        public void Settings()
        {
            this.SwitchScene(SceneType.SettingsScene);
        }

        public void SwitchLevel()
        {
            this._gameState.SwitchLevel();
            this.Run();
        }
    }
}