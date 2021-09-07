namespace OOP_Rubboli.util
{
    public interface ICoord
    {
        Coord CopyOf();

        double Distance(Coord coord);

        double Distance(double px, double py);

        void SetXy(double xValue, double yValue);

        void SumCoord(Coord coord);

        void SumValues(double xValue, double yValue);

        void SumVector(Vector vector);

        void SumVector(Vector vector, double multiplier);

        void SumXValue(double xValue);

        void SumYValue(double yValue);

        double X
        {
            get;
            set;
        }
        
        double Y
        {
            get;
            set;
        }
    }
}