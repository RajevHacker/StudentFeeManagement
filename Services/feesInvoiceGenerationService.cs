using StudentManagement.Interface;
using StudentManagement.Models;

namespace StudentManagement.Services;

public class feesInvoiceGenerationService: IFeesInvoiceGeneration
{
    private readonly StudentDbContextService _studentDatabase;
    public feesInvoiceGenerationService(StudentDbContextService studentDatabase)
    {
        _studentDatabase = studentDatabase;
    }

    public string feesInvoiceGeneration(string regNo, string studName, string desc, double feePaying,string invNo)
    {
        BillHistoryDb invoiceGeneration = new BillHistoryDb()
        {
            InvoiceNo = invNo,
            //InvoiceNo = _INextInvNumber.GetNextInvoiceNumber().Result,
            InvoiceDate = DateTime.Now.ToString("dd-MMM-yyyy"),
            RollNo = regNo,
            StudentName = studName,
            Description =  desc,
            AmountPaid = feePaying
        };
        _studentDatabase.BillHistoryTable.Add(invoiceGeneration);
        _studentDatabase.SaveChanges();
        
        
        return "pendingFee"; 
    }      
}