using senai_oneUp_webApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_oneUp_webApi.Interface
{
    interface IrepresentanteRepository
    {
        public Representante Login(string email, string senha);
        void Cadastrar(Representante novoRepresentante);
        List<Representante> Listar();
        Representante BuscarPorId(int id);
        void Atualizar(int id, Representante representanteAtualizado);
        void Deletar(int id);

    }
}
