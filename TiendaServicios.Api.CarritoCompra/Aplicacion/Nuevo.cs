using MediatR;
using TiendaServicios.Api.CarritoCompra.Modelo;
using TiendaServicios.Api.CarritoCompra.Persistencia;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public DateTime FechaCreacionSesion { get; set; }
            public List<string> ProductoLista { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CarritoContexto _contexto;

            public Manejador(CarritoContexto contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = new CarritoSesion
                {
                    FechaCreacion = request.FechaCreacionSesion
                };

                _contexto.CarritoSesion.Add(carritoSesion);
                var value = await _contexto.SaveChangesAsync();

                if (value == 0)
                    throw new Exception("No se pudo insertar el carrito.");

                int id = carritoSesion.CarritoSesionId;

                foreach (var item in request.ProductoLista)
                {
                    var detalleSesion = new CarritoSesionDetalle()
                    {
                        FechaCreacion = DateTime.Now,
                        CarritoSesionId = id,
                        ProductoSeleccionado = item
                    };

                    _contexto.CarritoSesionDetalle.Add(detalleSesion);
                }

                value = await _contexto.SaveChangesAsync();

                if (value == 0)
                    throw new Exception("Error insertando detalles del carrito de compra.");

                return Unit.Value;
            }
        }
    }
}
