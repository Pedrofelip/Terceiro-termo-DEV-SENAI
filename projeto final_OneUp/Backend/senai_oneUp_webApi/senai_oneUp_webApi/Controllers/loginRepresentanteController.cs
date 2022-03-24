using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_oneUp_webApi.Domain;
using senai_oneUp_webApi.Interface;
using senai_oneUp_webApi.Repository;
using senai_oneUp_webApi.viewwModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_oneUp_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginRepresentanteController : ControllerBase
    {
        private IrepresentanteRepository _representanteRepository { get; set; }

        public loginRepresentanteController()
        {
            _representanteRepository = new representanteRepository();
        }

        [HttpPost]
        public IActionResult Post(viewModelLogin login)
        {
            try
            {

                Representante representanteBuscado = _representanteRepository.Login(login.Email, login.senha);
                login.senha = md5Hash.CalculaHash(login.senha);

                if (representanteBuscado == null)
                {
                    return NotFound("E-mail ou senha inválidos!");
                }


                var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, representanteBuscado.Email),

                        new Claim(JwtRegisteredClaimNames.Jti, representanteBuscado.IdRepresentante.ToString()),

                        new Claim(ClaimTypes.Role, representanteBuscado.IdRepresentante.ToString()),

                        new Claim("role", "2"),

                        new Claim(JwtRegisteredClaimNames.Name, representanteBuscado.Nome)
                    };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("oneUp-projetoFinal-Senai"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "OneUp.webApi",
                    audience: "OneUp.webApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );


                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
