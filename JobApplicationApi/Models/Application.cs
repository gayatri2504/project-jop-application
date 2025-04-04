namespace JobApplicationApi.Models;

public class Application
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public string? ApplicantName { get; set; } // Nullable to fix CS8618
    public string? Email { get; set; }         // Nullable to fix CS8618
    public string? ResumeUrl { get; set; }     // Nullable to fix CS8618
}