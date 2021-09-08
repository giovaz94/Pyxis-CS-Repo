namespace OOP_Rubboli.util
{
    public interface IDimension
    {
        /// <summary>
        /// Returns the Dimension copy.
        /// </summary>
        /// <returns>
        /// The Dimension.
        /// </returns>
        Dimension CopyOf();

        /// <summary>
        /// Returns and sets the Dimension's height.
        /// </summary>
        double Height
        {
            get;
            set;
        }
        
        /// <summary>
        /// Increases the height value.
        /// </summary>
        /// <param name="increaseValue">
        /// The height value to add.
        /// </param>
        void IncreaseHeight(double increaseValue);
        
        /// <summary>
        /// Increases the width value.
        /// </summary>
        /// <param name="increaseValue">
        /// The width value to add.
        /// </param>
        void IncreaseWidth(double increaseValue);

        /// <summary>
        /// Returns and sets the Dimension's width.
        /// </summary>
        double Width
        {
            get;
            set;
        }
    }
}