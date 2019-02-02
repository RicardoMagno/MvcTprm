using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using MvcTprm.Models;

namespace  MvcTprm.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcTprmContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcTprmContext>>()))
            {
                SeedDB(context, "0");
            }
        }

        public static void SeedDB(MvcTprmContext context, string adminID)
        {
            if (context.Transacoes.Any())
            {
                return;
            }
            context.Clientes.AddRange(
                new Cliente
                {
                    NomeEmpresa = "Wayne Enterprises"
                },
                new Cliente
                {
                    NomeEmpresa = "LexCorp"
                },
                new Cliente
                {
                    NomeEmpresa = "Indústrias Queen"
                },
                new Cliente
                {
                    NomeEmpresa = "Indústrias Kord"
                },
                new Cliente
                {
                    NomeEmpresa = "STAR Labs"
                }
            );
            context.TipoDeServicos.AddRange(
                new TipoDeServico
                {
                    NomeServico = "Transferencia 1",
                    Valor = 200,
                    Descricao = "Tipo 01"
                },
                new TipoDeServico
                {
                    NomeServico = "Transferencia 1",
                    Valor = 10,
                    Descricao = "Tipo 02"
                },
                new TipoDeServico
                {
                    NomeServico = "Transferencia 1",
                    Valor = 500,
                    Descricao = "Tipo 01"
                },
                new TipoDeServico
                {
                    NomeServico = "Transferencia 2",
                    Valor = 2500,
                    Descricao = "Tipo 02"
                },
                new TipoDeServico
                {
                    NomeServico = "Transferencia 2",
                    Valor = 2300,
                    Descricao = "Tipo 02"
                },
                new TipoDeServico
                {
                    NomeServico = "Transferencia 3",
                    Valor = 10,
                    Descricao = "Tipo 03"
                }
            );
            context.Transacoes.AddRange(
                new Transacao
                {
                    ClienteContratanteId = 1,
                    NomeEmpresa = "Wayne Enterprises",
                    ContratadaId = 3,
                    NomeEmpresaContratada = "Indústrias Queen",
                    tipoDeServico = "Tranferencia 1",
                    valorDoServico = 13000, 
                    descricao = "Tranferencia 5"
                },new Transacao
                {
                    ClienteContratanteId = 4,
                    NomeEmpresa = "Indústrias Kord",
                    ContratadaId = 2,
                    NomeEmpresaContratada = "Indústrias Queen",
                    tipoDeServico = "Tranferencia 5",
                    valorDoServico = 3000, 
                    descricao = "Tranferencia 5"
                },new Transacao
                {
                    ClienteContratanteId = 2,
                    NomeEmpresa = "LexCorp",
                    ContratadaId = 5,
                    NomeEmpresaContratada = "STAR Labs",
                    tipoDeServico = "Tranferencia 2",
                    valorDoServico = 100, 
                    descricao = "Tranferencia 2"
                },new Transacao
                {
                    ClienteContratanteId = 2,
                    NomeEmpresa = "LexCorp",
                    ContratadaId = 2,
                    NomeEmpresaContratada = "LexCorp",
                    tipoDeServico = "Tranferencia 3",
                    valorDoServico = 600000, 
                    descricao = "Tranferencia 3"
                }
            );
            context.Dividas.AddRange(
                new Divida{
                    ClienteId = 1,
                    ClienteNome = "Wayne Enterprises",
                    ValorDaDivida = 150
                },new Divida{
                    ClienteId = 2,
                    ClienteNome = "LexCorp",
                    ValorDaDivida = 30
                },new Divida{
                    ClienteId = 3,
                    ClienteNome = "Indústrias Queen",
                    ValorDaDivida = 5
                },new Divida{
                    ClienteId = 4,
                    ClienteNome = "Indústrias Kord",
                    ValorDaDivida = 10
                }
                ,new Divida{
                    ClienteId = 5,
                    ClienteNome = "STAR Labs",
                    ValorDaDivida = 20
                }

                );
                context.SaveChanges();
            }
        }
    }
