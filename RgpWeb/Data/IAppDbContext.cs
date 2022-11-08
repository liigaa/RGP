using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RgpWeb.Models;

namespace RgpWeb.Data;

public interface IAppDbContext
{
    DbSet<T> Set<T>() where T : class;
    EntityEntry<T> Entry<T>(T entity) where T : class;
    DbSet<Owner> Owners { get; set; }
    DbSet<Property> Properties { get; set; }
    DbSet<Unit> Units { get; set; }
    DbSet<UnitUseTypes> UnitUseTypes { get; set; }
    int SaveChanges();
    Task<int> SaveChangesAsync();
}