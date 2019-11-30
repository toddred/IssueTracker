using System;
using System.Collections.Generic;

namespace BugTrackerIssueApi.Models
{
    public partial class Issue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public bool Active { get; set; }
    }
}
