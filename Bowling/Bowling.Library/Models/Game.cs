namespace BowlingLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        private readonly List<Player> players;

        private int Frames { get; set; }

        public readonly List<Score> scores = new List<Score>();

        public List<Result> Results => this.scores?
                .GroupBy(x => x.Player)
                .Select(x => new Result { Player = x.Key, Total = x.Sum(y => y.Value) })
                .OrderByDescending(x => x.Total)
                .ToList();

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="players"></param>
        /// <param name="frames"></param>
        public Game(List<Player> players, int frames = 10)
        {
            this.players = players;
            this.Frames = frames;
        }

        public void Play(int firstFrame = 1, int lastFrame = 1)
        {
            for (int frame = 1; frame <= this.Frames; frame++)
            {
                foreach (var player in this.players)
                {
                    int allowedBowls = 2;
                    int remainingPins = 10;

                    for (int attempt = 1; attempt <= (allowedBowls + player.RemainingBowls); attempt++)
                    {
                        var randomn = frame == this.Frames && attempt == 1 ? lastFrame : (frame == 1 && attempt == 1) ? firstFrame : 1;
                        var score = player.Bowl(frame, attempt, new Random().Next(randomn, remainingPins));
                        this.scores.Add(score);
                        this.RaiseNotification(new ProcessEventArgs { Player = player, Score = score });

                        if (player.RemainingBowls == 0)
                        {
                            break;
                        }
                        else if (player.Status == Status.NEXT)
                        {
                            remainingPins -= score.Value;
                        }
                    }
                }
            }
        }

        protected virtual void RaiseNotification(ProcessEventArgs e)
        {
            this.Notify?.Invoke(this, e);
        }

        public event EventHandler<ProcessEventArgs> Notify;
    }
}