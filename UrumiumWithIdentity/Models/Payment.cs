using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrumiumWithIdentity.Models
{
    public class Payment
    {
        public int Stauts { get; set; }
        public string token { get; set; }
        public string Phone { get; set; }
        public string Amount { get; set; }
        public string Name { get; set; }
        public string Peigiri { get; set; }
    }
}