using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using senai_oneUp_webApi.Domain;
using senai_oneUp_webApi.Interface;
using senai_oneUp_webApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_oneUp_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class presencaController : ControllerBase
    {
        private IpresencaRepository _presencaRepository;

        
        public presencaController()
        {
            _presencaRepository = new presencaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Presenca> listaPresencas = _presencaRepository.Listar();

            return Ok(listaPresencas);
        }

        [HttpGet("minhas")]
        public IActionResult GetMy()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_presencaRepository.ListarMinhas(idUsuario));
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "O usuario não está logado!",
                    error
                });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Presenca presencaAtualizada)
        {
            try
            {
                _presencaRepository.Atualizar(id, presencaAtualizada);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Presenca status)
        {
            try
            {
                _presencaRepository.AprovarRecusar(id, status.Situacao);

                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
