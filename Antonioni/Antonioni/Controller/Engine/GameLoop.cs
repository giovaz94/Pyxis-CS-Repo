using System;
using System.Collections.Concurrent;
using System.Threading;
using Antonioni.Controller.Command;
using Antonioni.Controller.Linker;
using Antonioni.GameState;
using Antonioni.GameState.State;
using Antonioni.Level;

namespace Antonioni.Controller.Engine
{
    public class GameLoop: IGameLoop
    {
        private const long Period = 1000;
        private readonly ConcurrentQueue<ICommand<ILevel>> _commandQueue = new ConcurrentQueue<ICommand<ILevel>>();
        private readonly ILinker _inputLinker;

        public GameLoop()
        {
            this._inputLinker = new Linker.Linker();
            this._inputLinker.GetGameState().SetState(StateEnum.Run);
        }
        
        private void WaitForNextFrame(long current)
        {
            long dt = DateTimeOffset.Now.ToUnixTimeMilliseconds() - current;
            if (dt < Period)
            {
                Thread.Sleep(Convert.ToInt32(Period - dt));
            }
        }
        
        public void Run()
        {
            Console.WriteLine("GameLoop Started !");
            
            long lastTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            IGameState gState = this._inputLinker.GetGameState();
            while (gState.GetState() != StateEnum.Stop)
            {
                long current = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                int elapsed = Convert.ToInt32(current - lastTime);
                if (gState.GetState() == StateEnum.Run)
                {
                    this.ProcessInput();
                    this.Update(elapsed);
                }
                if (gState.GetState() == StateEnum.Run || gState.GetState() == StateEnum.WaitingForStartingCommand)
                {
                    this.Render();
                }
                this.WaitForNextFrame(current);
                lastTime = current;
            }
        }
        
        public void AddCommand(ICommand<ILevel> command)
        {
            this._commandQueue.Enqueue(command);
        }

        public void ProcessInput()
        {
            while (this._commandQueue.Count > 0)
            {
                ICommand<ILevel> command; 
                this._commandQueue.TryDequeue(out command);
                command.Execute(this._inputLinker.GetGameState().GetLevel());
            }
        }

        public void Render()
        {
            this._inputLinker.Render();
        }

        public void Update(double elapsed)
        {
            this._inputLinker.GetGameState().Update(elapsed);
        }
    }
}