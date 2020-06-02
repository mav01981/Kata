using Bowling.Library.Interfaces;
using Bowling.Library.Models;

namespace Bowling.Library
{
    public class FrameFactory: IFrameFactory
    {
        private int[] _rolls;

        private bool IsRoll(int roll)
        {
            return roll >= 1 && (_rolls[roll] + _rolls[roll + 1]) < 10;
        }

        private bool IsSpare(int roll)
        {
            return (_rolls[roll] + _rolls[roll + 1]) == 10;
        }

        private bool IsStrike(int roll)
        {
            return _rolls[roll] == 10;
        }

        public IFrame Create(int[] rolls, int frame, int roll)
        {
            _rolls = rolls;

            return (roll) switch
            {
                _ when IsStrike(roll) => new Strike(frame, rolls, roll),
                _ when IsSpare(roll) => new Spare(frame, rolls, roll),
                _ when IsRoll(roll) => new Frame(rolls, roll),
                _ => null,
            };
        }
    }
}
