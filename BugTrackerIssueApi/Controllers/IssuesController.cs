using System;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerIssueApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        private readonly ILogger<IssuesController> _logger;
        
        public IssuesController(BugTrackerContext context, ILogger<IssuesController> logger)
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
        
        // GET : issues/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return Ok(await _context.Issues.FindAsync(id));
        }
        // POST: /issues
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody]Issue issue)
        {
            issue.CreatedBy = Int32.Parse(User.Claims.First().Value);
            try
            {
                _context.Issues.Add(issue);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return Ok(issue);
        }
        // PUT : /issues
        [Authorize]
        [HttpPut]
        public async Task<ActionResult> Edit([FromBody]Issue issue)
        {
            try
            {
                issue.ModifiedOn = DateTime.Now;
                _context.Issues.Update(issue);
                await _context.SaveChangesAsync();
                return Ok(issue);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return BadRequest();
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
                issue.ModifiedOn = DateTime.Now;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                
            }
            return BadRequest();
        }
    }
}
