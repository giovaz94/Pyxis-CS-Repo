using System.Collections.Generic;
using Traini.Model.Element.BallElement;
using Traini.Model.Element.BrickElement;
using Traini.Model.Element.PadElement;
using Traini.Model.Element.PowerupElement;
using Traini.Model.Util;

namespace Traini.Model.Arena
{
    interface IArena
    {
        /// <summary>
        /// The Dimension of the Arena
        /// </summary>
        IDimension Dimension { get; }
        /// <summary>
        /// The pad in the Arena
        /// </summary>
        IPad Pad { get; set; }
        /// <summary>
        /// The balls in the Arena
        /// </summary>
        ISet<IBall> Balls { get; }
        /// <summary>
        /// The Bricks in the Arena
        /// </summary>
        ISet<IBrick> Bricks { get; }
        /// <summary>
        /// The powerups in the Arena
        /// </summary>
        ISet<IPowerup> Powerups { get; }

        /// <summary>
        /// Adds a Ball in the Arena
        /// </summary>
        /// <param name="ball"> The ball to add</param>
        void AddBall(IBall ball);

        /// <summary>
        /// Adds a brick in the Arena
        /// </summary>
        /// <param name="brick"> The brick to add</param>
        void AddBrick(IBrick brick);

        /// <summary>
        /// Adds a powerup in the Arena
        /// </summary>
        /// <param name="powerup"> The powerup to add</param>
        void AddPowerup(IPowerup powerup);

        /// <summary>
        /// Procedure of cleanup of the Arena
        /// </summary>
        void CleanUp();

        /// <summary>
        /// Removes all the Balls in the Arena
        /// </summary>
        void ClearBalls();

        /// <summary>
        /// Removes all the Bricks in the Arena
        /// </summary>
        void ClearBricks();

        /// <summary>
        /// Removes all the powerups in the Arena
        /// </summary>
        void ClearPowerups();

        /// <summary>
        /// Returns the last Ball id inserted in the Arena
        /// </summary>
        /// <returns>The integer representing
        /// the last Ball id inserted in the Arena</returns>
        int GetLastBallId();

        /// <summary>
        /// Returns a random Ball of this Arena
        /// </summary>
        IBall GetRandomBall();

        /// <summary>
        /// Increases the pad's width of an input amount
        /// </summary>
        /// <param name="amount"> The amount to increase</param>
        void IncreasePadWidth(double amount);

        /// <summary>
        /// Checks if the Arena is cleared, or rather, if there aren't any bricks left
        /// except for the ones of indestructible type.
        /// </summary>
        /// <returns>true if the Arena is cleared, false otherwise</returns>
        bool IsCleared();

        /// <summary>
        /// Moves the pad left in the Arena
        /// </summary>
        void MovePadLeft();

        /// <summary>
        /// Moves the pad Right in the Arena
        /// </summary>
        void MovePadRight();

        /// <summary>
        /// Removes a Ball from the Arena
        /// </summary>
        /// <param name="ball">The ball to remove</param>
        void RemoveBall(IBall ball);

        /// <summary>
        /// Removes a Brick from the Arena
        /// </summary>
        /// <param name="brickCoord">The Coord of the brick to remove</param>
        void RemoveBrick(ICoord brickCoord);

        /// <summary>
        /// Removes a Powerup from the Arena
        /// </summary>
        /// <param name="powerup">The powerup to remove</param>
        void RemovePowerup(IPowerup powerup);

        /// <summary>
        /// Resets the Pad and the Ball to the starting Coords
        /// </summary>
        void ResetStartingPosition();

        /// <summary>
        /// Restore the dimension of the Pad
        /// </summary>
        void RestorePadDimension();
    }
}
