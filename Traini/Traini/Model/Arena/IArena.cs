using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traini.Model.Element;
using Traini.Model.Util;

namespace Traini.Model.Arena
{
    interface IArena
    {
        IDimension Dimension { get; }
        IPad Pad { get; set; }
        ISet<IBall> Balls { get; }
        ISet<IBrick> Bricks { get; }
        ISet<IPowerup> Powerups { get; }
        void AddBall(IBall ball);
        void AddBrick(IBrick brick);
        void AddPowerup(IPowerup powerup);
        void CleanUp();
        void ClearBalls();
        void ClearBricks();
        void ClearPowerups();
        int GetLastBallId();
        IBall GetRandomBall();
        void IncreasePadWidth(double amount);
        bool IsCleared();
        void MovePadLeft();
        void MovePadRight();
        void RemoveBall(IBall ball);
        void RemoveBrick(ICoord brickCoord);
        void RemovePowerup(IPowerup powerup);
        void ResetStartingPosition();
        void RestorePadDimension();
    }
}
