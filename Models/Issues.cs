using System;
using System.Collections.Generic;

namespace BugTrackerIssueApi
{
    public partial class Issues
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public ulong IsOpen { get; set; }
    }
}
