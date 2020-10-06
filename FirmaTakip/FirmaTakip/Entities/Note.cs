﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaTakip.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        
        public DateTime Date { get; set; }

    }
}
