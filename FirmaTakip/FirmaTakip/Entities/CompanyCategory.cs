using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaTakip.Entities
{
    public class CompanyCategory
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int CategoryId { get; set; }
        public Category CategoryName { get; set; }
    }
}
