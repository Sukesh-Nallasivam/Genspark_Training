using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClinicDALLibrary.Models
{
    public partial class DoctorClinicDBContext : DbContext
    {
        public DoctorClinicDBContext()
        {
        }

        public DoctorClinicDBContext(DbContextOptions<DoctorClinicDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<MedicalHistory> MedicalHistories { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<PreviousConsultation> PreviousConsultations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=DoctorClinicDB;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");

                entity.Property(e => e.AppointmentDateTime).HasColumnType("datetime");

                entity.Property(e => e.AppointmentStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Purpose)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_DoctorId");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_PatientId");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.ConsultingHours)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("consulting_hours");

                entity.Property(e => e.Contact)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("contact");

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("doctor_name");

                entity.Property(e => e.Speciality)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("speciality");
            });

            modelBuilder.Entity<MedicalHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MedicalHistory");

                entity.Property(e => e.MedicalCondition)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Patient)
                    .WithMany()
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_MedicalHistoryPatientId");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PreviousConsultation>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Consultant)
                    .WithMany()
                    .HasForeignKey(d => d.ConsultantId)
                    .HasConstraintName("FK_PreviousConsultationsDoctorId");

                entity.HasOne(d => d.Patient)
                    .WithMany()
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_PreviousConsultationsPatientId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
