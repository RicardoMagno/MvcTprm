using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTprm.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MvcTprm.DAL
{
    public class TprmContext : DbContext
    {
        public TprmContext() : base("TprmContext")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Divida> Dividas { get; set; }
        public DbSet<TipoDeServico> TipoDeServicos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}