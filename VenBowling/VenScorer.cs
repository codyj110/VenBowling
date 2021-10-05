using System.Linq;

namespace VenBowling
{
    public class VenScorer: IScorer
    {
        public int ScoreGame(Game game)
        {
            var score = 0;
            foreach (var gameFrame in game.Frames.Select((frame, i) => (frame, i)))
            {
                score += gameFrame.frame.Rolls.Sum(x => x.RoleScore);

                score = ScoreStrikeAndSpare(game, gameFrame, score, game.NumberOfPins);
            }

            return score;
        }

        private int ScoreStrikeAndSpare(Game game, (Frame frame, int i) gameFrame, int score, int numberOfPins)
        {
            return ScoreIfNotLastFrame(game, gameFrame, score, numberOfPins);
        }

        private int ScoreIfNotLastFrame(Game game, (Frame frame, int i) gameFrame, int score, int numberOfPins)
        {
            if (NotLastFrame(game, gameFrame))
            {
                score = ScoreStrike(game, gameFrame, score, numberOfPins);
                score = ScoreSpare(game, gameFrame, score, numberOfPins);
            }

            return score;
        }

        private int ScoreSpare(Game game, (Frame frame, int i) gameFrame, int score, int numberOfPins)
        {
            var nextFrameIndex = gameFrame.i + 1;
            if (FrameIsSpare(gameFrame.frame, numberOfPins))
            {
                foreach (var roll in game.Frames[nextFrameIndex].Rolls.Take(1))
                {
                    score += roll.RoleScore;
                }
            }

            return score;
        }

        private int ScoreStrike(Game game, (Frame frame, int i) gameFrame, int score, int numberOfPins)
        {
            if (FrameIsStrike(gameFrame.frame, numberOfPins))
            {
                foreach (var roll in game.Frames[gameFrame.i + 1].Rolls.Take(2))
                {
                    score += roll.RoleScore;
                }
            }

            return score;
        }

        private static bool NotLastFrame(Game game, (Frame frame, int i) gameFrame)
        {
            return gameFrame.i < game.NumberOfFrames - 1;
        }

        private bool FrameIsStrike(Frame frame, int numberOfPins)
        {
            return frame.PinsRemaining == 0 && frame.Rolls.First().RoleScore == numberOfPins;
        }

        private bool FrameIsSpare(Frame frame, int numberOfPins)
        {
            return frame.PinsRemaining == 0 && frame.Rolls.First().RoleScore != numberOfPins;
        }
    }
}