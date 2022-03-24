using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
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
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace senai_oneUp_webApi.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class loginVarejistaController : ControllerBase
    {
        private IvarejistaRepository _varejistaRepository { get; set; }

        public loginVarejistaController()
        {
            _varejistaRepository = new varejistaRepository();
        }

        [HttpPost]
        public IActionResult Post(viewModelLogin login)
        {
            try
            {
                Varejistum varejistaBuscado = _varejistaRepository.Login(login.Email, login.senha);
                login.senha = md5Hash.CalculaHash(login.senha);

                if (varejistaBuscado == null)
                {
                    return NotFound("E-mail ou senha inválidos!");

                }


                var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, varejistaBuscado.Email),

                        new Claim(JwtRegisteredClaimNames.Jti, varejistaBuscado.IdVarejista.ToString()),

                        new Claim(ClaimTypes.Role, varejistaBuscado.IdVarejista.ToString()),

                        new Claim("role", varejistaBuscado.Permissao.ToString()),

                        new Claim(JwtRegisteredClaimNames.Name, varejistaBuscado.Nome)
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
