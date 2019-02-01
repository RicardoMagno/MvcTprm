using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace  MvcTprm.Models
{
    public class Divida
    {
        public int DividaId {get;set;}
        public int ClienteId {get;set;}
        public string ClienteNome {get;set;}
        public decimal ValorDaDivida {get;set;}
    }
}