using System;
using System.Collections.Generic;
using System.Text;

namespace ArandaSoftwareEntities.DTOS
{
    public class LoginResult
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string Telefono { get; set; }

        public string Password { get; set; }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public bool Status { get; set; }
        public string NombresCompletos { get { return $"{Nombres} {Apellidos}"; } set { NombresCompletos = value; } }
        public int RolesId { get; set; }
        public bool Block { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get { return DateTime.Now.AddTicks(-FechaNacimiento.Ticks).Year; } set { Edad = value; } }
        public RolesDTO Rol { get; set; }
        public PermisosDTO Permisos { get; set; }

    }
}
