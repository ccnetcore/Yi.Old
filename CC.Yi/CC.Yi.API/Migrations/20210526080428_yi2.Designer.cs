﻿// <auto-generated />
using System;
using CC.Yi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CC.Yi.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210526080428_yi2")]
    partial class yi2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("CC.Yi.Model.prop", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("studentid")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("studentid");

                    b.ToTable("prop");
                });

            modelBuilder.Entity("CC.Yi.Model.student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("student");
                });

            modelBuilder.Entity("CC.Yi.Model.prop", b =>
                {
                    b.HasOne("CC.Yi.Model.student", "student")
                        .WithMany("props")
                        .HasForeignKey("studentid");

                    b.Navigation("student");
                });

            modelBuilder.Entity("CC.Yi.Model.student", b =>
                {
                    b.Navigation("props");
                });
#pragma warning restore 612, 618
        }
    }
}