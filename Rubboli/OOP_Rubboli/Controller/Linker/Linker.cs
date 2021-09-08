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
            bool isRunning = this._gameState.State == StateEnum.Run;
            bool isWaitingForStartingCommand = this._gameState.State
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
            if (this._gameState.State != StateEnum.Pause) {
                this._gameState.State = StateEnum.Pause;
            }
            this._gameState.UpdateTotalScore();
            this.SwitchScene(SceneType.EndLevelScene);
        }

        public IGameState GameState
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

        public int MaximumLevelReached
        {
            get;
            set;
        }

        public void Menu()
        {
            this.SwitchScene(SceneType.MenuScene);
            if (this._gameState.State == StateEnum.Pause)
            {
                int actualLevelReached = this._gameState.CurrentLevel.LevelNumber;
                bool levelCompleted = this._gameState.CurrentLevel.LevelStatus
                                         == LevelStatus.SuccessfullyCompleted;
                bool isLastLevel = actualLevelReached == this._gameState.
                    LevelIterator.Size();
                if (!isLastLevel && levelCompleted)
                {
                    actualLevelReached++;
                }
                this.MaximumLevelReached = Math.Max(this.MaximumLevelReached,
                    actualLevelReached);
                this._gameState.Reset();
                this._gameState.State = StateEnum.WaitingForNewGame;
            }
        }

        public void Pause()
        {
            if (this._gameState.State != StateEnum.Pause) {
                this._gameState.State = StateEnum.Pause;
                this._gameState.CurrentLevel.Arena.PowerupHandler.Pause();
            }
            this.SwitchScene(SceneType.PauseScene);
        }

        public void Quit()
        {
            Environment.Exit(0);
        }

        public void Render()
        {
            if (this._sceneHandler.CurrentController.View is IRenderableView) {
                ((IRenderableView) this._sceneHandler.CurrentController.View).Render();
            }
        }

        public void Resume()
        {
            this.SwitchScene(SceneType.GameScene);
            this._gameState.State = StateEnum.WaitingForStartingCommand;
            this._gameState.CurrentLevel.Arena.PowerupHandler.Resume();
        }

        public void Run()
        {
            this.SwitchScene(SceneType.GameScene);
            this.Render();
            this._gameState.State = StateEnum.WaitingForStartingCommand;
        }

        public ISceneHandler SceneHandler
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