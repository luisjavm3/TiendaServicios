using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libro.Persistencia
{
    public class ContextoLibreria:DbContext
    {
        public ContextoLibreria(DbContextOptions<ContextoLibreria> options):base(options)
        {   }

        public ContextoLibreria()
        {   }

        public virtual DbSet<LibreriaMaterial> LibreriaMaterial { get; set; }
    }
}
