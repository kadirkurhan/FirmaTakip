using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaTakip.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CompanyCategory> CompanyCategories { get; set; }

    }
}
