using System;
using System.Collections;
using System.ComponentModel;
using System.IO;

namespace OOP_Rubboli
{
    public enum BallType
    {
        NormalBall,
        AtomicBall,
        SteelBall
    }

    static class TypeMethods
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool Bounce(this BallType bT) 
        {
            switch (bT)
            {
                case BallType.AtomicBall:
                    return false;
                default:
                    return true;
            }
        }

        public static int? GetDamage(this BallType bT)
        {
            switch (bT)
            {
                case BallType.AtomicBall:
                    return null;
                case BallType.SteelBall:
                    return null;
                default:
                    return 1;
            }
        }
        
        public static double GetPaceMultiplier(this BallType bT)
        {
            switch (bT)
            {
                default:
                    return 1;
            }
        }

        public static string GetTypeName(this BallType bT)
        {
            switch (bT)
            {
                case BallType.AtomicBall:
                    return "Atomic";
                case BallType.SteelBall:
                    return "Steel";
                case BallType.NormalBall:
                    return "Normal";
                default:
                    return "Error";
            }
        }
    }
}