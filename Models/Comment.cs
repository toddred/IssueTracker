using System;

namespace BugTrackerIssueApi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int IssueId { get; set; }
        public string CommentBody { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool Active { get; set; }
        public Issue Issue { get; set; }
    }
}