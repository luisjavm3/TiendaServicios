﻿using TiendaServicios.Api.Author.Modelo;

namespace TiendaServicios.Api.Author.Aplicacion
{
    public class AutorDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string AutorLibroGuid { get; set; }
    }
}
