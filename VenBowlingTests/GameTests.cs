using System.Linq;
using VenBowling;
using Xunit;

namespace VenBowlingTests
{
    public class GameTests
    {
        [Fact]
        public void GameProvidesFramesAndRolls()
        {
            // setup
            var game = new Game();
            game.NumberOfFrames = 10;
            game.NumberOfPins = 10;
            game.RollSimulator = new RollSimulator();
            game.Scorer = new VenScorer();

            var expectedFramesCount = 10;
            var expectedRollsCount = 21;

            // act
            game.PlayGame();
            var actualFrameCount = game.Frames.Count;
            var actualRollsCount = game.Frames.Sum(f => f.Rolls.Count);
            // assert
            Assert.Equal(expectedFramesCount, actualFrameCount);
            Assert.Equal(expectedRollsCount, actualRollsCount);
        }
        
        [Fact]
        public void GameProvidesScore()
        {
            // setup
            var game = new Game();
            game.NumberOfFrames = 10;
            game.NumberOfPins = 10;
            game.RollSimulator = new RollSimulator();
            game.Scorer = new VenScorer();

            // act
            game.PlayGame();
            // assert
            Assert.True(game.Score > 0);
        }
    }
}