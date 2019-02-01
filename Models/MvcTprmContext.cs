using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace  MvcTprm.Models
{
    public class MvcTprmContext : DbContext
    {
        public MvcTprmContext(DbContextOptions<MvcTprmContext> options)
            : base(options)
        { }
        public DbSet<Cliente> Clientes {get;set;}
        public DbSet<TipoDeServico> TipoDeServicos {get;set;}
        public DbSet<Transacao> Transacoes {get;set;}
        public DbSet<Divida> Dividas {get;set;}

    }
}
