﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Yi.Framework.Model;

namespace Yi.Framework.Model.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211030074922_yi-5")]
    partial class yi5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Yi.Framework.Model.Models.menu", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("icon")
                        .HasColumnType("longtext");

                    b.Property<int>("is_delete")
                        .HasColumnType("int");

                    b.Property<int>("is_show")
                        .HasColumnType("int");

                    b.Property<int>("is_top")
                        .HasColumnType("int");

                    b.Property<string>("menu_name")
                        .HasColumnType("longtext");

                    b.Property<int?>("menuid")
                        .HasColumnType("int");

                    b.Property<int?>("mouldid")
                        .HasColumnType("int");

                    b.Property<int?>("roleid")
                        .HasColumnType("int");

                    b.Property<string>("router")
                        .HasColumnType("longtext");

                    b.Property<int>("sort")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("menuid");

                    b.HasIndex("mouldid");

                    b.HasIndex("roleid");

                    b.ToTable("menu");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.mould", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("is_delete")
                        .HasColumnType("int");

                    b.Property<string>("mould_name")
                        .HasColumnType("longtext");

                    b.Property<string>("url")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("mould");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.role", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("introduce")
                        .HasColumnType("longtext");

                    b.Property<int>("is_delete")
                        .HasColumnType("int");

                    b.Property<string>("role_name")
                        .HasColumnType("longtext");

                    b.Property<int?>("userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("role");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.user", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .HasColumnType("longtext");

                    b.Property<int?>("age")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("longtext");

                    b.Property<string>("icon")
                        .HasColumnType("longtext");

                    b.Property<string>("introduction")
                        .HasColumnType("longtext");

                    b.Property<string>("ip")
                        .HasColumnType("longtext");

                    b.Property<int>("is_delete")
                        .HasColumnType("int");

                    b.Property<string>("nick")
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .HasColumnType("longtext");

                    b.Property<int?>("phone")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.visit", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("is_delete")
                        .HasColumnType("int");

                    b.Property<int>("num")
                        .HasColumnType("int");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime(6)");

                    b.HasKey("id");

                    b.ToTable("visit");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.menu", b =>
                {
                    b.HasOne("Yi.Framework.Model.Models.menu", null)
                        .WithMany("children")
                        .HasForeignKey("menuid");

                    b.HasOne("Yi.Framework.Model.Models.mould", "mould")
                        .WithMany()
                        .HasForeignKey("mouldid");

                    b.HasOne("Yi.Framework.Model.Models.role", null)
                        .WithMany("menus")
                        .HasForeignKey("roleid");

                    b.Navigation("mould");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.role", b =>
                {
                    b.HasOne("Yi.Framework.Model.Models.user", null)
                        .WithMany("roles")
                        .HasForeignKey("userid");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.menu", b =>
                {
                    b.Navigation("children");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.role", b =>
                {
                    b.Navigation("menus");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.user", b =>
                {
                    b.Navigation("roles");
                });
#pragma warning restore 612, 618
        }
    }
}