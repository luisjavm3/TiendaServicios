using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Author.Modelo;

namespace TiendaServicios.Api.Author.Persistencia
{
    public class ContextoAutor: DbContext
    {
        public ContextoAutor(DbContextOptions<ContextoAutor> options) : base(options)
        { }

        public DbSet<AutorLibro> AutorLibro { get; set; }
        public DbSet<GradoAcademico> GradoAcademico { get; set; }
    }
}
