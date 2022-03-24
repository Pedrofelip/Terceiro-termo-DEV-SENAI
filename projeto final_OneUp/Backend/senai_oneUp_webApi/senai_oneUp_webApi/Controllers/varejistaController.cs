using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_oneUp_webApi.Domain;
using senai_oneUp_webApi.Interface;
using senai_oneUp_webApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_oneUp_webApi.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class varejistaController : ControllerBase
    {
        private IvarejistaRepository _varejistaRepository { get; set; }

        public varejistaController()
        {
            _varejistaRepository = new varejistaRepository();
        }


        [HttpGet]
        public IActionResult get()
        {
            List<Varejistum> listaVarejistas = _varejistaRepository.Listar();

            return Ok(listaVarejistas);
        }

        [HttpGet("{id}")]
        public IActionResult getID(int id)
        {
            try
            {
                return Ok(_varejistaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Varejistum att)
        {
            try
            {
                _varejistaRepository.Atualizar(id, att);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Post(Varejistum novo)
        {
            try
            {
                _varejistaRepository.Cadastrar(novo);

                return StatusCode(201);
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
                _varejistaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
