using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Casino.AdminPortal.WebApi.Models
{
    public class UserApiModel 
    {

        
        public string CustomerName { get; set; }
        public string EmailId { get; set; }
        public decimal AccountBalance { get; set; }
        public int BlockBalance { get; set; }

        
    }
}