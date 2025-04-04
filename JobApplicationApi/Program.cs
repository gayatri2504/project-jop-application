using Microsoft.EntityFrameworkCore;
using JobApplicationApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<JobContext>(opt => opt.UseInMemoryDatabase("JobDb"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

// Seed sample data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<JobContext>();
    if (context.Jobs != null) // Null check
    {
        context.Jobs.AddRange(
            new Job { Id = 1, Title = "Software Engineer", Description = "Build cool stuff", Location = "Remote" },
            new Job { Id = 2, Title = "Product Manager", Description = "Manage products", Location = "New York" }
        );
        context.SaveChanges();
    }
}

app.Run();

public class JobContext : DbContext
{
    public JobContext(DbContextOptions<JobContext> options) : base(options) { }
    public DbSet<Job>? Jobs { get; set; }
    public DbSet<Application>? Applications { get; set; }
}