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
        /// Returns the Dimension's height.
        /// </summary>
        double GetHeight();

        /// <summary>
        /// Sets the Dimension's height.
        /// </summary>
        /// <param name="inputHeight">
        /// The input height.
        /// </param>
        void SetHeight(double inputHeight);
        
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
        /// Returns the Dimension's width.
        /// </summary>
        double GetWidth();

        /// <summary>
        /// Sets the the Dimension's width.
        /// </summary>
        /// <param name="inputWidth">
        /// The input width.
        /// </param>
        void SetWidth(double inputWidth);
    }
}