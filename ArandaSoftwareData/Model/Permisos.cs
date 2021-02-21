namespace ArandaSoftwareData.Model
{
    public class Permisos
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public bool Ver { get; set; }
        public bool Editar { get; set; }
        public bool Crear { get; set; }
        public bool Eliminar { get; set; }
    }
}