using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTprm.Models
{
    public class Transacao
    {
        public int TransacaoId { get; set; }
        public int empresaContratanteID { get; set; }
        public int enpresaContratadaID { get; set; }
        public string tipoDeServico { get; set; }
        public decimal valorDoServico { get; set; }
        public string descricao { get; set; }

        public Status StatusTransacao { get; set; }

        public virtual Cliente empresaContratante { get; set; }
        public virtual Cliente empresaContratada { get; set; }

    }
    public enum Status
    {
        Aprovada,
        Rejeitada,
        Submetida
    }
}