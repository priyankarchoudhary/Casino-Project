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

        [Required(ErrorMessage = "Name is Required")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "DOB is Required")]
        public System.DateTime DOB { get; set; }

        [Required(ErrorMessage = "Phone Number is needed.")]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]
        public string Contact { get; set; }


        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        public string EmailId { get; set; }

        
        public byte[] IdProof { get; set; }

        public decimal AccountBalance { get; set; }

        public int BlockBalance { get; set; }

        public int CustomerId { get; set; }

        public decimal RechargeAmount { get; set; }
    }
}