using System;
using System.Collections.Generic;

#nullable disable

namespace senai_oneUp_webApi.Domain
{
    public partial class Agendamento
    {
        public Agendamento()
        {
            Presencas = new HashSet<Presenca>();
        }

        public int IdAgendamento { get; set; }
        public int? IdRepresentante { get; set; }
        public int? IdVarejista { get; set; }
        public int? IdArquivo { get; set; }
        public DateTime? Data { get; set; }
        public string Descricao { get; set; }
        public string Link { get; set; }
        public string Marca { get; set; }

        public virtual Arquivo IdArquivoNavigation { get; set; }
        public virtual Representante IdRepresentanteNavigation { get; set; }
        public virtual Varejistum IdVarejistaNavigation { get; set; }
        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
