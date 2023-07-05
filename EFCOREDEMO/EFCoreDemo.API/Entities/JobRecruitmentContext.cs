using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreDemo.API.Entities;

public partial class JobRecruitmentContext : DbContext
{
    public JobRecruitmentContext()
    {
    }

    public JobRecruitmentContext(DbContextOptions<JobRecruitmentContext> options) : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; } = null;

    public virtual DbSet<Company> Companies { get; set; } = null;

    public virtual DbSet<Job> Jobs { get; set; } = null;

    public virtual DbSet<Requirement> Requirements { get; set; } = null;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {
            string conn = "server=127.0.0.1;database=JobRecruitment;user=root;pwd=123456";
            optionsBuilder.UseMySql(ServerVersion.AutoDetect(conn));
            
            
        }
    }
}