using Bowling.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling.Library
{
    public class Player
    {
        public string Name { get; }
        private int pins { get; set; }

        private List<Event> events = new List<Event>();

        public int TotalScore => events.Select(x => x.Score.Value).Sum();

        public int LastScore => events.Skip(events.Count() - 1).Select(x => x.Score.Value).First();

        public int Attempts => events.Skip(events.Count() - 1).Select(x => x.Attempts).First();

        public Player(string name)
        {
            Name = name;
            pins = 10;
        }

        public void Bowl(int frame, int attempt, int score = 0)
        {
            score = score == 0 ? new Random().Next(1, pins) : score;

            events.Add((frame, attempt) switch
            {
                _ when frame < 10 && attempt == 1 && score % pins == 0 || frame == 10 && score % pins == 0 => new Event
                {
                    Attempts = frame == 10 ? 3 : 0,
                    Score = new Score { Player = this.Name, Value = score, Description = $"STRIKE 10/10" },
                },
                _ when score % pins > 0 => new Event
                {
                    Attempts = 2,
                    Score = new Score { Player = this.Name, Value = score, Description = $"{score} pins knocked down." },
                },
                _ when frame < 10 && attempt == 2 && score == pins || frame == 10 && attempt >= 2 && score == pins => new Event
                {
                    Attempts = frame == 10 ? 3 : 0,
                    Score = new Score { Player = this.Name, Value = score, Description = $"SPARE {10 - score} and {score} pins knocked down." },
                },
                _ => throw new NotImplementedException(),
            });

            pins = pins - score == 0 ? 10 : pins - score;
        }
    }
}

