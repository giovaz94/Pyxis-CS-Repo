using System.Threading;
using Antonioni.Arena;
using Antonioni.Level.Status;

namespace Antonioni.Level
{
    public class Level : ILevel
    {
        private int Lives { get; set; }
        private IArena Arena { get; set; }
        private LevelStatus LevelStatus { get; set; }
        private int Score { get; set; }
        private int LevelNumber { get; }
        
        public Level(IArena inputArena, int levelNumber = 1)
        {
            this.Arena = inputArena;
            this.LevelNumber = levelNumber;
            this.Lives = 3;
            this.LevelStatus = LevelStatus.Playing;
        }

        public void DecreaseLife()
        {
            this.Lives--;
        }

        public int GetLevelNumber()
        {
            return this.LevelNumber;
        }

        public int GetLives()
        {
            return this.Lives;
        }

        public int GetScore()
        {
            return this.Score;
        }

        public void IncreaseScore(int score)
        {
            this.Score += score;
        }

        public LevelStatus GetLevelStatus()
        {
            return this.LevelStatus;
        }

        public IArena GetArena()
        {
            return this.Arena;
        }

        public void SetLevelStatus(LevelStatus status)
        {
            this.LevelStatus = status;
        }

        public void Update(double delta)
        {
            this.Arena.Update(delta);
        }
    }
}