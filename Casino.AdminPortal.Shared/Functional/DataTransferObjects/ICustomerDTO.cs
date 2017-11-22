using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.AdminPortal.Shared
{
     
    public interface ICustomerDTO : IDTO
    {
 
         string CustomerName { get; set; }
         System.DateTime DOB { get; set; }
         string Contact { get; set; }
         string EmailId { get; set; }
         byte[] IdProof { get; set; }
         decimal AccountBalance { get; set; }
         int BlockBalance { get; set; }
         int CustomerId { get; set; }
    }
    
}
