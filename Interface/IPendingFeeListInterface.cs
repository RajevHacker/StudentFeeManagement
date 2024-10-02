using StudentManagement.Models;

namespace StudentManagement.Interface;

public interface IPendingFeeListInterface
{
    public List<GetPendingFeeDetail> GetPendingFees(int standard);
}