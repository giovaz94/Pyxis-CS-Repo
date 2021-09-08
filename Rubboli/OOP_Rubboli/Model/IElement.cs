using OOP_Rubboli.util;

namespace OOP_Rubboli
{
    public interface IElement
    {
        /// <summary>
        /// Returns the Element's Dimension.
        /// </summary>
        Dimension Dimension
        {
            get;
        }

        /// <summary>
        /// Sets the Element's Height.
        /// </summary>
        double Height
        {
            set;
        }
        
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
        /// Returns and sets the Element's Pace.
        /// </summary>
        IVector Pace
        {
            get;
            set;
        }

        /// <summary>
        /// Returns and sets the Element's Position.
        /// </summary>
        ICoord Position
        {
            get;
            set;
        }

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
        int UpdateTimeMultiplier
        {
            get;
        }

        /// <summary>
        /// Sets the Element's Width.
        /// </summary>
        double Width
        {
            set;
        }
    }
}