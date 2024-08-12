using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Payslip.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalarySlips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    EMPID = table.Column<int>(type: "integer", nullable: false),
                    Designation = table.Column<string>(type: "text", nullable: true),
                    DateOfJoining = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UAN = table.Column<long>(type: "bigint", nullable: false),
                    GrossSalary = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalCalendarDays = table.Column<int>(type: "integer", nullable: false),
                    LOPDays = table.Column<int>(type: "integer", nullable: false),
                    PaidDays = table.Column<int>(type: "integer", nullable: false),
                    SalaryCreditMode = table.Column<string>(type: "text", nullable: true),
                    Bank = table.Column<string>(type: "text", nullable: true),
                    BankAccountNo = table.Column<long>(type: "bigint", nullable: false),
                    BasicDA = table.Column<decimal>(type: "numeric", nullable: false),
                    HRA = table.Column<decimal>(type: "numeric", nullable: false),
                    ConveyanceAllowance = table.Column<decimal>(type: "numeric", nullable: false),
                    OverTimeEarningsAllowance = table.Column<decimal>(type: "numeric", nullable: false),
                    ExecutiveAllowance = table.Column<decimal>(type: "numeric", nullable: false),
                    MedicalAllowance = table.Column<decimal>(type: "numeric", nullable: false),
                    OtherAllowance = table.Column<decimal>(type: "numeric", nullable: false),
                    OverTimeEarnings = table.Column<decimal>(type: "numeric", nullable: false),
                    ArrearsIfAny = table.Column<decimal>(type: "numeric", nullable: false),
                    OtherEarnings = table.Column<decimal>(type: "numeric", nullable: false),
                    GrossPay = table.Column<decimal>(type: "numeric", nullable: false),
                    PFEmployeeContribution = table.Column<decimal>(type: "numeric", nullable: false),
                    ESIDeductions = table.Column<decimal>(type: "numeric", nullable: false),
                    LoanDeduction = table.Column<decimal>(type: "numeric", nullable: false),
                    ProfessionTax = table.Column<decimal>(type: "numeric", nullable: false),
                    TDS = table.Column<decimal>(type: "numeric", nullable: false),
                    OtherDeductions = table.Column<decimal>(type: "numeric", nullable: false),
                    SalaryAdvance = table.Column<decimal>(type: "numeric", nullable: false),
                    GrossDeductions = table.Column<decimal>(type: "numeric", nullable: false),
                    NetPay = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalarySlips", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalarySlips");
        }
    }
}
