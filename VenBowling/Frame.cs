using System.Collections.Generic;

namespace VenBowling
{
    public struct Frame
    {
        public IEnumerable<Roll> Rolls { get; set; }
        public int PinsRemaining { get; set; }
    }
}