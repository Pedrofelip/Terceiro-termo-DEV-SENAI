using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_oneUp_webApi.Contexts;
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
    public class arquivoController : ControllerBase
    {

        OneUpContext ctx = new OneUpContext();

        private IArquivoRepository _arquivoRepository { get; set; }

        public arquivoController()
        {
            _arquivoRepository = new arquivoRepository();
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {                             
                return Ok(_arquivoRepository.ListarTodos());
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Post(Arquivo novoArquivo)
        {
            try
            {
                _arquivoRepository.Cadastrar(novoArquivo);

                return Ok(201);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _arquivoRepository.Deletar(id);

                return StatusCode(201);

            }
            catch(Exception ex)
            {
                return BadRequest(ex); 
            }
        }
        [HttpPut]
        public IActionResult Put(Arquivo arquivoAtualizado)
        {
            try
            {
                _arquivoRepository.Atualizar(arquivoAtualizado);

                return StatusCode(201);
            }

            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
