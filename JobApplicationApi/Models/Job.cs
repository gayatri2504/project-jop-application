namespace JobApplicationApi.Models;

public class Job
{
    public int Id { get; set; }
    public string? Title { get; set; }        // Nullable to fix CS8618
    public string? Description { get; set; }  // Nullable to fix CS8618
    public string? Location { get; set; }     // Nullable to fix CS8618
}