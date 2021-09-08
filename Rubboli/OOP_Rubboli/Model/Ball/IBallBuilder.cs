using OOP_Rubboli.util;

namespace OOP_Rubboli
{
    public interface IBallBuilder
    {
        /// <summary>
        /// Sets the Ball's BallType.
        /// </summary>
        /// <param name="type">
        /// The type of the Ball.
        /// </param>
        /// <returns>
        /// The BallBuilder.
        /// </returns>
        IBallBuilder Type(BallType type);

        /// <summary>
        /// Builds the Ball checking all fields are set.
        /// </summary>
        /// <returns>
        /// The Ball.
        /// </returns>
        IBall Build();

        /// <summary>
        /// Sets the Ball's id.
        /// </summary>
        /// <param name="id">
        /// The id to set.
        /// </param>
        /// <returns>
        /// The BallBuilder.
        /// </returns>
        IBallBuilder Id(int id);

        /// <summary>
        /// Sets the Ball's Coord position.
        /// </summary>
        /// <param name="position">
        /// The position to set.
        /// </param>
        /// <returns>
        /// The BallBuilder.
        /// </returns>
        IBallBuilder InitialPosition(ICoord position);

        /// <summary>
        /// Sets the Ball's Vector pace.
        /// </summary>
        /// <param name="pace">
        /// The Vector to set.
        /// </param>
        /// <returns>
        /// The BallBuilder.
        /// </returns>
        IBallBuilder Pace(IVector pace);
    }
}