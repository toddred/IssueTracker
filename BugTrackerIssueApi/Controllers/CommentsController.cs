using System;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerIssueApi.Models;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ILogger<CommentsController> _logger;
        
        public CommentsController(BugTrackerContext context, ILogger<CommentsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("issue/{id}")]
        public async Task<IActionResult> GetComments([FromRoute]int id)
        {
            if (id > 0)
                return Ok(await _context.Comments
                    .Where(comment =>
                        comment.IssueId == id && comment.Active)
                    .ToListAsync());
            _logger.LogWarning("**ERROR** Invalid Issue Id");
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment([FromRoute]int id)
        {
            if (id > 0) return Ok(await _context.Comments.FindAsync(id));
            _logger.LogWarning("**ERROR** Invalid Issue Id");
            return BadRequest();
        }
        [Authorize]
        [HttpPost]
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
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> EditComment([FromBody] Comment comment)
        {
            try
            {
                comment.ModifiedOn = DateTime.Now;
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
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> ArchiveComment([FromRoute] int id)
        {
            
            try
            {
                var comment = await _context.Comments.FindAsync(id);
                comment.ModifiedOn = DateTime.Now;
                comment.Active = false;
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