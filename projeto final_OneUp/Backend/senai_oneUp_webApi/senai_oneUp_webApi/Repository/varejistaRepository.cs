using senai_oneUp_webApi.Contexts;
using senai_oneUp_webApi.Domain;
using senai_oneUp_webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_oneUp_webApi.Repository
{
    public class varejistaRepository : IvarejistaRepository
    {
        OneUpContext ctx = new OneUpContext();

        public void Atualizar(int id, Varejistum varejistaAtualizado)
        {
            Varejistum varejistaBuscado = ctx.Varejista.Find(id);

            if (varejistaAtualizado.Nome != null)
            {
                varejistaBuscado.Nome = varejistaAtualizado.Nome;
            }

            if (varejistaAtualizado.Email != null)
            {
                varejistaBuscado.Email = varejistaAtualizado.Email;
            }

            if (varejistaAtualizado.Senha != null)
            {
                varejistaBuscado.Senha = varejistaAtualizado.Senha;
            }

            ctx.Varejista.Update(varejistaBuscado);

            ctx.SaveChanges();
        }

        public Varejistum BuscarPorId(int id)
        {
            return ctx.Varejista.FirstOrDefault(e => e.IdVarejista == id);
        }

        public void Cadastrar(Varejistum novoVarejista)
        {

            novoVarejista.Senha = md5Hash.CalculaHash(novoVarejista.Senha);

            ctx.Varejista.Add(novoVarejista);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Varejistum varejista = BuscarPorId(id);
            ctx.Varejista.Remove(varejista);
            ctx.SaveChanges();
        }

        public List<Varejistum> Listar()
        {
            return ctx.Varejista.ToList();
        }

        public Varejistum Login(string email, string senha)
        {
            return ctx.Varejista.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
