namespace OOP_Rubboli.util
{
    public class Pair<TFirst, TSecond> : IPair<TFirst, TSecond> {
        
            private TFirst _first;
            private TSecond _second;
            
            public Pair(TFirst first, TSecond second) {
                this._first = first;
                this._second = second;
            }

            public TFirst First
            {
                get;
                set;
            }

            public TSecond Second
            {
                get;
                set;
            }
            
            public override string ToString()
            {
                return "<" + _first + "," + _second + ">";
            }
    }
}