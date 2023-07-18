using BackendDataService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class TestDbContext : DbContext
{

    protected readonly IConfiguration _configuration;

    public TestDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Date> Dates { get; set; }
    public DbSet<Dish> Dishes { get; set; }

    public DbSet<DishToDate> DishToDates { get; set; }

    public DbSet<UserToLink> UserToLink { get; set; }

    public TestDbContext(DbContextOptions<TestDbContext> options, IConfiguration configuration )
    : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("TestDbConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("user", "webapi").HasKey(u => u.UserId);
        modelBuilder.Entity<Date>().ToTable("dates", "webapi").HasKey(u => u.DateId);
        modelBuilder.Entity<Dish>().ToTable("dishes", "webapi").HasKey(u => u.DishId);
        modelBuilder.Entity<DishToDate>().ToTable("dishes_to_date", "webapi").HasNoKey();
        modelBuilder.Entity<UserToLink>().ToTable("user_to_dish_date_link", "webapi").HasNoKey();
    }
}