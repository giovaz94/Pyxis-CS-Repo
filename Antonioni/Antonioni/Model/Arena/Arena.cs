using System;

namespace Antonioni.Arena
{
    public class Arena: IArena
    {
        private int Updates { get; set; }
        public void Update(double delta)
        {
            this.Updates++;
            Console.WriteLine("Updating ! Current updates :" + this.Updates);
        }
    }
}