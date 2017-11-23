using Casino.AdminPortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.AdminPortal.DTOModel
{
    //[ViewModelMapping("Casino.AdminPortal.WebApi.Models.UserModelAPI", MappingType.TotalExplicit)]
    [ViewModelMapping("Casino.AdminPortal.Web.Models.UserModel", MappingType.TotalExplicit)]
    [EntityMapping("Casino.AdminPortal.EntityDataModel.EntityModel.Player", MappingType.TotalExplicit)]
    public class CustomerDTO : DTOBase, ICustomerDTO
    {
        public CustomerDTO()
            : base(DTOType.CustomerDTO)
        {

        }

        
        [ViewModelPropertyMapping(MappingDirectionType.Both, "CustomerName")]
        [EntityPropertyMapping(MappingDirectionType.Both, "CustomerName")]
        public string CustomerName { get; set; }
         
        [ViewModelPropertyMapping(MappingDirectionType.Both, "DOB")]
        [EntityPropertyMapping(MappingDirectionType.Both, "DOB")]
        public System.DateTime DOB { get; set; }
         
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Contact")]
        [EntityPropertyMapping(MappingDirectionType.Both, "Contact")]
        public string Contact { get; set; }
        
                [ViewModelPropertyMapping(MappingDirectionType.Both, "EmailId")]
        [EntityPropertyMapping(MappingDirectionType.Both, "EmailId")]
        public string EmailId { get; set; }
         
       [ViewModelPropertyMapping(MappingDirectionType.Both, "IdProof")]
        [EntityPropertyMapping(MappingDirectionType.Both, "IdProof")]
        public byte[] IdProof { get; set; }
        
        [ViewModelPropertyMapping(MappingDirectionType.Both, "AccountBalance")]
        [EntityPropertyMapping(MappingDirectionType.Both, "AccountBalance")]
        public decimal AccountBalance { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "BlockBalance")]
        [EntityPropertyMapping(MappingDirectionType.Both, "BlockBalance")]
        public int BlockBalance { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "CustomerId")]
        [EntityPropertyMapping(MappingDirectionType.Both, "CustomerId")]
        public int CustomerId { get; set; }
    }
}
