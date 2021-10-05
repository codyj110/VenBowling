using System.Collections.Generic;
using System.Linq;
using VenBowling;
using Xunit;

namespace VenBowlingTests
{
    public class RollSimulatorTests
    {
        [Fact]
        public void GeneratesValidRandomRolls()
        {
            // setup
            var rolls = new List<int>();
            var rollSimulator = new RollSimulator();

            // act
            for (int x = 0; x < 1000; x++)
            {
                rolls.Add(rollSimulator.Roll());
            }

            // assert
            Assert.True(rolls.All(r => r <= 10 && r >= 0));
        }
    }
}