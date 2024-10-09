using Microsoft.EntityFrameworkCore;

namespace ProjectApp.Persistence;

public class ProjectDbContext : DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) { }
    
    public DbSet<TaskDb> TaskDbs { get; set; }
    public DbSet<ProjectDb> ProjectDbs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) //seed data
    {
        ProjectDb pdb = new ProjectDb
        {
            Id = -1, //seed date
            Title = "Learn ASP.NET Core with MVC",
            CreateDate = DateTime.Now,
            UserName = "julg@kth.se",
            TaskDbs = new List<TaskDb>()
        };
        modelBuilder.Entity<ProjectDb>().HasData(pdb);

        TaskDb tdb1 = new TaskDb()
        {
            Id = -1,
            Description = "Follow the turtles",
            LastUpdated = DateTime.Now,
            Status = Core.Status.IN_PROGRESS,
            ProjectId = -1
        };
        TaskDb tdb2 = new TaskDb()
        {
            Id = -2,
            Description = "Do it yourself",
            LastUpdated = DateTime.Now,
            Status = Core.Status.TODO,
            ProjectId = -2
        };
        modelBuilder.Entity<TaskDb>().HasData(tdb1);
        modelBuilder.Entity<TaskDb>().HasData(tdb2);
    }
}