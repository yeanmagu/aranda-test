using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArandaSoftwareData.Model
{
    public class Users
    {
      
        [Required]
        public string Username { get;  set; }
        public int Id { get;  set; }
        [Required]
        public string Email { get;  set; }

        public string Telefono { get;  set; }
        [Required]
        public string Password { get;  set; }
        [Required]
        public string Nombres { get;  set; }
        public bool Status { get;  set; }
        public string Apellidos { get;  set; }
        public int RolesId { get;  set; }
        public bool Block { get;  set; }
        public string Direccion { get;  set; }
        public DateTime FechaNacimiento { get; set; }
        [ForeignKey("RolesId")]
        public virtual Roles Rol { get; set; }
    }
}