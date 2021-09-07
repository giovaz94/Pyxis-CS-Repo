using OOP_Rubboli.util;

namespace OOP_Rubboli
{
    public interface IBallBuilder
    {
        IBallBuilder Type(BallType type);

        IBall Build();

        IBallBuilder Id(int id);

        IBallBuilder InitialPosition(Coord position);

        IBallBuilder Pace(Vector pace);
    }
}