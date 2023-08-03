namespace Identity.Core.Data;

public class IdentityAppDbContext : IdentityDbContext<ApplicationUser>
{
	public IdentityAppDbContext(DbContextOptions<IdentityAppDbContext> options): base(options)
	{
	}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}

