using StudentManagement.Models;

namespace StudentManagement.Interface;

public interface IFeesInvoice
{
    public FeesInvoice ActualFeeInvoice(string regNo, string studName, string desc, double feePaying,string email);
}