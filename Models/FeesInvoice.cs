namespace StudentManagement.Models;

public class FeesInvoice
{
    public string InvoiceNumber { get; set; }
    public string InvoiceDate { get; set; }
    public string emailId { get; set; }
    public string RollNo { get; set; }
    public string StudentName { get; set; }
    public string Description { get; set; }
    public double FeePaid { get; set; }
    public double BalanceChange { get; set; }
    public double TotalFeePaid { get; set; }
    public double PendingFeeAmount { get; set; }
}