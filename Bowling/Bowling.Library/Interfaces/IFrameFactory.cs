using Bowling.Library.Interfaces;

namespace Bowling.Library
{
    public interface IFrameFactory
    {
        IFrame Create(int[] rolls, int frame, int roll);
    }
}