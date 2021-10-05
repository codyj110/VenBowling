
namespace VenBowling
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.NumberOfFrames = 10;
            game.NumberOfPins = 10;
            game.RollSimulator = new RollSimulator();
            game.Scorer = new VenScorer();
            game.PlayGame();
            
            var scoreboard = new ConsoleScoreBoard();
            scoreboard.DisplayBoard(game);
            scoreboard.DisplayScore(game.Score);
        }
    }
}