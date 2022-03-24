using senai_oneUp_webApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_oneUp_webApi.Interface
{
    public interface IpresencaRepository
    {

        List<Presenca> Listar();

        void Atualizar(int id, Presenca presencaAtualizada);

         List<Presenca> ListarMinhas(int id);

         void AprovarRecusar(int id, string status);

    }
}
