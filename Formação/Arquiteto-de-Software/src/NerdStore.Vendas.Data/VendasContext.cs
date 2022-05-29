using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Communication;
using NerdStore.Core.Data;
using NerdStore.Core.Messages;
using NerdStore.Vendas.Domain;

namespace NerdStore.Vendas.Data;

public sealed class VendasContext : DbContext, IUnitOfWork
{
    private readonly IMediatRHandler _mediatRHandler;

    public VendasContext(DbContextOptions<VendasContext> options, IMediatRHandler mediatRHandler)
        : base(options) => (_mediatRHandler) = (mediatRHandler);

    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<PedidoItem> PedidoItems { get; set; }
    public DbSet<Voucher> Vouchers { get; set; }

    public async Task<bool> Commit()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") is not null))
        {
            if (entry.State == EntityState.Added) entry.Property("DataCadastro").CurrentValue = DateTime.Now;
            if (entry.State == EntityState.Modified) entry.Property("DataCadastro").IsModified = false;
        }

        var sucesso = await SaveChangesAsync() > 0;

        if (sucesso) await _mediatRHandler.PublicarEventos(this);

        return sucesso;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string)))) property.SetColumnType("varchar(100)");

        modelBuilder.Ignore<Event>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VendasContext).Assembly);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

        modelBuilder.HasSequence<int>("minhasequencia").StartsAt(1000).IncrementsBy(1);

        base.OnModelCreating(modelBuilder);
    }
}