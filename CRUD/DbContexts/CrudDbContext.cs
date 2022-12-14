using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DbContexts
{
    public class CrudDbContext : DbContext
    {
        public CrudDbContext() {}
        public CrudDbContext(DbContextOptions<CrudDbContext> options) : base(options) {}

        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
