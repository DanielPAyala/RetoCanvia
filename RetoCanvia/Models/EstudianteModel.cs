using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetoCanvia.Models
{
    public class EstudianteModel
    {
        public int EstudianteId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int CarreraId { get; set; }
    }
}
