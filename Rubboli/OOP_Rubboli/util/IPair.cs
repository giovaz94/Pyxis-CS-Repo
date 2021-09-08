namespace OOP_Rubboli.util
{
    public interface IPair<TFirst, TSecond>
    {
        /// <summary>
        /// Returns and sets the Pair's first value.
        /// </summary>
        TFirst First
        {
            get;
            set;
        }

        /// <summary>
        /// Returns and sets the Pair's second value.
        /// </summary>
        TSecond Second
        {
            get;
            set;
        }
    }
}