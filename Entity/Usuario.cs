using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Usuario
    {
        [Key]
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string ClaveDeIngreso { get; set; }
        public string Token { get; set; }
        public string Rol { get; set; }

    }
}