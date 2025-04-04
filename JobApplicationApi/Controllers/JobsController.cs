using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobApplicationApi.Models;

namespace JobApplicationApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobsController : ControllerBase
{
    private readonly JobContext _context;

    public JobsController(JobContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Job>> GetJobs()
    {
        if (_context.Jobs == null) // Null check
        {
            return NotFound();
        }
        return _context.Jobs.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Job> GetJob(int id)
    {
        if (_context.Jobs == null) // Null check
        {
            return NotFound();
        }
        var job = _context.Jobs.Find(id);
        if (job == null) return NotFound();
        return job;
    }

    [HttpPost]
    public ActionResult<Job> PostJob(Job job)
    {
        if (_context.Jobs == null) // Null check
        {
            return Problem("Entity set 'JobContext.Jobs' is null.");
        }
        _context.Jobs.Add(job);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetJob), new { id = job.Id }, job);
    }
}