using Casino.AdminPortal.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Casino.AdminPortal.Web.Models
{
    public class UserModel : DTOBase ,ICustomerDTO
    {

        
        public string CustomerName { get; set; }

        public System.DateTime DOB { get; set; }

        public string Contact { get; set; }

        public string EmailId { get; set; }

        public byte[] IdProof { get; set; }

        public decimal AccountBalance { get; set; }

        public int BlockBalance { get; set; }

        public int CustomerId { get; set; }

        public decimal RechargeAmount { get; set; }
    }
}