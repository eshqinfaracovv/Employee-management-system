using management.Employees.Models;
using management.Employees.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace management.Common.Repo
{
    public class Repo<TEntity, TId> :DbContext
         where TEntity : Entity<TId>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-GHFALKV;Database=CodeAcademy;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<TEntity> DbContext1 { get; set; }
        public TEntity Add(TEntity entry)
        {
            DbContext1.Add(entry);
            return entry;
        }
        public DbSet<TEntity> GetAll()
        {
            return DbContext1;
        }
       
    }
}
