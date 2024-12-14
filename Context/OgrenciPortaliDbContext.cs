using Microsoft.EntityFrameworkCore;

public class OgrenciPortaliDbContext : DbContext
{
    public DbSet<UserDMO> User { get; set; }
    public OgrenciPortaliDbContext(DbContextOptions options) : base(options)
    {
    }

}