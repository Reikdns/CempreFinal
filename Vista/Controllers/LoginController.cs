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
    public class LoginController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly JWTService _jwtService;

        public LoginController(CempreContext context, IOptions<AppSetting> appSetting)
        {
            _usuarioService = new UsuarioService(context);
            _jwtService = new JWTService(appSetting);
        }   

       [AllowAnonymous]
        [HttpPost]
        public ActionResult<UsuarioViewModel> Post(UsuarioInputModel usuarioInput)
        {
            Usuario usuario = MapearUsuario(usuarioInput);
            var user = _usuarioService.Validate(usuario.CorreoElectronico, usuario.ClaveDeIngreso);
            if (user == null) return BadRequest("El correo electronico o la clave de acceso son incorrectos.");
            var response = _jwtService.GenerateToken(user);
            return Ok(response);
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
 
    }
}