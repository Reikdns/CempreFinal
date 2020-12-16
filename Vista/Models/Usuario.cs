using Entity;

namespace Vista.Models
{
    public class UsuarioInputModel
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string ClaveDeIngreso { get; set; }
        public string Rol { get; set; }
        public string Token { get; set; }
    }

    public class UsuarioViewModel : UsuarioInputModel
    {
        public UsuarioViewModel()
        {
            
        }

        public UsuarioViewModel(Usuario usuario)
        {
            Identificacion = usuario.Identificacion;
            Nombre = usuario.Nombre;
            CorreoElectronico = usuario.CorreoElectronico;
            ClaveDeIngreso = usuario.ClaveDeIngreso;
            Rol = usuario.Rol;
        }
        
    } 

}