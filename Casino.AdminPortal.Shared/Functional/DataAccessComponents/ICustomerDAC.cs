using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.AdminPortal.Shared
{
    public interface ICustomerDAC : IDataAccessComponent
    {
        ICustomerDTO CreateCustomer(ICustomerDTO custDTO);
        IList<ICustomerDTO> GetAllCustomer();
        IList<ICustomerDTO> SearchCustomer(string name, string email, string contact);
        ICustomerDTO AddMoneyCustomer(string email, decimal rupees);
        ICustomerDTO GetCustomerByContact(string contact);
        ICustomerDTO GetCustomerByEmail(string email);
        ICustomerDTO WinningAmount(string email, decimal deposited , int multipliedBy);
        ICustomerDTO BlockMoneyCustomer(string email, decimal rupees);
    }
}
