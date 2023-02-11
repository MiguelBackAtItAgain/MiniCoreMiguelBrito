﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniCore.Data;

#nullable disable

namespace MiniCore.Migrations
{
    [DbContext(typeof(MiniCoreContext))]
    [Migration("20230123001712_deploy")]
    partial class deploy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MiniCore.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("MiniCore.Models.Contrato", b =>
                {
                    b.Property<int>("ContratoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContratoId"), 1L, 1);

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<float>("Monto")
                        .HasColumnType("real");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContratoId");

                    b.HasIndex("ClienteID");

                    b.ToTable("Contrato");
                });

            modelBuilder.Entity("MiniCore.Models.Contrato", b =>
                {
                    b.HasOne("MiniCore.Models.Cliente", "Cliente")
                        .WithMany("Contratos")
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("MiniCore.Models.Cliente", b =>
                {
                    b.Navigation("Contratos");
                });
#pragma warning restore 612, 618
        }
    }
}
