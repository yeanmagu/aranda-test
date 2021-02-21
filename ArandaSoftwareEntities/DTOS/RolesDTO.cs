using System;
using System.Collections.Generic;
using System.Text;

namespace ArandaSoftwareEntities.DTOS
{
    public class RolesDTO
    {
        public int Id { get; internal set; }
        public string RoleName { get; internal set; }
        public DateTime DateCreation { get; internal set; }
    }
}
