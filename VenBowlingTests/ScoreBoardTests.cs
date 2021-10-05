using System.Collections.Generic;
using System.Linq;
using VenBowling;
using Xunit;

namespace VenBowlingTests
{
    public class ScoreBoardTests
    {
        public static List<string> WriteLines = new();
        public static List<string> WriteTexts = new();
        
        
        [Fact]
        public void ScoreBoardDrawsBoarders()
        {
            // setup
            var expectedBoarder =  "-----------------------------------------------";
            var expectedBoarders = 2;

            var scoreboard = new MockedConsoleScoreBoard();
            
            // act
            scoreboard.DisplayBoard(GetSampleGame());
            var foundBoarders = WriteLines.Count(l => l.Contains(expectedBoarder));

            // assert
            Assert.Equal(expectedBoarders, foundBoarders);
            
            // clean up
            WriteLines.Clear();
        }
        
        [Fact]
        public void ScoreBoardDrawsScore()
        {
            // setup
            var param = 110;
            var expectedText =  $"Total Score: {param}";
            var expectedCount = 1;
            
            var scoreboard = new MockedConsoleScoreBoard();
            
            // act
            scoreboard.DisplayScore(110);
            var actualCount = WriteLines.Count(l => l.Contains(expectedText));

            // assert
            Assert.Equal(expectedCount, actualCount);
            
            // clean up
            WriteLines.Clear();
        }

        [Fact]
        public void ScoreBoardDrawsHeader()
        {
            // setup
            var expectedHeader = $" {"Frame",-10} | {"Roll1",-10} | {"Roll2",-10} | {"Roll3",-10} |";
            var expectedCount = 1;

            var scoreboard = new MockedConsoleScoreBoard();
            
            // act
            scoreboard.DisplayBoard(GetSampleGame());
            var actualCount = WriteLines.Count(l => l.Contains(expectedHeader));

            // assert
            Assert.Equal(expectedCount, actualCount);
            
            // clean up
            WriteLines.Clear();
        }
        
        [Fact]
        public void ScoreBoardDrawsFrame()
        {
            // setup
            var expectedFrame = $" {"Frame1",-10} | {"1",-10} | {"2",-10} | {"3",-10} |\r\n";
            var expectedCount = 1;

            var scoreboard = new MockedConsoleScoreBoard();
            
            // act
            scoreboard.DisplayBoard(GetSampleGame());
            var actualCount = WriteLines.Count(l => l.Contains(expectedFrame));

            // assert
            Assert.Equal(expectedCount, actualCount);
            
            // clean up
            WriteLines.Clear();
        }

        [Fact]
        public void DrawsInCorrectOrder()
        {
            // setup
            var expectedBoarder =  "-----------------------------------------------";
            var expectedHeader = $" {"Frame",-10} | {"Roll1",-10} | {"Roll2",-10} | {"Roll3",-10} |";
            var expectedFrame = $" {"Frame1",-10} | {"1",-10} | {"2",-10} | {"3",-10} |\r\n";

            var scoreboard = new MockedConsoleScoreBoard();
            
            // act
            scoreboard.DisplayBoard(GetSampleGame());
            var actualFirstBorderPresent = WriteLines[0].Contains(expectedBoarder);
            var actualLastBorderPresent = WriteLines[3].Contains(expectedBoarder);
            var actualHeaderPresent = WriteLines[1].Contains(expectedHeader);
            var actualFramePresent = WriteLines[2].Contains(expectedFrame);

            // assert
            Assert.True(actualFirstBorderPresent);
            Assert.True(actualLastBorderPresent);
            Assert.True(actualHeaderPresent);
            Assert.True(actualFramePresent);
            
            // clean up
            WriteLines.Clear();
        }

        private Game GetSampleGame()
        {
            var roll1 = new List<Roll>()
            {
                new()
                {
                    RoleScore = 1
                },
                new()
                {
                    RoleScore = 2
                },
                new()
                {
                    RoleScore = 3
                }
            };

            var frame = new List<Frame>()
            {
                new()
                {
                    Rolls = roll1,
                    PinsRemaining = 0
                }
            };

            return new Game
            {
                Frames = frame,
                Score = 0
            };
        }
    }

    public class MockedConsoleScoreBoard : ConsoleScoreBoard
    {
        protected override void WriteLine(string lineToWrite)
        {
            ScoreBoardTests.WriteLines.Add(lineToWrite);
        }

        protected override void WriteText(string textToWrite)
        {
            if (textToWrite == "\r\n")
            {
                var newLine = $"{string.Concat(ScoreBoardTests.WriteTexts)}{textToWrite}";
                ScoreBoardTests.WriteLines.Add(newLine);
                ScoreBoardTests.WriteTexts.Clear();
            }
            ScoreBoardTests.WriteTexts.Add(textToWrite);
        }
    }
}