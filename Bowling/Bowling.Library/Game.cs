namespace Bowling.Library
{
    using Bowling.Library.Interfaces;
    using Bowling.Library.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        private int[] rolls = new int[22];

        private int currentRoll = 0;

        private List<IFrame> frames = new List<IFrame>();

        private readonly IFrameFactory _frameFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="players"></param>
        /// <param name="frames"></param>
        public Game(IFrameFactory frameFactory)
        {
            _frameFactory = frameFactory;
        }

        public void Roll(int pins)
        {
            rolls[currentRoll] = pins;
            currentRoll++;
        }

        public int Score()
        {
            int frame = 1;
            for (int roll = 0; roll < currentRoll; roll++)
            {
                IFrame result = _frameFactory.Create(rolls, frame, roll);

                if (result != null)
                {
                    frames.Add(result);
                    frame = frame < 10 ? frames.Count() + 1 : 10;

                    roll += (frame) switch
                    {
                        _ when result is Strike => 0,
                        _ when result is Frame => 1,
                        _ when result is Spare => 1,
                    };
                }
            }
            return frames.Sum(x => x.Score);
        }
    }
}
