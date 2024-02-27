using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LWEnglishPractice.Entities
{
    public partial class ListenAndWriteContext : DbContext
    {
        public ListenAndWriteContext()
        {
        }

        public ListenAndWriteContext(DbContextOptions<ListenAndWriteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<Learner> Learner { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<Level> Level { get; set; }
        public virtual DbSet<Track> Track { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #warning directive
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=GODOFGA\\SQLEXPRESS;Initial Catalog=ListenAndWrite;Integrated Security=True");
#pragma warning restore CS1030 // #warning directive
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<History>(entity =>
            {
                entity.HasKey(e => new { e.Idhistory, e.Idlearner, e.Idlesson })
                    .HasName("PK__HISTORY__C1204A89B11CFC09");

                entity.ToTable("HISTORY");

                entity.Property(e => e.Idhistory)
                    .HasColumnName("IDHISTORY")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idlearner).HasColumnName("IDLEARNER");

                entity.Property(e => e.Idlesson).HasColumnName("IDLESSON");

                entity.Property(e => e.Finishdate)
                    .HasColumnName("FINISHDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Finishtime).HasColumnName("FINISHTIME");

                entity.Property(e => e.Score).HasColumnName("SCORE");

                entity.HasOne(d => d.IdlearnerNavigation)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.Idlearner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKHISTORY104111");

                entity.HasOne(d => d.IdlessonNavigation)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.Idlesson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKHISTORY918407");
            });

            modelBuilder.Entity<Learner>(entity =>
            {
                entity.HasKey(e => e.Idlearner)
                    .HasName("PK__LEARNER__A456CE0E77466214");

                entity.ToTable("LEARNER");

                entity.Property(e => e.Idlearner).HasColumnName("IDLEARNER");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnName("DATEOFBIRTH")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasColumnName("FULLNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Image)
                    .HasColumnName("IMAGE")
                    .HasMaxLength(255);

                entity.Property(e => e.Joindate)
                    .HasColumnName("JOINDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(255);

                entity.Property(e => e.Sex)
                    .HasColumnName("SEX")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.HasKey(e => e.Idlesson)
                    .HasName("PK__LESSON__21303567A454A674");

                entity.ToTable("LESSON");

                entity.Property(e => e.Idlesson).HasColumnName("IDLESSON");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Datecreate)
                    .HasColumnName("DATECREATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Describe)
                    .HasColumnName("DESCRIBE")
                    .HasMaxLength(4000);



                entity.Property(e => e.Idlevel).HasColumnName("IDLEVEL");

                entity.Property(e => e.Lessonanme)
                    .IsRequired()
                    .HasColumnName("LESSONANME")
                    .HasMaxLength(255);



                entity.HasOne(d => d.IdlevelNavigation)
                    .WithMany(p => p.Lesson)
                    .HasForeignKey(d => d.Idlevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKLESSON775544");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.HasKey(e => e.Idlevel)
                    .HasName("PK__LEVEL__59FBD2D6D7126C34");

                entity.ToTable("LEVEL");

                entity.Property(e => e.Idlevel).HasColumnName("IDLEVEL");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Level1).HasColumnName("LEVEL");

                entity.Property(e => e.Levelname)
                    .HasColumnName("LEVELNAME")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.HasKey(e => e.Idtrack)
                    .HasName("PK__TRACK__FDEADA54C7A2B749");

                entity.ToTable("TRACK");

                entity.Property(e => e.Idtrack).HasColumnName("IDTRACK");

                entity.Property(e => e.Duration)
                   .HasColumnName("DURATION");
               

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Describe)
                   .HasColumnName("DESCRIBE")
                   .HasMaxLength(4000);

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("SOURCE")
                    .HasMaxLength(255);

                entity.Property(e => e.Dateupload)
                     .IsRequired()
                     .HasColumnName("DATEUPLOAD")
                     .HasColumnType("datetime");

                entity.Property(e => e.Idlesson).HasColumnName("IDLESSON");

                entity.Property(e => e.Trackname)
                    .HasColumnName("TRACKNAME")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdlessonNavigation)
                    .WithMany(p => p.Track)
                    .HasForeignKey(d => d.Idlesson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTRACK502409");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
