using Antonioni.Level.Status;

namespace Antonioni.Level
{
    public interface ILevel
    {
        void CleanUp();

        void DecreaseLife();

        int GetLevelNumber();

        int GetLives();

        int GetScore();

        void IncreaseScore(int score);

        LevelStatus GetLevelStatus();

        void SetLevelStatus(LevelStatus status);

        void Update(double delta);
    }
}