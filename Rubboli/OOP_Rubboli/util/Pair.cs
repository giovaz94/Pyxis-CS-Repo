namespace OOP_Rubboli.util
{
    public class Pair<TFirst, TSecond> : IPair<TFirst, TSecond> {
        
            public Pair(TFirst first, TSecond second) {
                this.First = first;
                this.Second = second;
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
                return "<" + this.First + "," + this.Second + ">";
            }
    }
}