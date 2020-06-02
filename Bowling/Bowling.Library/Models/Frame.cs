using Bowling.Library.Interfaces;

namespace Bowling.Library.Models
{
    public class Frame : IFrame
    {
        private readonly int[] _rolls;
        private readonly int _roll;

        public int Score => _rolls[_roll-1] + _rolls[_roll];

        public string Description => $"{Score} pins knocked down.";

        public Frame(int[] rolls, int roll)
        {
            _roll = roll;
            _rolls = rolls;
        }
    }
}

