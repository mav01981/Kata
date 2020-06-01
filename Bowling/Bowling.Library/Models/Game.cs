namespace Bowling.Library
{
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        private readonly List<Player> _players;

        private int frames => 10;

        public Player Winner => _players.OrderBy(x => x.TotalScore).First();

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="players"></param>
        /// <param name="frames"></param>
        public Game(List<Player> players)
        {
            _players = players;
        }

        public void Start()
        {
            for (int frame = 1; frame <= frames; frame++)
            {
                foreach (var player in _players)
                {
                    player.Bowl(frame, 1);

                    var attempts = player.Attempts;
                    for (int attempt = 2; attempt <= attempts; attempt++)
                    {
                        player.Bowl(frame, attempt);
                    }
                }
            }
        }
    }
}
