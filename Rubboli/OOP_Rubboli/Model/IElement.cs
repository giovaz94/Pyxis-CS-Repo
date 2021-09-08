using OOP_Rubboli.util;

namespace OOP_Rubboli
{
    public interface IElement
    {
        /// <summary>
        /// Returns the Element's Dimension.
        /// </summary>
        Dimension GetDimension();

        /// <summary>
        /// Sets the Element's height.
        /// </summary>
        /// <param name="inputHeight">
        /// The input height.
        /// </param>
        void SetHeight(double inputHeight);
        
        /// <summary>
        /// Increases the Element's height value.
        /// </summary>
        /// <param name="increaseValue">
        /// The value to increase.
        /// </param>
        void IncreaseHeight(double increaseValue);

        /// <summary>
        /// Increases the Element's width value.
        /// </summary>
        /// <param name="increaseValue">
        /// The value to increase.
        /// </param>
        void IncreaseWidth(double increaseValue);

        /// <summary>
        /// Returns the Element's Pace.
        /// </summary>
        IVector GetPace();
        
        /// <summary>
        /// Sets the Element's Pace.
        /// </summary>
        /// <param name="inputPace">
        /// The input pace.
        /// </param>
        void SetPace(IVector inputPace);

        /// <summary>
        /// Returns the Element's Position.
        /// </summary>
        ICoord GetPosition();

        /// <summary>
        /// Sets the Element's Position.
        /// </summary>
        /// <param name="inputPosition">
        /// The input position.
        /// </param>
        void SetPosition(ICoord inputPosition);

        /// <summary>
        /// Executes an update on the Element.
        /// </summary>
        /// <param name="dt">
        /// The elapsed time between two updates.
        /// </param>
        void Update(double dt);

        /// <summary>
        /// Returns the update time multiplier.
        /// </summary>
        int GetUpdateTimeMultiplier();

        /// <summary>
        /// Sets the Element's Width.
        /// </summary>
        void SetWidth(double inputWidth);
    }
}