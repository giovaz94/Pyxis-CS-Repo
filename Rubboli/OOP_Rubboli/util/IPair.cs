namespace OOP_Rubboli.util
{
    public interface IPair<TFirst, TSecond>
    {
        /// <summary>
        /// Returns the Pair's first value.
        /// </summary>
        TFirst GetFirst();

        /// <summary>
        /// Sets the Pair's first value.
        /// </summary>
        /// <param name="inputFirst">
        /// The input value.
        /// </param>
        void SetFirst(TFirst inputFirst);
        
        /// <summary>
        /// Returns the Pair's second value.
        /// </summary>
        TSecond GetSecond();

        /// <summary>
        /// Sets the Pair's second value.
        /// </summary>
        /// <param name="inputSecond">
        /// The input value.
        /// </param>
        void SetSecond(TSecond inputSecond);
    }
}