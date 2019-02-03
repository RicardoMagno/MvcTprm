using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcTprm.Models
{
    public class TransacaoOperacaoViewModel
    {
        public List<Transacao> Transacoes;
        public SelectList Operacoes;
        public string TransacaoOperacao { get; set; }
        public string SearchString { get; set; }

    }
}