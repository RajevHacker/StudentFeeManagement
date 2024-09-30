using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class BillHistoryDb
    {
        [Key]
        public int SeqNo { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string RollNo { get; set; }
        public string StudentName { get; set; }
        public string Description { get; set; }
        public double AmountPaid { get; set; }
    }
}