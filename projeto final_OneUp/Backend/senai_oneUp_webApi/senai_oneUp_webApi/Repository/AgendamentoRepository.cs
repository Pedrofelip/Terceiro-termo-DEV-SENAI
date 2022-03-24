using senai_oneUp_webApi.Contexts;
using senai_oneUp_webApi.Domain;
using senai_oneUp_webApi.Interface;
using senai_oneUp_webApi.viewwModel;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_oneUp_webApi.Repository
{
    public class agendamentoRepository : IAgendamentoRepository
    {

        OneUpContext ctx = new OneUpContext();

        /// <summary>
        /// Atualiza um agendamento existente
        /// </summary>
        /// <param name="id">ID do agendamento que será atualizado</param>
        /// <param name="agendamentoAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Agendamento agendamentoAtualizado)
        {
            //busca um agendamento através do ID
            Agendamento agendamentoBuscado = ctx.Agendamentos.Find(id);

            //Verifica se o id do agendamento informado é maior que 0
            if(agendamentoAtualizado.IdAgendamento > 0)
            {
                //Atribui os valores aos campos existentes
                agendamentoBuscado.IdAgendamento = agendamentoAtualizado.IdAgendamento;
            }

            //Verifica se o id do representante foi informado
            if(agendamentoAtualizado.IdRepresentante != null)
            {
                //Atribui os valores aos campos existentes
                agendamentoBuscado.IdRepresentante = agendamentoAtualizado.IdRepresentante;
            }

            //verifica se o id do varejista foi informado
            if(agendamentoAtualizado.IdVarejista != null)
            {
                //Atribui os valores aos campos existentes
                agendamentoBuscado.IdVarejista = agendamentoAtualizado.IdVarejista;
            }

            //Verifica se a data foi informada
            if(agendamentoAtualizado.Data != null)
            {
                //Atribui os valores aos campos existentes
                agendamentoBuscado.Data = agendamentoAtualizado.Data;
            }

            //Verifica se uma presença foi informada
            if(agendamentoAtualizado.Presencas != null)
            {
                //Atribui os valores aos campos existentes
                agendamentoBuscado.Presencas = agendamentoAtualizado.Presencas;
            }

            //Verifica se uma descrição foi informada
            if(agendamentoAtualizado.Descricao != null)
            {
                //Atribui os valores aos campos existentes
                agendamentoBuscado.Descricao = agendamentoAtualizado.Descricao;
            }

            //Atualiza o agendamento que foi selecionado
            ctx.Agendamentos.Update(agendamentoBuscado);

            //Salva as novas informações de um agendamento
            ctx.SaveChanges();
        }
        /// <summary>
        /// Busca um agendamento através do seu id
        /// </summary>
        /// <param name="id">Id do agendamento que será buscado</param>
        /// <returns>Um agendamento buscado</returns>
        public Agendamento BuscarPorId(int id)
        {
            //Retorna o primeiro agendamento encontrado para o ID informado
            return ctx.Agendamentos.FirstOrDefault(p => p.IdAgendamento == id);
        }

        /// <summary>
        /// Cadastra um novo agendamento
        /// </summary>
        /// <param name="novoAgendamento">Objeto novoAgendamento que será cadastrado</param>
        public void Cadastrar(Agendamento novoAgendamento)
        {
            //Adiciona novoAgendamento
            ctx.Agendamentos.Add(novoAgendamento);

            //Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Exclui um agendamento
        /// </summary>
        /// <param name="id">Id do agendamento</param>
        public void Deletar(int id)
        {
            Agendamento agendamentoBuscado = ctx.Agendamentos.Find(id);

            ctx.Agendamentos.Remove(agendamentoBuscado);

            ctx.SaveChanges();
        }

        public List<Agendamento> ListarTodos(int id)
        {
            return ctx.Agendamentos
                .Include(e => e.IdRepresentanteNavigation)
                .Include(e => e.IdArquivoNavigation)
                .Include(e => e.Presencas)
                .Where(e => e.IdVarejista == id)
                .ToList();
        }
    }
}
