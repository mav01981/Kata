namespace BowlingLibrary
{
    using System;
    using System.Collections.Generic;

    public class ProcessResultsEventArgs : EventArgs
    {
        public List<Result> Results { get; set; }
    }
}