using System;
using System.Collections.Generic;

namespace ApiRest.Model.biblioteca
{
    public partial class Libro
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
