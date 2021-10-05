using System;

namespace VenBowling
{
    public class RollSimulator: IRollSimulator
    {
        public int Roll(int remainingPins = 10)
        {
            Random random = new();
            return random.Next(0,remainingPins + 1);
        }
    }
}