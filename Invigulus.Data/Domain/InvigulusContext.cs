using Microsoft.EntityFrameworkCore;

namespace Invigulus.Data.Domain
{
    public partial class InvigulusContext : DbContext
    {
        public InvigulusContext()
        {
        }

        public InvigulusContext(DbContextOptions<InvigulusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<Examinee> Examinee { get; set; }
        public virtual DbSet<Institution> Institution { get; set; }
        public virtual DbSet<Proctor> Proctor { get; set; }
        public virtual DbSet<UserSession> UserSession { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=Invigulus;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>(entity =>
            {
                entity.Property(e => e.ExamId).HasColumnName("ExamID");

                entity.Property(e => e.ExamDuration)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExamName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.Exam)
                    .HasForeignKey(d => d.InstitutionId)
                    .HasConstraintName("FK_InstitutionID");
            });

            modelBuilder.Entity<Examinee>(entity =>
            {
                entity.HasIndex(e => e.ExamineeEmail)
                    .HasName("UQ__Examinee__97ECA951CFF6EF18")
                    .IsUnique();

                entity.Property(e => e.ExamineeId)
                    .HasColumnName("ExamineeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExamineeEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExamineeFirstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExamineeLastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.HasIndex(e => e.InstitutionEmail)
                    .HasName("UQ__Institut__4F46D4B07CA04408")
                    .IsUnique();

                entity.HasIndex(e => e.InstitutionPhone)
                    .HasName("UQ__Institut__0BED9D8219ABD78E")
                    .IsUnique();

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.InstitutionEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstitutionName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstitutionPhone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstitutionPostal)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.InstitutionProvince)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.InstitutionStreetAddress)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Proctor>(entity =>
            {
                entity.HasIndex(e => e.ProctorEmail)
                    .HasName("UQ__Proctor__766A8DC01ED8D899")
                    .IsUnique();

                entity.Property(e => e.ProctorId).HasColumnName("ProctorID");

                entity.Property(e => e.ProctorEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProctorFirstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProctorLastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserSession>(entity =>
            {
                entity.HasKey(e => e.SessionId)
                    .HasName("PK_SessionID");

                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.Property(e => e.DateTime)
                    .HasColumnName("Date_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExamId).HasColumnName("ExamID");

                entity.Property(e => e.ExamineeId).HasColumnName("ExamineeID");

                entity.Property(e => e.ProctorId).HasColumnName("ProctorID");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.UserSession)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK_ExamID");

                entity.HasOne(d => d.Examinee)
                    .WithMany(p => p.UserSession)
                    .HasForeignKey(d => d.ExamineeId)
                    .HasConstraintName("FK_ExamineeID");

                entity.HasOne(d => d.Proctor)
                    .WithMany(p => p.UserSession)
                    .HasForeignKey(d => d.ProctorId)
                    .HasConstraintName("FK_ProctorID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
