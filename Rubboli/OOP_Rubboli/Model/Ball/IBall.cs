using System.Collections.Generic;
using OOP_Rubboli.util;

namespace OOP_Rubboli
{
    public interface IBall
    {
        /// <summary>
        /// Returns the Ball's id.
        /// </summary>
        int Id
        {
            get;
        }

        /// <summary>
        /// Returns and sets the Ball's pace.
        /// </summary>
        IVector Pace
        {
            get;
            set;
        }
        
        /// <summary>
        /// Returns and sets the Ball's type.
        /// </summary>
        BallType Type
        {
            get;
            set;
        }

    }
}