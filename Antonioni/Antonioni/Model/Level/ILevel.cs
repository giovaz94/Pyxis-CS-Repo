using Antonioni.Arena;
using Antonioni.Level.Status;

namespace Antonioni.Level
{
    public interface ILevel
    {
        void DecreaseLife();

        int GetLevelNumber();

        int GetLives();

        int GetScore();

        void IncreaseScore(int score);

        LevelStatus GetLevelStatus();

        IArena GetArena();

        void SetLevelStatus(LevelStatus status);

        void Update(double delta);
    }
}