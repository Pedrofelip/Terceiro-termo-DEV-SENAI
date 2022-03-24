using System;
using System.Collections.Generic;

#nullable disable

namespace senai_oneUp_webApi.Domain
{
    public partial class Varejistum
    {
        public Varejistum()
        {
            Agendamentos = new HashSet<Agendamento>();
            Presencas = new HashSet<Presenca>();
        }

        public int IdVarejista { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Permissao { get; set; }

        public virtual ICollection<Agendamento> Agendamentos { get; set; }
        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
