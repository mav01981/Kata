namespace BowlingLibrary
{
    public class Player 
    {
        public string Name { get; }

        public Status Status { get; set; }

        public int Bonus { get; set; }

        public int Frame { get; set; }

        public int LastFrame { get; set; }

        public int FrameScore { get; set; }

        public int TotalScore { get; set; }

        public int RemainingBowls { get; set; }

        public Player(string name)
        {
            this.Name = name;
            this.Status = Status.NEXT;
        }

        public Score Bowl(int frame, int attempt, int score)
        {
            if (this.Frame != frame)
            {
                this.FrameScore = 0;
            }

            this.Frame = frame;
            this.FrameScore += score;
            this.TotalScore += score;

            bool isStrike = score == 10;
            bool isSpare = this.FrameScore == 10;

            if (isStrike)
            {
                this.MapRules(Status.STRIKE, attempt);
                return new Score { Frame = frame, Player = this.Name, Value = score, Description = $"STRIKE 10/10" };
            }
            else
            {
                if (isSpare)
                {
                    this.MapRules(Status.SPARE, attempt);
                    return new Score { Frame = frame, Player = this.Name, Value = score, Description = $"SPARE {10 - score} and {score} pins knocked down." };
                }

                this.MapRules(Status.NEXT, attempt);
                return new Score { Frame = frame, Player = this.Name, Value = score, Description = $"{score} pins knocked down." };
            }
        }
    }
}
