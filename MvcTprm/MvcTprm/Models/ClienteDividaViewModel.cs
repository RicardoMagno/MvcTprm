using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTprm.Models
{
    public class ClienteDividaViewModel
    {
        //Informações do Cliente
        public string Nome { get; set; }

        //Informações da Divida 
        public decimal ValorDaDivida { get; set; }
    }
}