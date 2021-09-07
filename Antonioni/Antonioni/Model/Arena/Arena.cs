using System;

namespace Antonioni.Arena
{
    public class Arena: IArena
    {
        private int _updates { get; set; }
        public void Update(double delta)
        {
            this._updates++;
            Console.WriteLine("Updating ! Current updates :" + this._updates);
        }
    }
}