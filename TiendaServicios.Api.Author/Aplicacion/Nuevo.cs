﻿using FluentValidation;
using MediatR;
using TiendaServicios.Api.Author.Modelo;
using TiendaServicios.Api.Author.Persistencia;

namespace TiendaServicios.Api.Author.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextoAutor _contexto;

            public Manejador(ContextoAutor contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autorLibro = new AutorLibro()
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    FechaNacimiento = request.FechaNacimiento,
                    AutorLibroGuid = Convert.ToString(Guid.NewGuid())
                };

                await _contexto.AutorLibro.AddAsync(autorLibro);
                var valor = await _contexto.SaveChangesAsync();

                if (valor == 0)
                    throw new Exception("No se pudo insertar el autor del libro");

                return Unit.Value;
            }
        }
    }
}
