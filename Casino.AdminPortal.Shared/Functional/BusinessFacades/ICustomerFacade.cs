using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.AdminPortal.Shared
{
    public interface ICustomerFacade : IFacade
    {
        OperationResult<ICustomerDTO> CreateCustomer(ICustomerDTO userDTO);
        OperationResult<IList<ICustomerDTO>> GetAllCustomer();
        OperationResult<IList<ICustomerDTO>> SearchCustomer(string name, string email, string contact);
        OperationResult<ICustomerDTO> AddMoneyCustomer(string email, decimal rupees);
        OperationResult<ICustomerDTO> GetCustomerByContact(string contact);
        OperationResult<ICustomerDTO> GetCustomerByEmail(string email);
        OperationResult<ICustomerDTO> WinningAmount(string email, decimal deposited, decimal multipliedBy);
        OperationResult<ICustomerDTO> BlockMoneyCustomer(string email, decimal rupees);
    }
}
