using System.ComponentModel.DataAnnotations;
namespace StudentManagement.Models;

public class PendingFeesDb
{
    [Key]
    public int SeqNo { get; set; }
    public string RegNo {set; get; }    
    public int standard { get; set; }
    public string studentName { get; set; }
    public double ActualFee { get; set; }
    public double PaidFee { get; set; }
    public double BalanceFee { get; set; }
}