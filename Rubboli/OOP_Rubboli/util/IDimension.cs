namespace OOP_Rubboli.util
{
    public interface IDimension
    {
        Dimension CopyOf();

        double Height
        {
            get;
            set;
        }
        
        void IncreaseHeight(double increaseValue);
        
        void IncreaseWidth(double increaseValue);
        
        void SetHeight(double height);
        
        void SetWidth(double width);

        double Width
        {
            get;
            set;
        }
    }
}