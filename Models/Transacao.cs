using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MvcTprm.Models
{
    public class Transacao
    {
        public int TransacaoId {get; set;}
        public string OwnerID { get; set; }
        public string NomeEmpresa {get;set;}
        public string NomeEmpresaContratada {get;set;}
        public string tipoDeServico {get;set;}
        public decimal valorDoServico {get;set;}
        public string descricao {get;set;}

        public Status StatusTransacao { get; set; }
    }

    public enum Status
    {
        Enviada,
        Aprovada,
        Rejeitada
    }
    
}