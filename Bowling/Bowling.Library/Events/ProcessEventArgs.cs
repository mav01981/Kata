namespace Bowling.Library
{
    using System;

    public class ProcessEventArgs : EventArgs
    {
        public Player Player { get; set; }

        public Score Score { get; set; }
    }
}