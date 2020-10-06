using FirmaTakip.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaTakip.Models
{
    public class AddCompanyModel
    {
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Bu alan zorunlu.")]

        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Bu alan zorunlu.")]


        public string CompanyCountry { get; set; }
        [Required(ErrorMessage = "Bu alan zorunlu.")]

        public string CompanyCity { get; set; }
        [Required(ErrorMessage = "Bu alan zorunlu.")]

        public string CompanyTown { get; set; }
        [Required(ErrorMessage = "Bu alan zorunlu.")]

        public string CompanyAddress { get; set; }
        [Required(ErrorMessage = "Bu alan zorunlu.")]

        public string PhoneNumber { get; set; }

        public List<CompanyCategory> CompanyCategories { get; set; }

    }
}
