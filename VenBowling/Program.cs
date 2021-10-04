using System;
using System.Collections.Generic;

namespace VenBowling
{
    class Program
    {
        static void Main(string[] args)
        {
            var roll1 = new List<Roll>()
            {
                new Roll
                {
                    RoleScore = 1
                },
                new Roll()
                {
                    RoleScore = 2
                },
                new Roll()
                {
                    RoleScore = 3
                }
            };

            var frame = new List<Frame>()
            {
                new Frame
                {
                    Rolls = roll1,
                    PinsRemaining = 0
                }
            };

            var game = new Game
            {
                Frames = frame,
                Score = 0
            };

            var scoreboard = new ConsoleScoreBoard();
            scoreboard.DisplayBoard(game);
        }
    }
}