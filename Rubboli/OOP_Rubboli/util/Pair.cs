using System;
using System.Security.Cryptography;
using System.Text;

namespace OOP_Rubboli.util
{
    public class Pair<TFirst, TSecond> : IPair<TFirst, TSecond> {
        
            public Pair(TFirst first, TSecond second) {
                this.First = first;
                this.Second = second;
            }
            
            public override bool Equals(object o)
            {
                if (this == o)
                {
                    return true;
                }
                if (!(o is Pair<TFirst, TSecond>))
                {
                    return false;
                }
                Pair<TFirst, TSecond> pair = (Pair<TFirst, TSecond>) o;
                return Object.Equals(this.First, pair.First) && Object.Equals(this.Second, pair.Second);
            }

            private TFirst First
            {
                get;
                set;
            }
            
            public override int GetHashCode()
            {
                var md5Hasher = MD5.Create();
                var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(this.ToString()));
                var ivalue = BitConverter.ToInt32(hashed, 0);
                return ivalue;
            }

            private TSecond Second
            {
                get;
                set;
            }
            
            public override string ToString()
            {
                return "<" + this.First + "," + this.Second + ">";
            }

            public TFirst GetFirst()
            {
                return this.First;
            }

            public void SetFirst(TFirst inputFirst)
            {
                this.First = inputFirst;
            }

            public TSecond GetSecond()
            {
                return this.Second;
            }

            public void SetSecond(TSecond inputSecond)
            {
                this.Second = inputSecond;
            }
    }
}