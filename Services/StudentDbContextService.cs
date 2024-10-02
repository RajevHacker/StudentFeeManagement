using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Services;

public class StudentDbContextService:DbContext
{
    public StudentDbContextService(DbContextOptions<StudentDbContextService> option): base(option)
    {
    }

    public DbSet<BillHistoryDb> BillHistoryTable { get; set; }
    public DbSet<PendingFeesDb> PendingFeesTable { get; set; }
}