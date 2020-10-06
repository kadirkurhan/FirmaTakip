﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaTakip.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre Boş Geçilemez!")]

        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
