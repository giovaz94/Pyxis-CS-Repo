﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traini.Model.Element;
using Traini.Model.Util;

namespace Traini.Model.Arena
{
    class Arena : IArena
    {
        private static double PAD_X_MOVEMENT = 10;
        private static double MAX_PAD_X_DIMENSION = 200;
        private static double MIN_PAD_X_DIMENSION = 10;
        private IDictionary<ICoord, IBrick> _brickDictionary;
        private ISet<IBall> _ballSet;
        private ISet<IPowerup> _powerupSet;
        private IPad _pad;

        private ICoord StartingBallPosition { get; set; }
        private double StartingBallModule { get; set; }
        private ICoord StartingPadPosition { get; set; }
        private IDimension StartingPadDimension { get; set; }

        public IPad Pad
        {
            get { return this._pad; }
            set
            {
                this.StartingPadPosition = value.Position;
                this.StartingPadDimension = value.Dimension;
                this._pad = value;
            }
        }

        public IDimension Dimension
        {
            get { return this.Dimension.CopyOf(); }
            private set { this.Dimension = value; }
        }

        public ISet<IBall> Balls
        {
            get { return new HashSet<IBall>(this._ballSet); }
            private set { this._ballSet = value; }
        }

        public ISet<IPowerup> Powerups
        {
            get { return new HashSet<IPowerup>(this._powerupSet); }
            private set { this._powerupSet = value; }
        }

        public ISet<IBrick> Bricks
        {
            get { return new HashSet<IBrick>(this._brickDictionary.Values); }
        }

        public Arena(IDimension inputDimension)
        {
            this._brickDictionary = new Dictionary<ICoord, IBrick>();
            this.Balls = new HashSet<IBall>();
            this.Powerups = new HashSet<IPowerup>();
            this.Dimension = inputDimension;
        }

        private ICoord CalculatePadNewXCoord(double dx)
        {
            var updatedCoord = this.Pad.Position;
            updatedCoord.SumXValue(dx);
            return updatedCoord;
        }

        private bool CanModifyPadWidth(double amount)
        {
            var padWidth = this.Pad.Dimension.Width + amount;
            return padWidth < MAX_PAD_X_DIMENSION && padWidth > MIN_PAD_X_DIMENSION;
        }

        private void AdjustPositionOnResize(double resizeAmount)
        {
            var padWidth = this.Pad.Dimension.Width;
            var padPosition = this.Pad.Position;
            var halfIncrement = (padWidth + resizeAmount) / 2;
            double offset = 0;
            if (padPosition.X + halfIncrement > this.Dimension.Width)
            {
                offset = this.Dimension.Width - padPosition.X - halfIncrement;
            }
            else if (padPosition.X - halfIncrement < 0)
            {
                offset = -(padPosition.X - halfIncrement);
            }
            this.Pad.Position = new Coord(padPosition.X + offset, padPosition.Y);
        }

        private void ModifyPadWidth(double amount)
        {
            if (CanModifyPadWidth(amount))
            {
                this.Pad.IncreaseWidth(amount);
                this.AdjustPositionOnResize(amount);
            }
        }

        public void AddBall(IBall ball)
        {
            this._ballSet.Add(ball);
        }

        public void AddBrick(IBrick brick)
        {
            if (!this._brickDictionary.ContainsKey(brick.Position))
            {
                this._brickDictionary.Add(brick.Position, brick);
            }
        }

        public void AddPowerup(IPowerup powerup)
        {
            this._powerupSet.Add(powerup);
        }

        public void CleanUp()
        {
            throw new NotImplementedException();
        }

        public void ClearBalls()
        {
            foreach (IBall ball in this.Balls)
            {
                this.RemoveBall(ball);
            }
        }

        public void ClearBricks()
        {
            foreach (IBrick brick in this.Bricks)
            {
                this.RemoveBrick(brick.Position);
            }
        }

        public void ClearPowerups()
        {
            foreach (IPowerup powerup in this.Powerups)
            {
                this.RemovePowerup(powerup);
            }
        }

        public int GetLastBallId()
        {
            return Math.Max(this._ballSet.Select<IBall, int>(ball => ball.Id).Max(), 0);
        }

        public IBall GetRandomBall()
        {
            var ballList = new List<IBall>(this._ballSet);
            return ballList[new Random().Next(ballList.Count)];
        }

        public void IncreasePadWidth(double amount)
        {
            this.ModifyPadWidth(amount);
        }

        public bool IsCleared()
        {
            return this.Bricks.All(b => b.IsIndestructible());
        }

        public void MovePadLeft()
        {
            var oldPosition = this.Pad.Position;
            var newPosition = this.CalculatePadNewXCoord(-PAD_X_MOVEMENT);
            if (newPosition.X < this.Pad.Dimension.Width / 2)
            {
                newPosition = new Coord(this.Pad.Dimension.Width / 2, this.Pad.Position.Y);
            }
            this.Pad.Position = this.Balls.Any(b => b.Hitbox.IsCollidingWithHB(this.Pad.Hitbox))
                              ? oldPosition
                              : newPosition;
        }

        public void MovePadRight()
        {
            var oldPosition = this.Pad.Position;
            var newPosition = this.CalculatePadNewXCoord(PAD_X_MOVEMENT);
            var maxX = this.Dimension.Width - this.Pad.Dimension.Width / 2;
            if (newPosition.X > maxX)
            {
                newPosition = new Coord(maxX, this.Pad.Position.Y);
            }
            this.Pad.Position = this.Balls.Any(b => b.Hitbox.IsCollidingWithHB(this.Pad.Hitbox))
                              ? oldPosition
                              : newPosition;
        }

        public void RemoveBall(IBall ball)
        {
            this._ballSet.Remove(ball);
        }

        public void RemoveBrick(ICoord brickCoord)
        {
            this._brickDictionary.Remove(brickCoord);
        }

        public void RemovePowerup(IPowerup powerup)
        {
            this._powerupSet.Remove(powerup);
        }

        public void ResetStartingPosition()
        {
            var factory = new ElementFactory();
            this.Pad.Position = this.StartingPadPosition.CopyOf();
            this.ClearBalls();
            this._ballSet.Add(factory.createBallWithRandomAngle(1, BallType.NormalBall,
                                        this.StartingBallPosition.CopyOf(), this.StartingBallModule));
        }

        public void RestorePadDimension()
        {
            var difference = this.StartingPadDimension.Width - this.Pad.Dimension.Width;
            this.Pad.Dimension = StartingPadDimension.CopyOf();
            this.AdjustPositionOnResize(difference);
        }
    }
}