using System.Collections.Generic;
using VenBowling;
using Xunit;

namespace VenBowlingTests
{
    public class ScorerTests
    {
        [Fact]
        public void ScoresSparesAndStrikesCorrectly()
        {
            // setup
            var scorer = new VenScorer();
            var expectedScore = 110;
            var game = new Game
            {
                NumberOfFrames = 10,
                NumberOfPins = 10,
                RollSimulator = new RollSimulator()
            };

            var frame1 = new Frame
            {
                Rolls = new List<Roll>() { new() { RoleScore = 4 }, new() { RoleScore = 3 } },
                PinsRemaining = 3
            };
            game.Frames.Add(frame1);
            var frame2 = new Frame
            { 
                Rolls = new List<Roll>() { new() { RoleScore = 7 }, new() { RoleScore = 3 } },
                PinsRemaining = 0
            };
            game.Frames.Add(frame2);
            var frame3 = new Frame
            {
                Rolls = new List<Roll>() { new() { RoleScore = 5 }, new() { RoleScore = 2 } },
                PinsRemaining = 3
            };
            game.Frames.Add(frame3);
            var frame4 = new Frame
            {
                Rolls = new List<Roll>() { new() { RoleScore = 8 }, new() { RoleScore = 1 } },
                PinsRemaining = 1
            };
            game.Frames.Add(frame4);
            var frame5 = new Frame
            {
                Rolls = new List<Roll>() { new() { RoleScore = 4 }, new() { RoleScore = 6 } },
                PinsRemaining = 0
            };
            game.Frames.Add(frame5);
            var frame6 = new Frame
            {
                Rolls = new List<Roll>() { new() { RoleScore = 2 }, new() { RoleScore = 4 } },
                PinsRemaining = 4
            };
            game.Frames.Add(frame6);
            var frame7 = new Frame
            {
                Rolls = new List<Roll>() { new() { RoleScore = 8 }, new() { RoleScore = 0 } },
                PinsRemaining = 2
            };
            game.Frames.Add(frame7);
            var frame8 = new Frame
            {
                Rolls = new List<Roll>() { new() { RoleScore = 8 }, new() { RoleScore = 0 } },
                PinsRemaining = 2
            };
            game.Frames.Add(frame8);
            var frame9 = new Frame
            {
                Rolls = new List<Roll>() { new() { RoleScore = 8 }, new() { RoleScore = 2 } },
                PinsRemaining = 0
            };
            game.Frames.Add(frame9);
            var frame10 = new Frame
            {
                Rolls = new List<Roll>() { new() { RoleScore = 10 }, new() { RoleScore = 1 }, new() { RoleScore = 7 } },
                PinsRemaining = 10
            };
            game.Frames.Add(frame10);
            

            // act
            var actualScore = scorer.ScoreGame(game);

            // assert
            Assert.Equal(expectedScore, actualScore);
        }
        
        [Fact]
        public void ScoresSparesAndStrikesCorrectlyWithStrikes()
        {
            // setup
            var scorer = new VenScorer();
            var expectedScore = 111;
            var game = new Game
            {
                NumberOfFrames = 10,
                NumberOfPins = 10,
                RollSimulator = new RollSimulator()
            };

            var frame1 = new Frame
            {
                Rolls = new List<Roll>() { new() { RoleScore = 4 }, new() { RoleScore = 3 } },
                PinsRemaining = 3
            };
            game.Frames.Add(frame1);
            var frame2 = new Frame
            { 
                Rolls = new List<Roll>() { new() { RoleScore = 7 }, new() { RoleScore = 3 } },
                PinsRemaining = 0
            };
            game.Frames.Add(frame2);
            var frame3 = new Frame
            {
                Rolls = new List<Roll>() { new() { RoleScore = 5 }, new() { RoleScore = 2 } },
                PinsRemaining = 3
            };
            game.Frames.Add(frame3);
            var frame4 = new Frame
            {
                Rolls = new List<Roll>() { new() { RoleScore = 8 }, new() { RoleScore = 1 } },
                PinsRemaining = 1
            };
            game.Frames.Add(frame4);
            var frame5 = new Frame
            {
                Rolls = new List<Roll>() { new() { RoleScore = 4 }, new() { RoleScore = 6 } },
                PinsRemaining = 0
            };
            game.Frames.Add(frame5);
            var frame6 = new Frame
            {
                Rolls = new List<Roll>() { new() { RoleScore = 2 }, new() { RoleScore = 4 } },
                PinsRemaining = 4
            };
            game.Frames.Add(frame6);
            var frame7 = new Frame
            {
                Rolls = new List<Roll>() { new() { RoleScore = 8 }, new() { RoleScore = 0 } },
                PinsRemaining = 2
            };
            game.Frames.Add(frame7);
            var frame8 = new Frame
            {
                Rolls = new List<Roll>() { new() { RoleScore = 8 }, new() { RoleScore = 0 } },
                PinsRemaining = 2
            };
            game.Frames.Add(frame8);
            var frame9 = new Frame
            {
                Rolls = new List<Roll>() { new() { RoleScore = 10 }, new() { RoleScore = 0 } },
                PinsRemaining = 0
            };
            game.Frames.Add(frame9);
            var frame10 = new Frame
            {
                Rolls = new List<Roll>() { new() { RoleScore = 10 }, new() { RoleScore = 1 }, new() { RoleScore = 7 } },
                PinsRemaining = 10
            };
            game.Frames.Add(frame10);
            

            // act
            var actualScore = scorer.ScoreGame(game);

            // assert
            Assert.Equal(expectedScore, actualScore);
        }
    }
}