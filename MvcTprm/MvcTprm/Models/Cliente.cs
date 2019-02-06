using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTprm.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<Transacao> transacoes { get; set; }
    }
}