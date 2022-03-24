using senai_oneUp_webApi.Contexts;
using senai_oneUp_webApi.Domain;
using senai_oneUp_webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_oneUp_webApi.Repository
{
    public class arquivoRepository : IArquivoRepository
    {

        OneUpContext ctx = new OneUpContext();

        public void Atualizar(Arquivo arquivoAtualizado)
        {
            Arquivo arquivoBuscado = ctx.Arquivos.Find();

            if(arquivoAtualizado.IdArquivo > 0)
            {
                arquivoBuscado.IdArquivo = arquivoAtualizado.IdArquivo;
            }

            if(arquivoBuscado.CaminhoArquivo != null)
            {
                arquivoBuscado.CaminhoArquivo = arquivoAtualizado.CaminhoArquivo;
            }

            ctx.Arquivos.Update(arquivoBuscado);

            ctx.SaveChanges();

        }

        public void Cadastrar(Arquivo novoArquivo)
        {


            ctx.Arquivos.Add(novoArquivo);

            ctx.SaveChanges();

            
        }

        public void Deletar(int id)
        {
            Arquivo arquivoBuscado = ctx.Arquivos.Find();

            ctx.Arquivos.Remove(arquivoBuscado);

            ctx.SaveChanges();
        }

        public List<Arquivo> ListarTodos()
        {
            return ctx.Arquivos.ToList();
        }

    
    }
}
