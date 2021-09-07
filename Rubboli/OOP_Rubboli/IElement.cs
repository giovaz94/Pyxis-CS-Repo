using OOP_Rubboli.util;

namespace OOP_Rubboli
{
    public interface IElement
    {
        Dimension Dimension
        {
            get;
        }

        double Height
        {
            set;
        }
        
        void IncreaseHeight(double increaseValue);

        void IncreaseWidth(double increaseValue);

        Vector Pace
        {
            get;
            set;
        }

        Coord Position
        {
            get;
            set;
        }

        void Update(double dt);

        int UpdateTimeMultiplier
        {
            get;
        }

        double Width
        {
            set;
        }
    }
}