using Microsoft.EntityFrameworkCore;
using Vizsgafeladat.Entities;

namespace Vizsgafeladat;
public class ReportDbContext : DbContext
{
    public ReportDbContext(DbContextOptions<ReportDbContext> options) 
        : base(options) { }
    public ReportDbContext() : base(new DbContextOptionsBuilder().UseSqlServer(
        "Server=(localdb)\\mssqllocaldb;Database=DogFarmDB;Trusted_Connection=True;"
        ).Options)
    { }    

public DbSet<Report> Reports { get; set; }
public DbSet<TheTask> Tasks { get; set; }
public DbSet<Worker> Workers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Kapcsolatok, limitációk konfigurálása

        // "Report" és "Task" közötti összefüggések
        modelBuilder.Entity<TheTask>()
            .HasOne(t => t.Report)
            .WithMany(r => r.Tasks)
            .HasForeignKey(t => t.ReportID);

        // "Workers" és "Tasks" közötti összefüggések
        modelBuilder.Entity<TheTask>()
            .HasOne(t => t.Worker)
            .WithMany(w => w.Tasks)
            .HasForeignKey(t => t.WorkerID);
    }
}

