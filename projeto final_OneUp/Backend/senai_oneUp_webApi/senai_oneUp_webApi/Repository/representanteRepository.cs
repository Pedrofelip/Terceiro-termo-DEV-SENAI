using senai_oneUp_webApi.Contexts;
using senai_oneUp_webApi.Domain;
using senai_oneUp_webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_oneUp_webApi.Repository
{
    public class representanteRepository : IrepresentanteRepository
    {
        OneUpContext ctx = new OneUpContext();

        public void Atualizar(int id, Representante representanteAtualizado)
        {
            Representante representanteBuscado = ctx.Representantes.Find(id);

            if (representanteAtualizado.Nome != null)
            {
                representanteBuscado.Nome = representanteAtualizado.Nome;
            }

            if (representanteAtualizado.Email != null)
            {
                representanteBuscado.Email = representanteAtualizado.Email;
            }

            if (representanteAtualizado.Senha != null)
            {
                representanteBuscado.Senha = representanteAtualizado.Senha;
            }

            if (representanteAtualizado.Marca != null)
            {
                representanteBuscado.Marca = representanteAtualizado.Marca;
            }

            if (representanteAtualizado.Produto != null)
            {
                representanteBuscado.Produto = representanteAtualizado.Produto;
            }

            if (representanteAtualizado.Contato != null)
            {
                representanteBuscado.Contato = representanteAtualizado.Contato;
            }

            ctx.Representantes.Update(representanteBuscado);

            ctx.SaveChanges();
        }

        public Representante BuscarPorId(int id)
        {
            return ctx.Representantes.FirstOrDefault(e => e.IdRepresentante == id);
        }

        public void Cadastrar(Representante novoRepresentante)
        {
            novoRepresentante.Senha = md5Hash.CalculaHash(novoRepresentante.Senha);

            ctx.Representantes.Add(novoRepresentante);
            ctx.SaveChanges();

        }

        public void Deletar(int id)
        {
            Representante representante = BuscarPorId(id);
            ctx.Representantes.Remove(representante);
            ctx.SaveChanges();
        }

        public List<Representante> Listar()
        {
            return ctx.Representantes.ToList();
        }

        public Representante Login(string email, string senha)
        {
            return ctx.Representantes.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}

