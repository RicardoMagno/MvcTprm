using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace  MvcTprm.Models

{
    public class Cliente
    {
        public int ClienteId {get;set;}
        public string NomeEmpresa {get;set;}
    }
}