using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using MvcTprm.Models;
using MvcTprm.DAL;
using System.Collections.Generic;
using System.Web;

namespace MvcTprm.DAL
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<TprmContext>
    {

        protected override void Seed(TprmContext context)
        {
            var clientes = new List<Cliente>
                {
                new Cliente{Nome="Wayne Enterprises"},
                new Cliente{Nome="IGen"},
                new Cliente{Nome="Indústrias Oscorp"},
                new Cliente{Nome="Weasleys Wizard Wheezes"},
                new Cliente{Nome="Wayne Enterprise"},
                new Cliente{Nome="Pizza Planet"},
                new Cliente{Nome="Monsters, INC"},
                new Cliente{Nome="ACME"},
                new Cliente{Nome="Stark Industries" },
                new Cliente{Nome="Lex Corp" },
                };

            clientes.ForEach(s => context.Clientes.Add(s));
            context.SaveChanges();
            var dividas = new List<Divida>
                {
                new Divida{ClienteId=1, ValorDaDivida=20},
                new Divida{ClienteId=2, ValorDaDivida=30},
                new Divida{ClienteId=3, ValorDaDivida=50},
                new Divida{ClienteId=4, ValorDaDivida=60},
                new Divida{ClienteId=5, ValorDaDivida=10},
                new Divida{ClienteId=5, ValorDaDivida=25},
                new Divida{ClienteId=6, ValorDaDivida=20},
                };
            dividas.ForEach(s => context.Dividas.Add(s));
            context.SaveChanges();
            var transacoes = new List<Transacao>
                {
                new Transacao{empresaContratanteID=1, enpresaContratadaID=2,tipoDeServico = "TIPO1", valorDoServico=30, descricao="tipo 1" },
                new Transacao{empresaContratanteID=1, enpresaContratadaID=2,tipoDeServico = "TIPO1", valorDoServico=30, descricao="tipo 1" },
                new Transacao{empresaContratanteID=1, enpresaContratadaID=2,tipoDeServico = "TIPO1", valorDoServico=30, descricao="tipo 1" },
                new Transacao{empresaContratanteID=1, enpresaContratadaID=2,tipoDeServico = "TIPO1", valorDoServico=30, descricao="tipo 1" },
                new Transacao{empresaContratanteID=1, enpresaContratadaID=2,tipoDeServico = "TIPO1", valorDoServico=30, descricao="tipo 1" },
                new Transacao{empresaContratanteID=1, enpresaContratadaID=2,tipoDeServico = "TIPO1", valorDoServico=30, descricao="tipo 1" },
                new Transacao{empresaContratanteID=1, enpresaContratadaID=2,tipoDeServico = "TIPO1", valorDoServico=30, descricao="tipo 1" },

                };
            transacoes.ForEach(s => context.Transacoes.Add(s));
            context.SaveChanges();

        }
    }
}
