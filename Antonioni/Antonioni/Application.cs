using System;
using System.Threading;
using Antonioni.Controller.Engine;

namespace Antonioni
{
    class Application
    {
        static void Main(string[] args)
        {
            IGameLoop gameLoop = new GameLoop();
            Thread gameLoopInstance = new Thread(new ThreadStart(gameLoop.Run));
            
            gameLoopInstance.Start();
        }
    }
}