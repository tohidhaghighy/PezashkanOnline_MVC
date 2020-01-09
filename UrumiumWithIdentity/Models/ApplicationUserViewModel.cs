using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrumiumWithIdentity.Models
{
    public class ApplicationUserViewModel: IdentityUser
    {

        public int RollId { get; set; }
        public string Image { get; set; }
    }
}