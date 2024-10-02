using StudentManagement.Models;

namespace StudentManagement.Interface;

public interface IFeesInvoiceGeneration
{
    public string feesInvoiceGeneration(string StudName, string RegNo, string desc, double feePaying,string invNo);
}