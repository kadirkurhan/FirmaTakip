using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaTakip.Entities
{
    public class Bank
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan zorunlu.")]

        public string BankName { get; set; }
        [Required(ErrorMessage = "Bu alan zorunlu.")]
        public string CardNo { get; set; }

        public string Iban { get; set; }
        public string Password { get; set; }
        public string SKT { get; set; }
        public string CVVB { get; set; }
        public string CVVK { get; set; }
    }
}
