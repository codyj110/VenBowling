using System.Collections.Generic;

namespace VenBowling
{
    public class Game
    {
        public List<Frame> Frames = new();
        public int Score { get; set; }
        public int NumberOfPins { get; set; }
        public int NumberOfFrames { get; set; }
        
        public IRollSimulator RollSimulator { get; set; }
        
        public IScorer Scorer { get; set; }

        public void PlayGame()
        {
            PlayFrames();
        }
        
        private void PlayFrames()
        {
            for (int frameNumber = 1; frameNumber <= NumberOfFrames; frameNumber++)
            {
                var frame = PlayFrame(frameNumber, NumberOfPins, NumberOfFrames);
                Frames.Add(frame);
            }

            Score = Scorer.ScoreGame(this);
        }
        
        private Frame PlayFrame(int frameNumber, int numberOfPins, int numberOfFrames)
        {
            var frame = new Frame();
            frame.PinsRemaining = numberOfPins;
            var maxRollNumber = 3;
            for (int rollNumber = 0; rollNumber < maxRollNumber; rollNumber++)
            {
                RollIfPinsRemaining(frame, rollNumber, frameNumber, numberOfFrames);
            }

            return frame;
        }
        
        private void RollIfPinsRemaining(Frame frame, int rollNumber, int frameNumber,
            int numberOfFrames)
        {
            if (frame.PinsRemaining > 0)
            {
                RegularFrameRoll(rollNumber, frameNumber, frame, numberOfFrames);
                LastFrameRoll(frameNumber, frame, numberOfFrames);
            }
            else
            {
                DefaultRoll(rollNumber, frameNumber, frame, numberOfFrames);
            }
        }

        private void LastFrameRoll(int frameNumber, Frame frame, int numberOfFrames)
        {
            if (frameNumber == numberOfFrames)
            {
                var roll = new Roll();
                roll.RoleScore = RollSimulator.Roll();
                frame.Rolls.Add(roll);
            }
        }

        private void RegularFrameRoll(int rollNumber, int frameNumber, Frame frame, int numberOfFrames)
        {
            
            if (IsRegularFrame(rollNumber, frameNumber, numberOfFrames))
            {
                var roll = new Roll();
                roll.RoleScore = RollSimulator.Roll(frame.PinsRemaining);
                frame.PinsRemaining -= roll.RoleScore;
                frame.Rolls.Add(roll);
            }
        }

        private static bool IsRegularFrame(int rollNumber, int frameNumber, int numberOfFrames)
        {
            var maxRollNumber = 2;
            return rollNumber < maxRollNumber && frameNumber != numberOfFrames;
        }

        private void DefaultRoll(int rollNumber, int frameNumber, Frame frame, int numberOfFrames)
        {
            if (IsRegularFrame(rollNumber, frameNumber, numberOfFrames))
            {
                var roll = new Roll { RoleScore = 0 };
                frame.Rolls.Add(roll);
            }
        }
    }
}