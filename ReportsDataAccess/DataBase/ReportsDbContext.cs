namespace ReportsDataAccess.DataBase;

using Extensions;
using Microsoft.EntityFrameworkCore;
using ModelsConfigurations;
using ReportsDomain.Entities;
using ReportsDomain.Tasks;

public sealed class ReportsDbContext : DbContext
{
    public ReportsDbContext(DbContextOptions options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<ReportsTask> Tasks { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<WorkTeam> WorkTeams { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Sprint> Sprints { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();

        modelBuilder.ApplyConfiguration(new TaskConfigurations());
        modelBuilder.ApplyConfiguration(new EmployeeConfigurations());
        modelBuilder.ApplyConfiguration(new WorkTeamConfigurations());
        modelBuilder.ApplyConfiguration(new ReportConfiguration());
        modelBuilder.ApplyConfiguration(new SprintConfigurations());

        base.OnModelCreating(modelBuilder);
    }
}