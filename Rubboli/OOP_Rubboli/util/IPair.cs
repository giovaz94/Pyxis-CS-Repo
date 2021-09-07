namespace OOP_Rubboli.util
{
    public interface IPair<TFirst, TSecond>
    {
        TFirst First
        {
            get;
            set;
        }

        TSecond Second
        {
            get;
            set;
        }
    }
}