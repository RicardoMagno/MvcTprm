using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;//not
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNet.Identity.EntityFramework;
using MvcTprm.Models;
//using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace  MvcTprm.Data
{
    public class MvcTprmContext : IdentityDbContext<ApplicationUser>
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
