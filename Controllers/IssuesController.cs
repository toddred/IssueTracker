using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerIssueApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bugtrackerIssuesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IssuesController : ControllerBase
    {
        private readonly bugtrackerContext _context;

        public IssuesController(bugtrackerContext context)
        {
            _context = context;
        }
        // GET : api/Issues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Issues>>> Get()
        {
            var myIssues = _context.Issues;
            return myIssues.ToArray();
        }
        // POST: api/IssueItem
        [HttpPost]
        public async Task<ActionResult<Issues>> PostIssue(Issues issue)
        {
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(Get), new { id = issue.Id }, issue);
        }
    }
}
