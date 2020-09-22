﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using vsk_betacent.Models;

namespace vsk_betacent.Migrations
{
    [DbContext(typeof(vsk_dbcontext))]
    [Migration("20200911131023_UpdateNoticeTable")]
    partial class UpdateNoticeTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("vsk_betacent.Models.DataEntities.tbl_blood_gr", b =>
                {
                    b.Property<int>("int_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("txt_bld_gr")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("int_id");

                    b.ToTable("tbl_blood_gr");
                });

            modelBuilder.Entity("vsk_betacent.Models.DataEntities.tbl_desig_type", b =>
                {
                    b.Property<int>("int_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("txt_desig")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("int_id");

                    b.ToTable("tbl_desig_type");
                });

            modelBuilder.Entity("vsk_betacent.Models.DataEntities.tbl_gallery", b =>
                {
                    b.Property<int>("int_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dt_doc")
                        .HasColumnType("datetime2");

                    b.Property<string>("txt_file")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("txt_position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("txt_title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("int_id");

                    b.ToTable("tbl_gallery");
                });

            modelBuilder.Entity("vsk_betacent.Models.DataEntities.tbl_notice", b =>
                {
                    b.Property<int>("int_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dt_dou")
                        .HasColumnType("datetime2");

                    b.Property<string>("txt_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("txt_file")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("txt_proiority")
                        .HasColumnType("int");

                    b.Property<string>("txt_title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("int_id");

                    b.ToTable("tbl_notice");
                });

            modelBuilder.Entity("vsk_betacent.Models.DataEntities.tbl_profesn", b =>
                {
                    b.Property<int>("int_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("txt_profs")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("int_id");

                    b.ToTable("tbl_profesn");
                });

            modelBuilder.Entity("vsk_betacent.Models.DataEntities.tbl_qualification", b =>
                {
                    b.Property<int>("int_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("txt_qua")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("int_id");

                    b.ToTable("tbl_qualification");
                });

            modelBuilder.Entity("vsk_betacent.Models.DataEntities.tbl_staff_profile", b =>
                {
                    b.Property<int>("int_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dt_dob")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dt_doc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dt_dom")
                        .HasColumnType("datetime2");

                    b.Property<int>("int_fk_bld_grp")
                        .HasColumnType("int");

                    b.Property<int>("int_fk_desg")
                        .HasColumnType("int");

                    b.Property<int>("int_fk_prof")
                        .HasColumnType("int");

                    b.Property<int>("int_fk_qua")
                        .HasColumnType("int");

                    b.Property<int>("int_gen")
                        .HasColumnType("int");

                    b.Property<int>("int_status")
                        .HasColumnType("int");

                    b.Property<string>("txt_address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("txt_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("txt_fk_sub_area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("txt_img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("txt_mob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("txt_mod_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("txt_nm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("txt_pwd")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("int_id");

                    b.HasIndex("int_fk_bld_grp");

                    b.HasIndex("int_fk_desg");

                    b.HasIndex("int_fk_prof");

                    b.HasIndex("int_fk_qua");

                    b.ToTable("tbl_staff_profile");
                });

            modelBuilder.Entity("vsk_betacent.Models.DataEntities.tbl_sub_area_type", b =>
                {
                    b.Property<int>("int_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("txt_sub")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("int_id");

                    b.ToTable("tbl_sub_area_type");
                });

            modelBuilder.Entity("vsk_betacent.Models.tbl_alumini_details", b =>
                {
                    b.Property<string>("registration_number")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("eamil")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("file")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("marital_status")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("organisation")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("passout_year")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("profession")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("registration_number");

                    b.ToTable("tbl_alumini_details");
                });

            modelBuilder.Entity("vsk_betacent.Models.tbl_inquary", b =>
                {
                    b.Property<string>("inquary_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Contact_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("course")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("query")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("slno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("inquary_id");

                    b.ToTable("tbl_inquary");
                });

            modelBuilder.Entity("vsk_betacent.Models.DataEntities.tbl_staff_profile", b =>
                {
                    b.HasOne("vsk_betacent.Models.DataEntities.tbl_blood_gr", "bld_id")
                        .WithMany()
                        .HasForeignKey("int_fk_bld_grp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vsk_betacent.Models.DataEntities.tbl_desig_type", "desg_id")
                        .WithMany()
                        .HasForeignKey("int_fk_desg")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vsk_betacent.Models.DataEntities.tbl_profesn", "prof_id")
                        .WithMany()
                        .HasForeignKey("int_fk_prof")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vsk_betacent.Models.DataEntities.tbl_qualification", "qualif_id")
                        .WithMany()
                        .HasForeignKey("int_fk_qua")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
