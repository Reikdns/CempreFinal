using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Logica;
using Datos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Vista.Models;

namespace Vista.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(CempreContext context)
        {
            _usuarioService = new UsuarioService(context);
        }

        [HttpGet]
        public IEnumerable<UsuarioViewModel> Gets()
        {
            var usuarios = _usuarioService.ConsultarTodos().Select(p=> new UsuarioViewModel(p));
            return usuarios;
        }

        [HttpGet("{identificacion}")]
        public ActionResult<UsuarioViewModel> Get(string identificacion)
        {
            var usuario = _usuarioService.BuscarPorIdentificacion(identificacion);
            if (usuario == null) return NotFound();
            var usuarioViewModel = new UsuarioViewModel(usuario);
            return usuarioViewModel;
        }

        [HttpPost]
        public ActionResult<UsuarioViewModel> Post(UsuarioInputModel usuarioInput)
        {
            Usuario usuario = MapearUsuario(usuarioInput);
            var response = _usuarioService.Guardar(usuario);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Usuario);
        }

        [HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(string identificacion)
        {
            string mensaje = _usuarioService.Eliminar(identificacion);
            return Ok(mensaje);
        }

        private Usuario MapearUsuario(UsuarioInputModel usuarioInput)
        {
            var usuario = new Usuario
            {
                Identificacion = usuarioInput.Identificacion,
                Nombre = usuarioInput.Nombre,
                CorreoElectronico = usuarioInput.CorreoElectronico,
                ClaveIngreso = usuarioInput.ClaveIngreso
            };
            return usuario;
        }

        [HttpPut("{identificacion}")]
        public ActionResult<Usuario> Put(Usuario usuario)
        {
            _usuarioService.Modificar(usuario);
            return Ok(usuario);
        }
    }
}