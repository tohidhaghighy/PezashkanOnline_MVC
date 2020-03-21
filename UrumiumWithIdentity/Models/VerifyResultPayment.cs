using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrumiumWithIdentity.Models
{
    public class VerifyResultPayment
    {
        public bool success { get; set; }
        public String TransActionID { get; set; }
        public String Amount { get; set; }
        public string factorNumber { get; set; }
        public string description { get; set; }
        public string mobile { get; set; }
        public String SuccessMessage { get; set; }
        public bool error { get; set; }
        public String ErrorMessage { get; set; }
    }
}