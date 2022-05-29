using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Data;

namespace NerdStore.Catalogo.Data;

public sealed class CatalogoContext : DbContext, IUnitOfWork
{
    public CatalogoContext(DbContextOptions<CatalogoContext> options)
        : base(options) { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //para cada propriedade do tipo string, ela será varchar(100) no banco de dados
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");

        // modelBuilder.Ignore<Event>();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
    }

    public async Task<bool> Commit()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") is not null))
        {
            if (entry.State == EntityState.Added) entry.Property("DataCadastro").CurrentValue = DateTime.Now;

            if (entry.State == EntityState.Modified) entry.Property("DataCadastro").IsModified = false;
        }

        return await base.SaveChangesAsync() > 0;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.EnableSensitiveDataLogging();
}