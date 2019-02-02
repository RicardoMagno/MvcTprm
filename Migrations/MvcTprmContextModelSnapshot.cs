﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcTprm.Models;
using MvcTprm.Data;

namespace MvcTprm.Migrations
{
    [DbContext(typeof(MvcTprmContext))]
    partial class MvcTprmContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("MvcTprm.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NomeEmpresa");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("MvcTprm.Models.Divida", b =>
                {
                    b.Property<int>("DividaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteId");

                    b.Property<string>("ClienteNome");

                    b.Property<decimal>("ValorDaDivida");

                    b.HasKey("DividaId");

                    b.ToTable("Dividas");
                });

            modelBuilder.Entity("MvcTprm.Models.TipoDeServico", b =>
                {
                    b.Property<int>("TipoDeServicoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("NomeServico");

                    b.Property<decimal>("Valor");

                    b.HasKey("TipoDeServicoId");

                    b.ToTable("TipoDeServicos");
                });

            modelBuilder.Entity("MvcTprm.Models.Transacao", b =>
                {
                    b.Property<int>("TransacaoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteContratanteId");

                    b.Property<int>("ContratadaId");

                    b.Property<string>("NomeEmpresa");

                    b.Property<string>("NomeEmpresaContratada");

                    b.Property<string>("descricao");

                    b.Property<string>("tipoDeServico");

                    b.Property<decimal>("valorDoServico");

                    b.HasKey("TransacaoId");

                    b.ToTable("Transacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
