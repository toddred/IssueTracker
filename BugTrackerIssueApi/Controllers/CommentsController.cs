using System;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerIssueApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BugTrackerIssueApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CommentsController : ControllerBase
    {
        private readonly BugTrackerContext _context;
        private readonly ILogger _logger;
        
        public CommentsController(BugTrackerContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult> GetComments(int issueId)
        {
            if (issueId <= 0)
            {
                _logger.LogWarning("**ERROR** Invalid Issue Id");
                return BadRequest();
            }
            return Ok(await _context.Comments.Where(comment => comment.IssueId == issueId).ToListAsync());
        }

        [HttpGet("/comment/{id}")]
        public async Task<IActionResult> GetComment(int commentId)
        {
            if (commentId <= 0)
            {
                _logger.LogWarning("**ERROR** Invalid Issue Id");
                return BadRequest();
            }
            return Ok(await _context.Comments.FindAsync(commentId));
        }

        [HttpPost("/{id}")]
        public async Task<IActionResult> CreateComment([FromBody] Comment comment)
        {
            // TODO: some server side model validation? 
            try
            {
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return Ok(comment);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return NotFound();
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> EditComment([FromBody] Comment comment)
        {
            try
            {
                _context.Comments.Update(comment);
                await _context.SaveChangesAsync();
                return Ok(comment);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return BadRequest();
        }
    }
}