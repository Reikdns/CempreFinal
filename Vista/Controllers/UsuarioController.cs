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
using Microsoft.AspNetCore.Authorization;
using Vista.Models;
using Microsoft.Extensions.Options;
using Vista.Config;
using Vista.Services;

namespace Vista.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly JWTService _jwtService;

        public UsuarioController(CempreContext context, IOptions<AppSetting> appSetting)
        {
            _usuarioService = new UsuarioService(context);
            _jwtService = new JWTService(appSetting);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioInputModel model)
        {
            var user = _usuarioService.Validate(model.CorreoElectronico, model.ClaveDeIngreso);
            if (user == null) return BadRequest("El correo electronico o la clave de acceso son incorrectos.");
            var response = _jwtService.GenerateToken(user);
            return Ok(response);
        }

        [HttpGet]
        public IEnumerable<UsuarioViewModel> Gets()
        {
            var usuarios = _usuarioService.ConsultarTodos().Select(p => new UsuarioViewModel(p));
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

        [AllowAnonymous]
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
                ClaveDeIngreso = usuarioInput.ClaveDeIngreso,
                Rol = usuarioInput.Rol
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