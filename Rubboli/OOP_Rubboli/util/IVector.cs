namespace OOP_Rubboli.util
{
    public interface IVector
    {
        /// <summary>
        /// Returns a copy of the Vector.
        /// </summary>
        /// <returns>
        /// The Vector copy.
        /// </returns>
        Vector CopyOf();

        /// <summary>
        /// Returns a new copy of the current Vector rotated by a certain amount of degrees.
        /// </summary>
        /// <param name="rotationAngle">
        /// The rotation angle of the Vector.
        /// </param>
        /// <returns>
        /// A new rotated Vector.
        /// </returns>
        Vector CreateVectorWithSameModule(double rotationAngle);
        
        /// <summary>
        /// Returns Vector's module.
        /// </summary>
        /// <returns>
        /// The module's value.
        /// </returns>
        double GetModule();

        /// <summary>
        /// Returns and sets the Vector's x component.
        /// </summary>
        double X
        {
            get;
            set;
        }

        /// <summary>
        /// Returns and sets the Vector's y component.
        /// </summary>
        double Y
        {
            get;
            set;
        }
    }
}