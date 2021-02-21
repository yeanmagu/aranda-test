using System;
using System.ComponentModel.DataAnnotations;

namespace ArandaSoftwareData.Model
{
    public class Roles
    {
        public int Id { get; internal set; }
        [Required(ErrorMessage ="Nombre del rol es requerido")]
        public string RoleName { get; internal set; }
        public DateTime DateCreation { get; internal set; }
        
       
    }
}