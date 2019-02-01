using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace  MvcTprm.Models
{
    public class TipoDeServico
    {
        public int TipoDeServicoId {get;set;}
        public string NomeServico {get;set;}
        public decimal Valor {get;set;}
        public string Descricao {get;set;}
    }
    
}