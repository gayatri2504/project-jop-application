using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobApplicationApi.Models;

namespace JobApplicationApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationsController : ControllerBase
{
    private readonly JobContext _context;

    public ApplicationsController(JobContext context)
    {
        _context = context;
    }

    [HttpPost]
    public ActionResult<Application> PostApplication(Application application)
    {
        if (_context.Applications == null) // Null check
        {
            return Problem("Entity set 'JobContext.Applications' is null.");
        }
        _context.Applications.Add(application);
        _context.SaveChanges();
        return CreatedAtAction(nameof(PostApplication), new { id = application.Id }, application);
    }
}