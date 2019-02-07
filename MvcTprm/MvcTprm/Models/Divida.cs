using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTprm.Models
{
    public class Divida
    {
        public int DividaId { get; set; }
        public int ClienteId { get; set; }
        public decimal ValorDaDivida { get; set; }

        public virtual Cliente Cliente { get; set; }
    }

}
