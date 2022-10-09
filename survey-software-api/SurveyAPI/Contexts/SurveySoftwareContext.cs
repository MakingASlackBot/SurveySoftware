using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SurveyAPI.Models;

namespace SurveyAPI.Contexts
{
    public partial class SurveySoftwareContext : DbContext
    {
        public SurveySoftwareContext()
        {
        }

        public SurveySoftwareContext(DbContextOptions<SurveySoftwareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Survey> Surveys { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=survey-software;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Survey");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Jsoncontents).HasColumnName("JSONContents");

                entity.Property(e => e.SurveyCode).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
