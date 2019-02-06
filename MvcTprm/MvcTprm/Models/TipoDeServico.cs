using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MvcTprm.Models
{
    public class TipoDeServico
    {
        public int TipoDeServicoId { get; set; }
        public string NomeServico { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
    }

}