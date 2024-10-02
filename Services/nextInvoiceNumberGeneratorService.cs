using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using StudentManagement.Interface;

namespace StudentManagement.Services
{
    public class nextInvoiceNumberGeneratorService : INextInvoiceNumberGenerator
    {
        private const string InvoiceNumberKey = "name";
        private readonly IDistributedCache _cache;
        public nextInvoiceNumberGeneratorService(IDistributedCache redis)
        {   
            _cache = redis;
        }
        //public async Task<string> GetNextInvoiceNumber()
        public async Task<string> GetNextInvoiceNumber()
        {
            // await _cache.SetStringAsync("Bill", "1");

            var cacheCounter = await _cache.GetStringAsync("Bill");
            int newVal = Int32.Parse(cacheCounter);
            newVal=newVal+1;
            string invoiceNumber = "2024-25-B.No-"+Int32.Parse(cacheCounter).ToString();
            await _cache.SetStringAsync("Bill", newVal.ToString());
            return invoiceNumber;
        }
    }
}