using senai_oneUp_webApi.Domain;
using senai_oneUp_webApi.viewwModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_oneUp_webApi.Interface
{
    public interface IAgendamentoRepository
    {
        void Cadastrar(Agendamento novoAgendamento);

        void Deletar(int id);

        void Atualizar(int id, Agendamento agendamentoAtualizado);

        List<Agendamento> ListarTodos(int id);
        
        Agendamento BuscarPorId(int id);      
    }
}
