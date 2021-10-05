using System;
using System.Linq;

namespace VenBowling
{
    public class ConsoleScoreBoard: IScoreBoard
    {
        public void DisplayScore(int score)
        {
            WriteLine($"Total Score: {score}");
        }
        
        public void DisplayBoard(Game game)
        {
            DrawBorder();
            DrawHeaders();
            foreach (var gameFrame in game.Frames.Select((frame, i) => (frame, i)))
            {
                var frameName = $"Frame{gameFrame.i + 1}";
                DrawFrames(gameFrame.frame, frameName);
                NewLine();
            }
            DrawBorder();
        }

        private void DrawFrames(Frame frame, string frameName)
        {
            DrawColumn(frameName);
            
            foreach (var frameRoll in frame.Rolls)
            {
                DrawColumn(frameRoll.RoleScore.ToString());
            }
        }

        private void NewLine()
        {
            WriteText("\r\n");
        }

        private void DrawColumn(string textToWrite)
        {
            var column = $" {textToWrite, -10} |";
            WriteText(column);
        }

        private void DrawHeaders()
        {
            var headers = $" {"Frame",-10} | {"Roll1",-10} | {"Roll2",-10} | {"Roll3",-10} |";
            WriteLine(headers);
        }

        private void DrawBorder()
        {
            var border = "-----------------------------------------------";   
            WriteLine(border);
        }

        protected virtual void WriteText(string textToWrite)
        {
            Console.Write(textToWrite);
        }

        protected virtual void WriteLine(string lineToWrite)
        {
            Console.WriteLine(lineToWrite);
        }
    }
}