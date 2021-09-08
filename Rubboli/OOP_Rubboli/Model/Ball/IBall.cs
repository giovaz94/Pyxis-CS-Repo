using System.Collections.Generic;
using OOP_Rubboli.util;

namespace OOP_Rubboli
{
    public interface IBall
    {
        /// <summary>
        /// Returns the Ball's id.
        /// </summary>
        int GetId();

        /// <summary>
        /// Returns the Ball's pace.
        /// </summary>
        IVector GetPace();
        
        /// <summary>
        /// Sets the Ball's pace.
        /// </summary>
        /// <param name="inputPace">
        /// The input pace.
        /// </param>
        void SetPace(IVector inputPace);
        
        /// <summary>
        /// Returns the Ball's type.
        /// </summary>
        BallType GetType();
        
        /// <summary>
        /// Sets the Ball's type.
        /// </summary>
        /// <param name="inputType">
        /// The input type.
        /// </param>
        void SetType(BallType inputType);
    }
}