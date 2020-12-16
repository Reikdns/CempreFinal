using Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vista.Config;
using Vista.Models;


namespace Vista.Services {
    public class JWTService {

        private readonly AppSetting _appSettings;

        public JWTService (IOptions<AppSetting> appSettings) => _appSettings = appSettings.Value;

        public UsuarioViewModel GenerateToken (Usuario userLogIn) {

            // return null if user not found
            if (userLogIn == null) return null;
            var userResponse = new UsuarioViewModel () { Nombre = userLogIn.Nombre, CorreoElectronico = userLogIn.CorreoElectronico };
            
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler ();
            var key = Encoding.ASCII.GetBytes (_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity (new Claim[] {
                new Claim (ClaimTypes.Name, userLogIn.Nombre.ToString ()),
                new Claim (ClaimTypes.Email, userLogIn.CorreoElectronico.ToString ()),
                new Claim (ClaimTypes.Role, userLogIn.Rol),
                }),
                Expires = DateTime.UtcNow.AddDays (7),
                SigningCredentials = new SigningCredentials (new SymmetricSecurityKey (key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken (tokenDescriptor);
            userResponse.Token = tokenHandler.WriteToken (token);
            return userResponse;
        }

    }
}