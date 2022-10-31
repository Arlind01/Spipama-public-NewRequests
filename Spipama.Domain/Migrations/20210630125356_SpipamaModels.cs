using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spipama.Domain.Migrations
{
    public partial class SpipamaModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    StrategyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: false),
                    ActiveYear = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BudgetTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BudgetCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BudgetCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FileRef = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ActionPlan__Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBodyHtml = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EmailTemplates__Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndicatorStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__IndicatorStatus__Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Institution__Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClearMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Object = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditedObject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Logs__Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasuresStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MeasureStatus__Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    MeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acknowledge = table.Column<bool>(type: "bit", nullable: false),
                    IsSent = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notification__Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectiveStrategics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identifier = table.Column<int>(type: "int", nullable: false),
                    ActionPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ObjectiveStrategic__Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectiveStrategic_ActionPlanId",
                        column: x => x.ActionPlanId,
                        principalTable: "ActionPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StrategySourceOfFundings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StrategySourceOfFunding__Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrategySourceOfFunding_ActionPlanId",
                        column: x => x.ActionPlanId,
                        principalTable: "ActionPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndicatorStrategics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectiveStrategicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identifier = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Base = table.Column<int>(type: "int", nullable: false),
                    InputType = table.Column<int>(type: "int", nullable: false),
                    IndicatorTemp = table.Column<int>(type: "int", nullable: false),
                    IndicatorTempAchieved = table.Column<int>(type: "int", nullable: true),
                    IndicatorFinal = table.Column<int>(type: "int", nullable: false),
                    IndicatorFinalAchieved = table.Column<int>(type: "int", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    IndicatorStatusId = table.Column<int>(type: "int", nullable: false),
                    ResponsibleInstitutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__IndicatorStrategic__Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicatorStrategic_IndicatorStatusId",
                        column: x => x.IndicatorStatusId,
                        principalTable: "IndicatorStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicatorStrategic_ObjectiveStrategicId",
                        column: x => x.ObjectiveStrategicId,
                        principalTable: "ObjectiveStrategics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicatorStrategic_ResponsibleInstitutionId",
                        column: x => x.ResponsibleInstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjectiveSpecifics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identifier = table.Column<int>(type: "int", nullable: false),
                    ObjectiveStrategicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    BudgetTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BudgetCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BudgetCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ObjectiveSpecific__Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectiveSpecific_ObjectiveStrategicId",
                        column: x => x.ObjectiveStrategicId,
                        principalTable: "ObjectiveStrategics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndicatorSpecifics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectiveSpecificId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identifier = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Base = table.Column<int>(type: "int", nullable: false),
                    InputType = table.Column<int>(type: "int", nullable: false),
                    IndicatorStatusId = table.Column<int>(type: "int", nullable: false),
                    ResponsibleInstitutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__IndicatorSpecific__Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicatorSpecific_IndicatorStatusId",
                        column: x => x.IndicatorStatusId,
                        principalTable: "IndicatorStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicatorSpecific_ObjectiveSpecificId",
                        column: x => x.ObjectiveSpecificId,
                        principalTable: "ObjectiveSpecifics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicatorSpecific_ResponsibleInstitutionId",
                        column: x => x.ResponsibleInstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identifier = table.Column<int>(type: "int", nullable: false),
                    ObjectiveSpecificId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    PeriodFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalBudgetSpent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MeasureStatusId = table.Column<int>(type: "int", nullable: true),
                    Product = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ResponsibleInstitutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Measure__Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measure_MeasureStatusId",
                        column: x => x.MeasureStatusId,
                        principalTable: "MeasuresStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Measure_ObjectiveSpecificId",
                        column: x => x.ObjectiveSpecificId,
                        principalTable: "ObjectiveSpecifics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Measure_ResponsibleInstitutionId",
                        column: x => x.ResponsibleInstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndicatorSpecificDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndicatorSpecificId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Indicator = table.Column<int>(type: "int", nullable: false),
                    IndicatorAchieved = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__IndicatorSpecificDetails__Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicatorSpecific_IndicatorSpecificId",
                        column: x => x.IndicatorSpecificId,
                        principalTable: "IndicatorSpecifics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeasureDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BudgetSpent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StrategySourceOfFundingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MeasureDetails__Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasureDetails_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeasureDetails_StrategySourceOfFundingId",
                        column: x => x.StrategySourceOfFundingId,
                        principalTable: "StrategySourceOfFundings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeasuresResponsibleInstitutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstitutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuresResponsibleInstitutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasureResponsibleInstitution_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeasureResponsibleInstitution_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportingResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    IndicatorStrategicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IndicatorSpecificId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ReportingResult__Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportingResult_IndicatorSpecificId",
                        column: x => x.IndicatorSpecificId,
                        principalTable: "IndicatorSpecifics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportingResult_IndicatorStrategicId",
                        column: x => x.IndicatorStrategicId,
                        principalTable: "IndicatorStrategics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportingResult_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportingResultDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportingResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileRef = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ReportingResultDocument__Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportingResultDocument_ReportingResultId",
                        column: x => x.ReportingResultId,
                        principalTable: "ReportingResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorSpecificDetails_IndicatorSpecificId",
                table: "IndicatorSpecificDetails",
                column: "IndicatorSpecificId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorSpecifics_IndicatorStatusId",
                table: "IndicatorSpecifics",
                column: "IndicatorStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorSpecifics_ObjectiveSpecificId",
                table: "IndicatorSpecifics",
                column: "ObjectiveSpecificId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorSpecifics_ResponsibleInstitutionId",
                table: "IndicatorSpecifics",
                column: "ResponsibleInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorStrategics_IndicatorStatusId",
                table: "IndicatorStrategics",
                column: "IndicatorStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorStrategics_ObjectiveStrategicId",
                table: "IndicatorStrategics",
                column: "ObjectiveStrategicId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorStrategics_ResponsibleInstitutionId",
                table: "IndicatorStrategics",
                column: "ResponsibleInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasureDetails_MeasureId",
                table: "MeasureDetails",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasureDetails_StrategySourceOfFundingId",
                table: "MeasureDetails",
                column: "StrategySourceOfFundingId");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_MeasureStatusId",
                table: "Measures",
                column: "MeasureStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_ObjectiveSpecificId",
                table: "Measures",
                column: "ObjectiveSpecificId");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_ResponsibleInstitutionId",
                table: "Measures",
                column: "ResponsibleInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasuresResponsibleInstitutions_InstitutionId",
                table: "MeasuresResponsibleInstitutions",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasuresResponsibleInstitutions_MeasureId",
                table: "MeasuresResponsibleInstitutions",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectiveSpecifics_ObjectiveStrategicId",
                table: "ObjectiveSpecifics",
                column: "ObjectiveStrategicId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectiveStrategics_ActionPlanId",
                table: "ObjectiveStrategics",
                column: "ActionPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportingResultDocuments_ReportingResultId",
                table: "ReportingResultDocuments",
                column: "ReportingResultId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportingResults_IndicatorSpecificId",
                table: "ReportingResults",
                column: "IndicatorSpecificId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportingResults_IndicatorStrategicId",
                table: "ReportingResults",
                column: "IndicatorStrategicId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportingResults_MeasureId",
                table: "ReportingResults",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_StrategySourceOfFundings_ActionPlanId",
                table: "StrategySourceOfFundings",
                column: "ActionPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DropTable(
                name: "IndicatorSpecificDetails");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "MeasureDetails");

            migrationBuilder.DropTable(
                name: "MeasuresResponsibleInstitutions");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ReportingResultDocuments");

            migrationBuilder.DropTable(
                name: "StrategySourceOfFundings");

            migrationBuilder.DropTable(
                name: "ReportingResults");

            migrationBuilder.DropTable(
                name: "IndicatorSpecifics");

            migrationBuilder.DropTable(
                name: "IndicatorStrategics");

            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropTable(
                name: "IndicatorStatuses");

            migrationBuilder.DropTable(
                name: "MeasuresStatus");

            migrationBuilder.DropTable(
                name: "ObjectiveSpecifics");

            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropTable(
                name: "ObjectiveStrategics");

            migrationBuilder.DropTable(
                name: "ActionPlans");
        }
    }
}
