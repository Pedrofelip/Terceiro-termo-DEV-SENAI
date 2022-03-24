using System;
using System.Collections.Generic;

#nullable disable

namespace senai_oneUp_webApi.Domain
{
    public partial class Arquivo
    {
        public Arquivo()
        {
            Agendamentos = new HashSet<Agendamento>();
        }

        public int IdArquivo { get; set; }             
        public string CaminhoArquivo { get; set; }

        public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}
