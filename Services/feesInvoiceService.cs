using StudentManagement.Interface;
using StudentManagement.Models;

namespace StudentManagement.Services;

public class feesInvoiceService:IFeesInvoice
{
    private readonly StudentDbContextService _studentDatabase;
    private readonly INextInvoiceNumberGenerator _INextInvNumber;
    private readonly IFeesInvoiceGeneration _IfeeInvoiceGeneration;
   public feesInvoiceService(StudentDbContextService studentDatabase,INextInvoiceNumberGenerator invoiceNum,IFeesInvoiceGeneration invoiceGeneration)
   {
        _studentDatabase = studentDatabase;
        _INextInvNumber = invoiceNum;
        _IfeeInvoiceGeneration = invoiceGeneration;

   }
   public FeesInvoice ActualFeeInvoice(string regNo, string studName, string desc, double feePaying, string email)
   {
        var ActualFee = _studentDatabase.PendingFeesTable
            .Where(s => s.RegNo == regNo && s.studentName == studName)
            .Select(s => s.ActualFee)
            .FirstOrDefault();
        var feePaid = _studentDatabase.PendingFeesTable
            .Where(s => s.RegNo == regNo && s.studentName == studName)
            .Select(s => s.PaidFee)
            .FirstOrDefault();
        var balanceFee = _studentDatabase.PendingFeesTable
            .Where(s => s.RegNo == regNo && s.studentName == studName)
            .Select(s => s.BalanceFee)
            .FirstOrDefault();
        System.Console.WriteLine("======" + ActualFee+"====" + feePaid+"===" + balanceFee);
        FeesInvoice fInvoice = new FeesInvoice();
        fInvoice.InvoiceNumber = _INextInvNumber.GetNextInvoiceNumber().Result;
        fInvoice.InvoiceDate = DateTime.Now.ToString("dd-MMM-yyyy");
        fInvoice.emailId = email;
        fInvoice.StudentName = studName;
        fInvoice.RollNo = regNo;
        fInvoice.Description = desc;
        if (feePaying > balanceFee)
        {
            fInvoice.BalanceChange = feePaying - balanceFee;
            feePaying = balanceFee;
            balanceFee = 0;
            feePaid = feePaid + feePaying;
        }
        else
        {
            feePaid = feePaid + feePaying;
            balanceFee = ActualFee - feePaid;
        } 
        fInvoice.FeePaid = feePaying;
        fInvoice.TotalFeePaid = feePaid;
        fInvoice.PendingFeeAmount = balanceFee;
        _IfeeInvoiceGeneration.feesInvoiceGeneration(regNo,studName,desc,feePaying,fInvoice.InvoiceNumber);
        var stud = _studentDatabase.PendingFeesTable.Where(e => e.studentName == studName && e.RegNo == regNo).ToList();
        foreach (var temp in stud)
        {
            temp.BalanceFee = fInvoice.PendingFeeAmount;
            temp.PaidFee = fInvoice.TotalFeePaid;
        }
        _studentDatabase.SaveChanges();
    return fInvoice;
   }
}