using senai_oneUp_webApi.Contexts;
using senai_oneUp_webApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_oneUp_webApi.Repository
{
    public class uploadRepository
    {

        OneUpContext ctx = new OneUpContext();


        public void Upload(Arquivo novoArquivo)
        {
            ctx.Arquivos.Add(novoArquivo);

            ctx.SaveChanges();
        }

    }
}
