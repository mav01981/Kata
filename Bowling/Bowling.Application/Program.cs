namespace Bowling
{
    using Bowling.Library;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player> { new Player("James"), new Player("Jon"), new Player("Bob") };
            var game = new Game(players);
            game.Notify += Game_Notify;

            game.Play();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Results");

            foreach (var result in game.Scores?
                .GroupBy(x => x.Player)
                .Select(x => new Result { Player = x.Key, Total = x.Sum(y => y.Value) })
                .OrderByDescending(x => x.Total)
                .ToList())
            {
                Console.WriteLine($"Player: {result.Player} Total : {result.Total}");
            }

            Console.Read();
        }

        private static void Game_Notify(object sender, ProcessEventArgs eventResult)
        {
            Console.WriteLine($"Frame:{eventResult.Score.Frame} | Player:{eventResult.Player.Name} {eventResult.Score.Description}");
        }
    }
}
