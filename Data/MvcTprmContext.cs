using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcTprm.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MvcTprm.Data
{
    public class MvcTprmContext : IdentityDbContext
    {
        public MvcTprmContext(DbContextOptions<MvcTprmContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<MvcTprm.Models.Cliente> Clientes {get;set;}
        public DbSet<MvcTprm.Models.TipoDeServico> TipoDeServicos {get;set;}
        public DbSet<MvcTprm.Models.Transacao> Transacoes {get;set;}
        public DbSet<MvcTprm.Models.Divida> Dividas {get;set;}

    }
}
