using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Author.Modelo;
using TiendaServicios.Api.Author.Persistencia;

namespace TiendaServicios.Api.Author.Aplicacion
{
    public class ConsultaFiltro
    {
        public class AutorUnico : IRequest<AutorDto>
        {
            public string AutorGuid { get; set; }
        }

        public class Manejador : IRequestHandler<AutorUnico, AutorDto>
        {
            private readonly ContextoAutor _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoAutor contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<AutorDto> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await _contexto.AutorLibro
                    .Where(a => a.AutorLibroGuid == request.AutorGuid)
                    .FirstOrDefaultAsync();

                if (autor == null)
                    throw new Exception("No se encontro el autor");

                var autorDto = _mapper.Map<AutorDto>(autor);

                return autorDto;
            }
        }
    }
}
