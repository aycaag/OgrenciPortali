using Microsoft.EntityFrameworkCore;

public class OgrenciPortaliDbContext : DbContext
{
    public DbSet<UserDMO> User { get; set; }
    public DbSet<TeacherListDMO> Teacher { get; set; }
    public OgrenciPortaliDbContext(DbContextOptions options) : base(options)
    {
    }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TeacherListDMO için Keyless Entity tanımı
        modelBuilder.Entity<TeacherListDMO>().HasNoKey();
    }


}