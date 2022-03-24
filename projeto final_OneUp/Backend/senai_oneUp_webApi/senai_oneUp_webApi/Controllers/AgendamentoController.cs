using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_oneUp_webApi.Contexts;
using senai_oneUp_webApi.Domain;
using senai_oneUp_webApi.Interface;
using senai_oneUp_webApi.Repository;
using senai_oneUp_webApi.viewwModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_oneUp_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class agendamentoController : ControllerBase
    {

        OneUpContext ctx = new OneUpContext();

        private IAgendamentoRepository _agendamentoRepository { get; set; }

        public agendamentoController()
        {
            _agendamentoRepository = new agendamentoRepository();
        }

        [HttpGet]
       public IActionResult Get(int id)
       {
            
            try
            {
                return Ok(_agendamentoRepository.ListarTodos(id));
            }

            catch(Exception erro)
            {
                return BadRequest(erro);
            }
               


       }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_agendamentoRepository.BuscarPorId(id));
            }

            catch(Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _agendamentoRepository.Deletar(id);

                return StatusCode(201);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Post(Agendamento novoAgendamento)
        {
            try
            {
                _agendamentoRepository.Cadastrar(novoAgendamento);

                return StatusCode(201);
            }

            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult Put(int id, Agendamento agendamentoAtualizado)
        {
            try
            {
                _agendamentoRepository.Atualizar(id, agendamentoAtualizado);

                return StatusCode(201);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
