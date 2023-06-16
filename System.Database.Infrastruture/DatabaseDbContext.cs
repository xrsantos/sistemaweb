
using System.Diagnostics;
using System.Database.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace System.Database.Infrastruture;
public class DatabaseDbContext: DbContext
{
    private readonly IConfiguration _configuration;

    public DatabaseDbContext(){
        var builder = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", true, true);
        _configuration = builder.Build();
        Console.WriteLine(_configuration.GetConnectionString("DefaultConnection"));
    }
    public DatabaseDbContext(DbContextOptions<DatabaseDbContext> options, IConfiguration configuration) : base(options) 
    {
        _configuration = configuration;
    }

    public DbSet<Costumer> Costumer { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 26)));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Costumer>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });

    //    modelBuilder.Entity<Contract>(entity =>
    //    {
    //        entity.HasKey(e => e.Id);
    //        entity.Property(e => e.Name).IsRequired();
    //        entity.HasOne(d => d.ClientSystem)
    //            .WithMany(p => p.ClientContracts);
    //    });
    }


}
