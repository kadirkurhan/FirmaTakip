using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaTakip.Entities
{
    //[Dapper.Contrib.Extensions.Table("Company")]
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public string CompanyCountry { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyTown { get; set; }

        public string CompanyAddress { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime LastControlDate { get; set; }
        public bool WillControl { get; set; }
        public bool IsOffer {get;set;}
        public int PriceOffer { get; set; }
        public bool ActiveOrNot { get; set; }
        public int DebtAmount { get; set; }
        public List<CompanyCategory> CompanyCategories { get; set; }
    }
}
