using Bowling.Library.Interfaces;

namespace Bowling.Library
{
    public class Spare : IFrame
    {
        private readonly int[] _rolls;
        private readonly int _roll;
        private readonly int _frame;
        private const int maxFrame = 10;
        private const int spare = 10;

        public int Score => _frame == maxFrame ? _rolls[_roll] : spare + _rolls[_roll + 2];

        public string Description => $"SPARE=> {_rolls[_roll]} : {_rolls[_roll + 1]}";

        public Spare(int frame, int[] rolls, int roll)
        {
            _frame = frame;
            _rolls = rolls;
            _roll = roll;
        }
    }
}
