using System;
using System.Collections.Generic;

#nullable disable

namespace senai_oneUp_webApi.Domain
{
    public partial class Representante
    {
        public Representante()
        {
            Agendamentos = new HashSet<Agendamento>();
            Presenca = new HashSet<Presenca>();
        }

        public int IdRepresentante { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Marca { get; set; }
        public string Produto { get; set; }
        public string Contato { get; set; }
        public int Permissao { get; set; }
        public virtual ICollection<Agendamento> Agendamentos { get; set; }
        public virtual ICollection<Presenca> Presenca { get; set; }
    }
}
