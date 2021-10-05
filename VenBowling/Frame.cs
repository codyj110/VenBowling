using System.Collections.Generic;

namespace VenBowling
{
    public class Frame
    {
        public List<Roll> Rolls = new();
        public int PinsRemaining { get; set; }
    }
}