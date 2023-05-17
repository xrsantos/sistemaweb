using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SistemaDB.Models;

public class ERPDBContext: DbContext
{
    private readonly IConfiguration _configuration;

    public ERPDBContext(){
        var builder = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", true, true);
        _configuration = builder.Build();
    }
    public ERPDBContext(IConfiguration configuration){
         _configuration = configuration;
    }

    public DbSet<ClientSystem> TableClientSystem { get; set; }
    public DbSet<ClientContract> TableClientContract { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 26)));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ClientSystem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<ClientContract>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.HasOne(d => d.ClientSystem)
                .WithMany(p => p.ClientContracts);
        });
    }
}

