using AutoMapper;
using TiendaServicios.Api.Author.Modelo;

namespace TiendaServicios.Api.Author.Aplicacion
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AutorLibro, AutorDto>();
        }
    }
}
