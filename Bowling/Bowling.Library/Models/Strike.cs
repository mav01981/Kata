using Bowling.Library.Interfaces;

namespace Bowling.Library
{
    public class Strike : IFrame
    {
        private readonly int[] _rolls;
        private readonly int _roll;
        private readonly int _frame;
        private const int maxFrame = 10;
        private const int strike = 10;

        public int Score => _frame == maxFrame ? _rolls[_roll] : strike + _rolls[_roll + 1] + _rolls[_roll + 2];

        public string Description => $"STRIKE {_rolls[_roll]}";

        public Strike(int frame, int[] rolls, int roll)
        {
            _frame = frame;
            _rolls = rolls;
            _roll = roll;
        }
    }
}
