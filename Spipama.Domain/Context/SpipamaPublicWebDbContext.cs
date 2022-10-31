using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Spipama.Domain.IdentityModels;
using Spipama.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Domain.Context
{
    public class SpipamaPublicWebDbContext : IdentityDbContext<ApplicationUser>
    {
        public SpipamaPublicWebDbContext(DbContextOptions<SpipamaPublicWebDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<ObjectiveSpecific> ObjectiveSpecifics { get; set; }
        public virtual DbSet<IndicatorStrategic> IndicatorStrategics { get; set; }
        public virtual DbSet<ReportingResult> ReportingResults { get; set; }
        public virtual DbSet<ObjectiveStrategic> ObjectiveStrategics { get; set; }
        public virtual DbSet<ActionPlan> ActionPlans { get; set; }
        public virtual DbSet<IndicatorSpecific> IndicatorSpecifics { get; set; }
        public virtual DbSet<IndicatorSpecificDetails> IndicatorSpecificDetails { get; set; }
        public virtual DbSet<ReportingResultDocument> ReportingResultDocuments { get; set; }
        public virtual DbSet<StrategySourceOfFunding> StrategySourceOfFundings { get; set; }
        public virtual DbSet<Measure> Measures { get; set; }
        public virtual DbSet<MeasureDetails> MeasureDetails { get; set; }
        public virtual DbSet<MeasureResponsibleInstitution> MeasuresResponsibleInstitutions { get; set; }
        public virtual DbSet<MeasureStatus> MeasuresStatus { get; set; }
        public virtual DbSet<IndicatorStatus> IndicatorStatuses { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<EmailTemplates> EmailTemplates { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<_PublicCodes> _PublicCodes { get; set; }
        public virtual DbSet<FileManagement> FileManagements { get; set; }
        public virtual DbSet<FileCategory> FileCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                    .AddJsonFile(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/../Spipama.API/appsettings.json").Build();

                var connectionString = configuration.GetConnectionString("SpipamaPublicWebDBConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IndicatorStrategic>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__IndicatorStrategic__Id");

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(1000);

                entity.Property(e => e.Result)
                .IsRequired()
                .HasMaxLength(700);
            });

            builder.Entity<IndicatorStrategic>()
            .HasOne(p => p.ObjectiveStrategic)
            .WithMany()
            .HasForeignKey(p => p.ObjectiveStrategicId)
            .HasConstraintName("FK_IndicatorStrategic_ObjectiveStrategicId");


            builder.Entity<IndicatorStrategic>()
            .HasOne(p => p.IndicatorStatus)
            .WithMany()
            .HasForeignKey(p => p.IndicatorStatusId)
            .HasConstraintName("FK_IndicatorStrategic_IndicatorStatusId");

            builder.Entity<IndicatorStrategic>()
             .HasOne(p => p.ResponsibleInstitution)
             .WithMany()
             .HasForeignKey(p => p.ResponsibleInstitutionId)
             .HasConstraintName("FK_IndicatorStrategic_ResponsibleInstitutionId");


            builder.Entity<ReportingResult>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__ReportingResult__Id");

                entity.Property(e => e.Reason)
                .IsRequired()
                .HasMaxLength(4000);
            });

            builder.Entity<ReportingResult>()
           .HasOne(p => p.IndicatorStrategic)
           .WithMany()
           .HasForeignKey(p => p.IndicatorStrategicId)
           .HasConstraintName("FK_ReportingResult_IndicatorStrategicId");


            builder.Entity<ReportingResult>()
           .HasOne(p => p.IndicatorSpecific)
           .WithMany()
           .HasForeignKey(p => p.IndicatorSpecificId)
           .HasConstraintName("FK_ReportingResult_IndicatorSpecificId");


            builder.Entity<ReportingResult>()
           .HasOne(p => p.Measure)
           .WithMany()
           .HasForeignKey(p => p.MeasureId)
           .HasConstraintName("FK_ReportingResult_MeasureId");


            builder.Entity<ObjectiveStrategic>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__ObjectiveStrategic__Id");

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(4000);
            });

            builder.Entity<ObjectiveStrategic>()
            .HasOne(p => p.ActionPlan)
            .WithMany()
            .HasForeignKey(p => p.ActionPlanId)
            .HasConstraintName("FK_ObjectiveStrategic_ActionPlanId");


            builder.Entity<ActionPlan>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__ActionPlan__Id");

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(4000);

                entity.Property(e => e.StrategyName)
                .IsRequired()
                .HasMaxLength(200);

                entity.Property(e => e.BudgetTotal)
                .HasColumnType("decimal(18,2)");

                entity.Property(e => e.BudgetCapital)
                .HasColumnType("decimal(18,2)");

                entity.Property(e => e.BudgetCost)
                .HasColumnType("decimal(18,2)");

                entity.Property(e => e.FileRef)
                .HasMaxLength(2000);

                entity.Property(e => e.FileName)
                .HasMaxLength(100);
            });

            builder.Entity<IndicatorSpecific>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__IndicatorSpecific__Id");

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(1000);

                entity.Property(e => e.Result)
                .IsRequired()
                .HasMaxLength(700);

            });

            builder.Entity<IndicatorSpecific>()
            .HasOne(p => p.ObjectiveSpecific)
            .WithMany()
            .HasForeignKey(p => p.ObjectiveSpecificId)
            .HasConstraintName("FK_IndicatorSpecific_ObjectiveSpecificId");

            builder.Entity<IndicatorSpecific>()
            .HasOne(p => p.IndicatorStatus)
            .WithMany()
            .HasForeignKey(p => p.IndicatorStatusId)
            .HasConstraintName("FK_IndicatorSpecific_IndicatorStatusId");

            builder.Entity<IndicatorSpecific>()
            .HasOne(p => p.ResponsibleInstitution)
            .WithMany()
            .HasForeignKey(p => p.ResponsibleInstitutionId)
            .HasConstraintName("FK_IndicatorSpecific_ResponsibleInstitutionId");


            builder.Entity<IndicatorSpecificDetails>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__IndicatorSpecificDetails__Id");

            });

            builder.Entity<IndicatorSpecificDetails>()
            .HasOne(p => p.IndicatorSpecific)
            .WithMany()
            .HasForeignKey(p => p.IndicatorSpecificId)
            .HasConstraintName("FK_IndicatorSpecific_IndicatorSpecificId");


            builder.Entity<ReportingResultDocument>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__ReportingResultDocument__Id");

                entity.Property(e => e.FileRef)
                .IsRequired()
                .HasMaxLength(2000);

                entity.Property(e => e.FileName)
                .IsRequired()
                .HasMaxLength(2000);
            });

            builder.Entity<ReportingResultDocument>()
            .HasOne(p => p.ReportingResult)
            .WithMany()
            .HasForeignKey(p => p.ReportingResultId)
            .HasConstraintName("FK_ReportingResultDocument_ReportingResultId");

            builder.Entity<StrategySourceOfFunding>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__StrategySourceOfFunding__Id");

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            });

            builder.Entity<StrategySourceOfFunding>()
           .HasOne(p => p.ActionPlan)
           .WithMany()
           .HasForeignKey(p => p.ActionPlanId)
           .HasConstraintName("FK_StrategySourceOfFunding_ActionPlanId");


            builder.Entity<Institution>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("PK__Institution__Id");

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
            });


            builder.Entity<ObjectiveSpecific>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("PK__ObjectiveSpecific__Id");

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(4000);

                entity.Property(e => e.BudgetTotal)
                .HasColumnType("decimal(18,2)");

                entity.Property(e => e.BudgetCapital)
                .HasColumnType("decimal(18,2)");

                entity.Property(e => e.BudgetCost)
                .HasColumnType("decimal(18,2)");

            });

            builder.Entity<ObjectiveSpecific>()
          .HasOne(p => p.ObjectiveStrategic)
          .WithMany()
          .HasForeignKey(p => p.ObjectiveStrategicId)
          .HasConstraintName("FK_ObjectiveSpecific_ObjectiveStrategicId");


            builder.Entity<Measure>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("PK__Measure__Id");

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(2000);

                entity.Property(e => e.TotalBudget)
                .HasColumnType("decimal(18,2)");

                entity.Property(e => e.TotalBudgetSpent)
               .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Product)
               .HasMaxLength(1000);

                entity.Property(e => e.Reference)
               .HasMaxLength(500);

            });


            builder.Entity<Measure>()
           .HasOne(p => p.ObjectiveSpecific)
           .WithMany()
           .HasForeignKey(p => p.ObjectiveSpecificId)
           .HasConstraintName("FK_Measure_ObjectiveSpecificId");

            builder.Entity<Measure>()
           .HasOne(p => p.MeasureStatus)
           .WithMany()
           .HasForeignKey(p => p.MeasureStatusId)
           .HasConstraintName("FK_Measure_MeasureStatusId");

            builder.Entity<Measure>()
            .HasOne(p => p.ResponsibleInstitution)
            .WithMany()
            .HasForeignKey(p => p.ResponsibleInstitutionId)
            .HasConstraintName("FK_Measure_ResponsibleInstitutionId")
            .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<MeasureDetails>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__MeasureDetails__Id");

                entity.Property(e => e.Budget)
                .HasColumnType("decimal(18,2)");

                entity.Property(e => e.BudgetSpent)
               .HasColumnType("decimal(18,2)");
            });

            builder.Entity<MeasureDetails>()
            .HasOne(p => p.Measure)
            .WithMany()
            .HasForeignKey(p => p.MeasureId)
            .HasConstraintName("FK_MeasureDetails_MeasureId");

            builder.Entity<MeasureDetails>()
            .HasOne(p => p.StrategySourceOfFunding)
            .WithMany()
            .HasForeignKey(p => p.StrategySourceOfFundingId)
            .HasConstraintName("FK_MeasureDetails_StrategySourceOfFundingId");

            builder.Entity<MeasureResponsibleInstitution>()
            .HasOne(p => p.Institution)
            .WithMany()
            .HasForeignKey(p => p.InstitutionId)
            .HasConstraintName("FK_MeasureResponsibleInstitution_InstitutionId");

            builder.Entity<MeasureResponsibleInstitution>()
            .HasOne(p => p.Measure)
            .WithMany()
            .HasForeignKey(p => p.MeasureId)
            .HasConstraintName("FK_MeasureResponsibleInstitution_MeasureId");

            builder.Entity<MeasureStatus>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("PK__MeasureStatus__Id");


            });


            builder.Entity<IndicatorStatus>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__IndicatorStatus__Id");

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            });

            builder.Entity<IndicatorStrategic>()
        .HasOne(p => p.IndicatorStatus)
        .WithMany()
        .HasForeignKey(p => p.IndicatorStatusId)
        .HasConstraintName("FK_IndicatorStrategic_IndicatorStatusId");

            builder.Entity<IndicatorSpecific>()
       .HasOne(p => p.IndicatorStatus)
       .WithMany()
       .HasForeignKey(p => p.IndicatorStatusId)
       .HasConstraintName("FK_IndicatorSpecific_IndicatorStatusId");

            builder.Entity<EmailTemplates>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__EmailTemplates__Id");
            });


            builder.Entity<Logs>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Logs__Id");
            });


            builder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Notification__Id");
            });

            builder.Entity<News>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__News__Id");

            });

            builder.Entity<FileManagement>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__FileManagement__Id");

            });

            builder.Entity<FileCategory>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__FileCategory__Id");

            });

            base.OnModelCreating(builder);
        }

    }
}
