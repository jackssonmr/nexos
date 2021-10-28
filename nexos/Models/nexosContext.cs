using Microsoft.EntityFrameworkCore;

namespace nexos.Models
{
    public class nexosContext : DbContext
    {
        nexosContext(DbContextOptions<nexosContext> options)
            : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
    }
}
