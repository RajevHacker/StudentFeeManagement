using StudentManagement.Interface;
using StudentManagement.Models;

namespace StudentManagement.Services;

public class pendingFeeListService:IPendingFeeListInterface
{
    private readonly StudentDbContextService _studentDatabase;
    public pendingFeeListService(StudentDbContextService studentDatabase)
    {
        _studentDatabase = studentDatabase;
    }
    /*public List<GetPendingFeeDetail> GetPendingFees(int standard)
    {
        _studentDatabase.PendingFeesTable.ToList();
    }*/
    public List<GetPendingFeeDetail> GetPendingFees(int stand)
    {
        List<GetPendingFeeDetail> pendingList = _studentDatabase.PendingFeesTable.Where
            (stud => stud.standard.Equals(stand)).Select(item => new GetPendingFeeDetail
        {
            RegNo = item.RegNo,
            Name = item.studentName,
            PendingFee = item.BalanceFee,
            Standard = item.standard
            
        }).ToList();
        return pendingList;
    }
}