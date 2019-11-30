using System;
using System.Threading.Tasks;
using BugTrackerIssueApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

// TODO: Edit Issues 
// TODO: Close Issues
// TODO: Soft Delete Issues


namespace BugTrackerIssueApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class IssuesController : ControllerBase
    {
        private readonly BugTrackerContext _context;
        private readonly ILogger _logger;
        public IssuesController(BugTrackerContext context)
        {
            _context = context;
        }
        
        // GET : issues
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Issues.ToArrayAsync());
        }
        // GET : issues/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return Ok(_context.Issues.Find(id));
        }
        // POST: issues
        [HttpPost]
        public async Task<ActionResult> Create([FromBody]Issue issue)
        {
            try
            {
                _context.Issues.Add(issue);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               
            }
            return Ok(issue);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Archive([FromRoute]int id)
        {
            try
            {
                var issue = _context.Issues.Find(id);
                issue.Active = false;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               
            }
            return Ok();
        }
    }
}
