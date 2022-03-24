using Microsoft.EntityFrameworkCore;
using senai_oneUp_webApi.Contexts;
using senai_oneUp_webApi.Domain;
using senai_oneUp_webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_oneUp_webApi.Repository
{
    public class presencaRepository : IpresencaRepository
    {
        OneUpContext ctx = new OneUpContext();

        public void AprovarRecusar(int id, string status)
        {

            Presenca presencaBuscada = ctx.Presencas
 
                .Include(p => p.IdAgendamentoNavigation)
                .FirstOrDefault(p => p.IdPresenca == id);

            switch (status)
            {
                case "1":
                    presencaBuscada.Situacao = "Confirmada";
                    break;

                case "2":
                    presencaBuscada.Situacao = "Recusada";
                    break;

                case "0":
                    presencaBuscada.Situacao = "Aguardando resposta";
                    break;

                default:
                    presencaBuscada.Situacao = presencaBuscada.Situacao;
                    break;
            }

            ctx.Presencas.Update(presencaBuscada);

            ctx.SaveChanges();
        }

       
        public void Atualizar(int id, Presenca presencaAtualizada)
        {
            Presenca presencaBuscada = ctx.Presencas.Find(id);

            
            if (presencaAtualizada.Situacao != null)
            { 
                presencaBuscada.Situacao = presencaAtualizada.Situacao;
            }

            ctx.Presencas.Update(presencaBuscada);

            ctx.SaveChanges();
        }


        public List<Presenca> Listar()
        {
            return ctx.Presencas.ToList();
        }


        public List<Presenca> ListarMinhas(int id)
        {
            return ctx.Presencas
                .Include(p => p.IdAgendamentoNavigation)
                .Include(p => p.IdAgendamentoNavigation.IdArquivoNavigation)            
                .Where(p => p.IdVarejista == id )
                .ToList();
        }
    }
}
