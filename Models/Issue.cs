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
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? ClosedOn { get; set; }
        
        public ICollection<Comment> Comments { get; set; }
    }
}
