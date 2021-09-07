namespace OOP_Rubboli.util
{
    public interface IVector
    {
        Vector CopyOf();

        Vector CreateVectorWithSameModule(double rotationAngle);
        
        double GetModule();

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