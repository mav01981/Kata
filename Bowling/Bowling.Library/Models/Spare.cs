using Bowling.Library.Interfaces;

namespace Bowling.Library
{
    public class Spare : IFrame
    {
        private readonly int[] _rolls;
        private readonly int _roll;
        private readonly int _frame;

        public int Score => _frame == 10 ? _rolls[_roll] : 10 + _rolls[_roll + 2];

        public string Description => $"SPARE=> {_rolls[_roll]} : {_rolls[_roll + 1]}";

        public Spare(int frame, int[] rolls, int roll)
        {
            _frame = frame;
            _rolls = rolls;
            _roll = roll;
        }
    }
}
