using System;
using System.Collections.Generic;
using System.Text;

namespace ArandaSoftwareEntities.DTOS
{
    public class PermisosDTO
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public bool Ver { get; set; }
        public bool Editar { get; set; }
        public bool Crear { get; set; }
        public bool Eliminar { get; set; }
    }
}
