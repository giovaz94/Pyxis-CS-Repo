using System.Collections.Generic;
using OOP_Rubboli.util;

namespace OOP_Rubboli
{
    public interface IBall
    {
        int Id
        {
            get;
        }

        Vector Pace
        {
            get;
            set;
        }
        BallType Type
        {
            get;
            set;
        }

    }
}