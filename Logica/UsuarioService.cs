using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class UsuarioService
    {
        private readonly CempreContext _context;
        public UsuarioService(CempreContext context)
        {
            _context = context;
        }

        public Usuario Validate(string correoElectronico, string claveIngreso) 
        {
            return _context.Usuarios.FirstOrDefault(t => t.CorreoElectronico == correoElectronico && t.ClaveIngreso == claveIngreso);
        }

        public GuardarUsuarioResponse Guardar(Usuario usuario)
        {
            try
            {   
                var usuarioBuscado = _context.Usuarios.Find(usuario.Identificacion);
                if (usuarioBuscado != null)
                {
                    return new GuardarUsuarioResponse("Error, el usuario ya se encuentra registrada.");
                }

                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                return new GuardarUsuarioResponse(usuario);
            }
            catch (Exception e)
            {
                return new GuardarUsuarioResponse($"Error de la Aplicacion: {e.Message}");
            }
        }

        public List<Usuario> ConsultarTodos()
        {
            List<Usuario> usuarios = _context.Usuarios.ToList();
            return usuarios;    
        }

        public string Eliminar(string identificacion)
        {
            try
            {
                var usuario = _context.Usuarios.Find(identificacion);

                if (usuario != null)
                {
                    _context.Usuarios.Remove(usuario);
                    _context.SaveChanges();
                    return ($"El registro {usuario.Nombre} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {identificacion} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
        }

        public string Modificar(Usuario usuarioNuevo)
        {
            try
            {
                var usuarioViejo = _context.Usuarios.Find(usuarioNuevo.Identificacion);
                if (usuarioViejo != null)
                {
                    usuarioViejo.Nombre = usuarioNuevo.Nombre;
                    usuarioViejo.Identificacion = usuarioNuevo.Identificacion;
                    usuarioViejo.CorreoElectronico = usuarioNuevo.CorreoElectronico;
                    usuarioViejo.ClaveIngreso = usuarioNuevo.ClaveIngreso;
                    _context.Usuarios.Update(usuarioViejo);
                    _context.SaveChanges();
                    return ($"El registro {usuarioNuevo.Nombre} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, el registro {usuarioNuevo.Nombre} no se encuentra en la base de datos.");
                }
            }
            catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message}.";
            }
        }

        public Usuario BuscarPorIdentificacion(string identificacion)
        {
            Usuario usuario = _context.Usuarios.Find(identificacion);
            return usuario;
        }

        public int Totalizar()
        {
            return _context.Usuarios.Count();
        }

    }

    public class GuardarUsuarioResponse 
    {
        public GuardarUsuarioResponse(Usuario usuario)
        {
            Error = false;
            Usuario = usuario;
        }
        public GuardarUsuarioResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Usuario Usuario { get; set; }
    }
}