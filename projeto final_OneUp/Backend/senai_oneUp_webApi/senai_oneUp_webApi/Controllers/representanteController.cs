using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class representanteController : ControllerBase
    {
        private IrepresentanteRepository _representanteRepository { get; set; }

        public representanteController()
        {
            _representanteRepository = new representanteRepository();
        }

        [HttpPost]
        public IActionResult Post(Representante novo)
        {

            

                try
                {
                    _representanteRepository.Cadastrar(novo);

                    return StatusCode(201);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }

            
        }

        /// <summary>
        /// Reponsavel por retornar uma lista dos Representantes cadastrados
        /// </summary>
        /// <returns>listaRepresentantes</returns>
        [HttpGet]
        public IActionResult get()
        {
            List<Representante> listaRepresentantes = _representanteRepository.Listar();

            return Ok(listaRepresentantes);
        }

        /// <summary>
        /// Responsavel por fazer a busca de um determinado Representante
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retorna o representante solicitado</returns>
        [HttpGet("{id}")]
        public IActionResult getID(int id)
        {
            try
            {
                return Ok(_representanteRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Representante att)
        {
            try
            {
                _representanteRepository.Atualizar(id, att);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _representanteRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
