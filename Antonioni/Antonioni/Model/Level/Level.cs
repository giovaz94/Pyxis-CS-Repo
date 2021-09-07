using System.Threading;
using Antonioni.Arena;
using Antonioni.Level.Status;

namespace Antonioni.Level
{
    public class Level : ILevel
    {
        private int _lives { get; set; }
        private IArena _arena { get; }
        private LevelStatus _levelStatus { get; set; }
        private int _score { get; set; }
        private int _levelNumber { get; }
        
        public Level(IArena inputArena, int levelNumber = 1)
        {
            this._arena = inputArena;
            this._levelNumber = levelNumber;
            this._lives = 3;
            this._levelStatus = LevelStatus.Playing;
        }

        public void DecreaseLife()
        {
            this._lives--;
        }

        public int GetLevelNumber()
        {
            return this._levelNumber;
        }

        public int GetLives()
        {
            return this._lives;
        }

        public int GetScore()
        {
            return this._score;
        }

        public void IncreaseScore(int score)
        {
            this._score += score;
        }

        public LevelStatus GetLevelStatus()
        {
            return this._levelStatus;
        }

        public IArena GetArena()
        {
            return this._arena;
        }

        public void SetLevelStatus(LevelStatus status)
        {
            this._levelStatus = status;
        }

        public void Update(double delta)
        {
            this._arena.Update(delta);
        }
    }
}