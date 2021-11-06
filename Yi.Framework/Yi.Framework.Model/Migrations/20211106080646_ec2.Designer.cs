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
    [Migration("20211106080646_ec2")]
    partial class ec2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Yi.Framework.Model.Models.brand", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .HasColumnType("longtext");

                    b.Property<int>("is_delete")
                        .HasColumnType("int");

                    b.Property<string>("letter")
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("brand");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.brand_category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("brandId")
                        .HasColumnType("int");

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<int>("is_delete")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("brandId");

                    b.HasIndex("categoryId");

                    b.ToTable("brand_category");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("categoryid")
                        .HasColumnType("int");

                    b.Property<int>("is_delete")
                        .HasColumnType("int");

                    b.Property<int>("is_parent")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<int>("sort")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("categoryid");

                    b.ToTable("category");
                });

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

            modelBuilder.Entity("Yi.Framework.Model.Models.order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("actual_pay")
                        .HasColumnType("int");

                    b.Property<string>("buyer_message")
                        .HasColumnType("longtext");

                    b.Property<string>("buyer_nick")
                        .HasColumnType("longtext");

                    b.Property<int>("buyer_rate")
                        .HasColumnType("int");

                    b.Property<DateTime>("creat_time")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("invoice_type")
                        .HasColumnType("int");

                    b.Property<int>("is_delete")
                        .HasColumnType("int");

                    b.Property<int>("payment_type")
                        .HasColumnType("int");

                    b.Property<int>("post_fee")
                        .HasColumnType("int");

                    b.Property<string>("promotion_ids")
                        .HasColumnType("longtext");

                    b.Property<string>("receiver")
                        .HasColumnType("longtext");

                    b.Property<string>("receiver_address")
                        .HasColumnType("longtext");

                    b.Property<string>("receiver_city")
                        .HasColumnType("longtext");

                    b.Property<string>("receiver_district")
                        .HasColumnType("longtext");

                    b.Property<string>("receiver_mobile")
                        .HasColumnType("longtext");

                    b.Property<string>("receiver_state")
                        .HasColumnType("longtext");

                    b.Property<string>("receiver_zip")
                        .HasColumnType("longtext");

                    b.Property<string>("shipping_code")
                        .HasColumnType("longtext");

                    b.Property<string>("shipping_name")
                        .HasColumnType("longtext");

                    b.Property<int?>("skuid")
                        .HasColumnType("int");

                    b.Property<int>("source_type")
                        .HasColumnType("int");

                    b.Property<int>("total_pay")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("skuid");

                    b.ToTable("order");
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

            modelBuilder.Entity("Yi.Framework.Model.Models.sku", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("crate_time")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("enable")
                        .HasColumnType("int");

                    b.Property<string>("images")
                        .HasColumnType("longtext");

                    b.Property<string>("indexes")
                        .HasColumnType("longtext");

                    b.Property<int>("is_delete")
                        .HasColumnType("int");

                    b.Property<DateTime>("last_update_time")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("own_spec")
                        .HasColumnType("longtext");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int?>("spuid")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("spuid");

                    b.ToTable("sku");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.spec_group", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("categoryid")
                        .HasColumnType("int");

                    b.Property<int>("is_delete")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("categoryid");

                    b.ToTable("spec_group");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.spec_param", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("categoryid")
                        .HasColumnType("int");

                    b.Property<int>("generic")
                        .HasColumnType("int");

                    b.Property<int>("is_delete")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<int>("numeric")
                        .HasColumnType("int");

                    b.Property<int>("searching")
                        .HasColumnType("int");

                    b.Property<string>("segments")
                        .HasColumnType("longtext");

                    b.Property<int?>("spec_Groupid")
                        .HasColumnType("int");

                    b.Property<string>("unit")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("categoryid");

                    b.HasIndex("spec_Groupid");

                    b.ToTable("spec_param");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.spu", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("brandid")
                        .HasColumnType("int");

                    b.Property<DateTime>("crate_time")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("is_delete")
                        .HasColumnType("int");

                    b.Property<DateTime>("last_update_time")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("saleable")
                        .HasColumnType("int");

                    b.Property<int?>("spu_Detailid")
                        .HasColumnType("int");

                    b.Property<string>("sub_title")
                        .HasColumnType("longtext");

                    b.Property<string>("title")
                        .HasColumnType("longtext");

                    b.Property<int>("valid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("brandid");

                    b.HasIndex("spu_Detailid");

                    b.ToTable("spu");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.spu_detail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("after_service")
                        .HasColumnType("longtext");

                    b.Property<string>("description")
                        .HasColumnType("longtext");

                    b.Property<string>("generic_spec")
                        .HasColumnType("longtext");

                    b.Property<int>("is_delete")
                        .HasColumnType("int");

                    b.Property<string>("packing_list")
                        .HasColumnType("longtext");

                    b.Property<string>("special_spec")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("spu_detail");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.stock", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("is_delete")
                        .HasColumnType("int");

                    b.Property<int>("seckill_stock")
                        .HasColumnType("int");

                    b.Property<int>("seckill_total")
                        .HasColumnType("int");

                    b.Property<int?>("skuid")
                        .HasColumnType("int");

                    b.Property<int>("stock_count")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("skuid");

                    b.ToTable("stock");
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

            modelBuilder.Entity("categoryspu", b =>
                {
                    b.Property<int>("categoriesid")
                        .HasColumnType("int");

                    b.Property<int>("spusid")
                        .HasColumnType("int");

                    b.HasKey("categoriesid", "spusid");

                    b.HasIndex("spusid");

                    b.ToTable("categoryspu");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.brand_category", b =>
                {
                    b.HasOne("Yi.Framework.Model.Models.brand", "brand")
                        .WithMany("categories")
                        .HasForeignKey("brandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Yi.Framework.Model.Models.category", "category")
                        .WithMany("brands")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("brand");

                    b.Navigation("category");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.category", b =>
                {
                    b.HasOne("Yi.Framework.Model.Models.category", null)
                        .WithMany("chidrens")
                        .HasForeignKey("categoryid");
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

            modelBuilder.Entity("Yi.Framework.Model.Models.order", b =>
                {
                    b.HasOne("Yi.Framework.Model.Models.sku", null)
                        .WithMany("orders")
                        .HasForeignKey("skuid");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.role", b =>
                {
                    b.HasOne("Yi.Framework.Model.Models.user", null)
                        .WithMany("roles")
                        .HasForeignKey("userid");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.sku", b =>
                {
                    b.HasOne("Yi.Framework.Model.Models.spu", "spu")
                        .WithMany("skus")
                        .HasForeignKey("spuid");

                    b.Navigation("spu");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.spec_group", b =>
                {
                    b.HasOne("Yi.Framework.Model.Models.category", "category")
                        .WithMany("spec_Groups")
                        .HasForeignKey("categoryid");

                    b.Navigation("category");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.spec_param", b =>
                {
                    b.HasOne("Yi.Framework.Model.Models.category", "category")
                        .WithMany("spec_Params")
                        .HasForeignKey("categoryid");

                    b.HasOne("Yi.Framework.Model.Models.spec_group", "spec_Group")
                        .WithMany("spec_Params")
                        .HasForeignKey("spec_Groupid");

                    b.Navigation("category");

                    b.Navigation("spec_Group");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.spu", b =>
                {
                    b.HasOne("Yi.Framework.Model.Models.brand", "brand")
                        .WithMany("spus")
                        .HasForeignKey("brandid");

                    b.HasOne("Yi.Framework.Model.Models.spu_detail", "spu_Detail")
                        .WithMany()
                        .HasForeignKey("spu_Detailid");

                    b.Navigation("brand");

                    b.Navigation("spu_Detail");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.stock", b =>
                {
                    b.HasOne("Yi.Framework.Model.Models.sku", "sku")
                        .WithMany()
                        .HasForeignKey("skuid");

                    b.Navigation("sku");
                });

            modelBuilder.Entity("categoryspu", b =>
                {
                    b.HasOne("Yi.Framework.Model.Models.category", null)
                        .WithMany()
                        .HasForeignKey("categoriesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Yi.Framework.Model.Models.spu", null)
                        .WithMany()
                        .HasForeignKey("spusid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.brand", b =>
                {
                    b.Navigation("categories");

                    b.Navigation("spus");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.category", b =>
                {
                    b.Navigation("brands");

                    b.Navigation("chidrens");

                    b.Navigation("spec_Groups");

                    b.Navigation("spec_Params");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.menu", b =>
                {
                    b.Navigation("children");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.role", b =>
                {
                    b.Navigation("menus");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.sku", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.spec_group", b =>
                {
                    b.Navigation("spec_Params");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.spu", b =>
                {
                    b.Navigation("skus");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.user", b =>
                {
                    b.Navigation("roles");
                });
#pragma warning restore 612, 618
        }
    }
}
