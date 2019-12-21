using System;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerIssueApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// TODO: validate edit and new object


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
        public IssuesController(BugTrackerContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }
        
        // GET : issues
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Issues.Where(issue => issue.Active).ToArrayAsync());
        }
        
        // GET : issues/secure
        [Authorize]
        [HttpGet("secure")]
        public async Task<IActionResult> GetSecure()
        {
            return Ok(await _context.Issues.ToArrayAsync());
        }
        // GET : issues/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return Ok(await _context.Issues.FindAsync(id));
        }
        // POST: issues
        [Authorize]
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
                _logger.LogError("ERROR**",e.Message);
            }
            return Ok(issue);
        }
        // PUT : issues/edit/{id}
        [Authorize]
        [HttpPut("edit/{id}")]
        public async Task<ActionResult> Edit([FromRoute] int id,[FromBody]Issue issue)
        {
            var myIssue = await _context.Issues.FindAsync(id);
            // if active  and the issue in the route matches id replace edited items
            if (myIssue.Active || myIssue.Id == issue.Id)
            {
                try
                {
                    _context.Issues.Update(issue);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    _logger.LogError("ERROR**",e.Message);
                    throw;
                }
                return Ok(issue);
            }
            return BadRequest();

        }
        // PATCH : issues/close/{id}
        [Authorize]
        [HttpPatch("close/{id}")]
        public async Task<ActionResult> Close([FromRoute] int id, [FromBody] Issue issue)
        {
            return Ok();
        }
        // DELETE : issues/{id}
        [Authorize]
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
                _logger.LogError("ERROR**",e.Message);
            }
            return Ok();
        }
    }
}
