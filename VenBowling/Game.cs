using System.Collections.Generic;

namespace VenBowling
{
    public struct Game
    {
        public IEnumerable<Frame> Frames { get; set; }
        public int Score { get; set; }
    }
}