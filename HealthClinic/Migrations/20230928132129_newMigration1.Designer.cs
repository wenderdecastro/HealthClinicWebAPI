﻿// <auto-generated />
using System;
using HealthClinic.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthCare.Migrations
{
    [DbContext(typeof(HealthClinicContext))]
    [Migration("20230928132129_newMigration1")]
    partial class newMigration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HealthClinic.Domains.Clinic", b =>
                {
                    b.Property<Guid>("ClinicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPNJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR(14)");

                    b.Property<TimeSpan>("ClosingTime")
                        .HasColumnType("TIME");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.Property<TimeSpan>("OpeningTime")
                        .HasColumnType("TIME");

                    b.Property<string>("TradeName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.HasKey("ClinicId");

                    b.HasIndex("CPNJ")
                        .IsUnique();

                    b.ToTable("Clinic");
                });

            modelBuilder.Entity("HealthClinic.Domains.FeedBack", b =>
                {
                    b.Property<Guid>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClinicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("VARCHAR(1024)");

                    b.Property<bool>("IsShown")
                        .HasColumnType("BIT");

                    b.Property<Guid>("MedicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MedicalAppointmentId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("INT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FeedbackId");

                    b.HasIndex("ClinicId");

                    b.HasIndex("MedicId");

                    b.HasIndex("MedicalAppointmentId");

                    b.HasIndex("UserId");

                    b.ToTable("FeedBack");
                });

            modelBuilder.Entity("HealthClinic.Domains.Medic", b =>
                {
                    b.Property<Guid>("MedicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("VARCHAR(8)");

                    b.Property<Guid>("ClinicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SpecialtyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MedicId");

                    b.HasIndex("CRM")
                        .IsUnique();

                    b.HasIndex("ClinicId");

                    b.HasIndex("SpecialtyId");

                    b.HasIndex("UserId");

                    b.ToTable("Medic");
                });

            modelBuilder.Entity("HealthClinic.Domains.MedicalAppointment", b =>
                {
                    b.Property<int>("MedicalAppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicalAppointmentId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATE");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MedicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("TIME");

                    b.HasKey("MedicalAppointmentId");

                    b.HasIndex("MedicId");

                    b.HasIndex("PatientId");

                    b.ToTable("MedicalAppointment");
                });

            modelBuilder.Entity("HealthClinic.Domains.MedicalSpecialty", b =>
                {
                    b.Property<Guid>("SpecialtyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.HasKey("SpecialtyId");

                    b.ToTable("MedicalSpecialty");
                });

            modelBuilder.Entity("HealthClinic.Domains.Patient", b =>
                {
                    b.Property<Guid>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("DATE");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("VARCHAR(11)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("CHAR(1)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PatientId");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("HealthClinic.Domains.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("BIT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("HealthClinic.Domains.FeedBack", b =>
                {
                    b.HasOne("HealthClinic.Domains.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthClinic.Domains.Medic", "Medic")
                        .WithMany()
                        .HasForeignKey("MedicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthClinic.Domains.MedicalAppointment", "MedicalAppointment")
                        .WithMany()
                        .HasForeignKey("MedicalAppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthClinic.Domains.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinic");

                    b.Navigation("Medic");

                    b.Navigation("MedicalAppointment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HealthClinic.Domains.Medic", b =>
                {
                    b.HasOne("HealthClinic.Domains.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthClinic.Domains.MedicalSpecialty", "Specialty")
                        .WithMany()
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthClinic.Domains.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinic");

                    b.Navigation("Specialty");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HealthClinic.Domains.MedicalAppointment", b =>
                {
                    b.HasOne("HealthClinic.Domains.Medic", "Medic")
                        .WithMany()
                        .HasForeignKey("MedicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthClinic.Domains.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medic");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HealthClinic.Domains.Patient", b =>
                {
                    b.HasOne("HealthClinic.Domains.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
