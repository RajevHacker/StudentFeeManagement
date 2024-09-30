using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Interface;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    [ApiController]
    public class StudentManagementController : ControllerBase
    {
        private readonly INextInvoiceNumberGenerator _invoiceNumberGenerator;
        private readonly IPendingFeeListInterface _IFeePendingList;
        private readonly IFeesInvoiceGeneration _IfeeInvoiceGeneration;
        private readonly IFeesInvoice _IfeeInv;
        public StudentManagementController(INextInvoiceNumberGenerator invoiceNumGenerator, 
                        IPendingFeeListInterface pendingFee, IFeesInvoiceGeneration newInvGeneration,IFeesInvoice feeInvoice)
        {
            _invoiceNumberGenerator = invoiceNumGenerator;
            _IFeePendingList = pendingFee;
            _IfeeInvoiceGeneration = newInvGeneration;
            _IfeeInv = feeInvoice;
        }
        [HttpGet()]
        [Route("Admin/PendingFee")]
        public List<GetPendingFeeDetail> getPendingFeeDetails([FromHeader] int standard)
        {
            Console.WriteLine(standard+"============");
            return _IFeePendingList.GetPendingFees(standard);
            //return _invoiceNumberGenerator.GetNextInvoiceNumber();
        }

        [HttpPost()]
        [Route("Admin/FeeGeneration")]
        public FeesInvoice generateInvoice([FromHeader] string RollNo, [FromHeader] string StudentName, 
                                                [FromHeader] string Description, [FromHeader] double AmountPaid, [FromHeader] string email)
        {
            return _IfeeInv.ActualFeeInvoice(RollNo,StudentName,Description,AmountPaid,email);
                
            // return "a";
        }
        
    }
}