using Entity;

namespace Vista.Models
{
    public class UsuarioInputModel
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string ClaveIngreso { get; set; }
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
            ClaveIngreso = usuario.ClaveIngreso;
        }
    } 

}