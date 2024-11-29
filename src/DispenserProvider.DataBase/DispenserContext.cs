using Net.Web3.EthereumWallet;
using Microsoft.EntityFrameworkCore;
using DispenserProvider.DataBase.Models;
using ConfiguredSqlConnection.Extensions;
using Net.Web3.EthereumWallet.Extensions;

namespace DispenserProvider.DataBase;

public class DispenserContext : DbContext
{
    public DispenserContext() { }
    public DispenserContext(DbContextOptions<DispenserContext> options) : base(options) { }

    public virtual DbSet<DispenserDTO> Dispenser { get; set; } = null!;
    public virtual DbSet<TransactionDetailDTO> TransactionDetails { get; set; } = null!;
    public virtual DbSet<SignatureDTO> Signatures { get; set; } = null!;
    public virtual DbSet<BuilderDTO> Builders { get; set; } = null!;
    public virtual DbSet<LogDTO> Logs { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .ConfigureFromActionConnection("DispenserProvider.Migrations")
            .ConfigureFromSecretConnection("DispenserProvider.Migrations");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DispenserDTO>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(x => x.UserAddress)
                .HasConversion(
                    x => x.ConvertToChecksumAddress(null),
                    x => new EthereumAddress(x)
                );

            entity.HasOne(e => e.UserSignature)
                .WithOne(e => e.Dispenser)
                .HasForeignKey<DispenserDTO>(e => e.Signature)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.WithdrawalDetail)
                .WithOne(e => e.Dispenser)
                .HasForeignKey<DispenserDTO>(e => e.WithdrawalDetailId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.RefundDetail)
                .WithOne()
                .HasForeignKey<DispenserDTO>(e => e.RefundDetailId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Log)
                .WithMany(e => e.Dispenser)
                .HasForeignKey(e => e.LogSignature)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<TransactionDetailDTO>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasMany(e => e.Builders)
                .WithOne(e => e.TransactionDetail)
                .HasForeignKey(e => e.TransactionDetailId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<SignatureDTO>(entity =>
        {
            entity.HasKey(e => e.Signature);
        });

        modelBuilder.Entity<BuilderDTO>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(x => x.ProviderAddress)
                .HasConversion(
                    x => x.ConvertToChecksumAddress(null),
                    x => new EthereumAddress(x)
                );

            entity.HasOne(e => e.TransactionDetail)
                .WithMany(e => e.Builders)
                .HasForeignKey(e => e.TransactionDetailId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<LogDTO>(entity =>
        {
            entity.HasKey(e => e.Signature);

            entity.HasMany(e => e.Dispenser)
                .WithOne(e => e.Log)
                .HasForeignKey(e => e.LogSignature)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}