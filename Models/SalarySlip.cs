namespace Payslip.Models
{
    public class SalarySlip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EMPID { get; set; }
        public string Designation { get; set; }
        public DateTime DateOfJoining { get; set; }
        public long UAN { get; set; }
        public decimal GrossSalary { get; set; }
        public int TotalCalendarDays { get; set; }
        public int LOPDays { get; set; }
        public int PaidDays { get; set; }
        public string SalaryCreditMode { get; set; }
        public string Bank { get; set; }
        public long BankAccountNo { get; set; }

        // Earnings
        public decimal BasicDA { get; set; }
        public decimal HRA { get; set; }
        public decimal ConveyanceAllowance { get; set; }

        public decimal OverTimeEarningsAllowance { get; set; }
        public decimal ExecutiveAllowance { get; set; }
        public decimal MedicalAllowance { get; set; }
        public decimal OtherAllowance { get; set; }

        public decimal OverTimeEarnings { get; set; }
        public decimal ArrearsIfAny { get; set; }
        public decimal OtherEarnings { get; set; }
        public decimal GrossPay { get; set; }

        // Deductions
        public decimal PFEmployeeContribution { get; set; }
        public decimal ESIDeductions { get; set; }
        public decimal LoanDeduction { get; set; }
        public decimal ProfessionTax { get; set; }
        public decimal TDS { get; set; }
        public decimal OtherDeductions { get; set; }
        public decimal SalaryAdvance { get; set; }
        public decimal GrossDeductions { get; set; }

        public decimal NetPay { get; set; }
    }
}
