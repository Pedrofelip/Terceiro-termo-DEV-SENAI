using senai_oneUp_webApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_oneUp_webApi.Interface
{
    interface IvarejistaRepository
    {
        public Varejistum Login(string email, string senha);
        void Cadastrar(Varejistum novoVarejista);
        List<Varejistum> Listar();
        Varejistum BuscarPorId(int id);
        void Atualizar(int id, Varejistum varejistaAtualizado);
        void Deletar(int id);
    }
}
