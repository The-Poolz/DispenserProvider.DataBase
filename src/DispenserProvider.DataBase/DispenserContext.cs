using Microsoft.EntityFrameworkCore;
using ConfiguredSqlConnection.Extensions;

namespace DispenserProvider.DataBase;

public class DispenserContext : DbContext
{
    public DispenserContext() { }
    public DispenserContext(DbContextOptions options) : base(options) { }
    public DispenserContext(DbContextOptions<DispenserContext> options) : base(options) { }

    //public virtual DbSet<TableDTO> Table { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .ConfigureFromActionConnection("DispenserProvider.Migrations")
            .ConfigureFromSecretConnection("DispenserProvider.Migrations");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //...
    }
}