using Casino.AdminPortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.AdminPortal.BusinessFacades
{
    public class CustomerFacade : FacadeBase, ICustomerFacade
    {
        public CustomerFacade() : base(FacadeType.CustomerFacade)
        {

        }


        public OperationResult<ICustomerDTO> CreateCustomer(ICustomerDTO userDTO)
        {
            ICustomerBDC userBDC = (ICustomerBDC)BDCFactory.Instance.Create(BDCType.CustomerBDC);
            return userBDC.CreateCustomer(userDTO);
        }

        public OperationResult<IList<ICustomerDTO>> GetAllCustomer()
        {
            ICustomerBDC departmentBDC = (ICustomerBDC)BDCFactory.Instance.Create(BDCType.CustomerBDC);
            return departmentBDC.GetAllCustomer();
        }


        public OperationResult<IList<ICustomerDTO>> SearchCustomer(string name, string email, string contact)
        {
            ICustomerBDC userBDC = (ICustomerBDC)BDCFactory.Instance.Create(BDCType.CustomerBDC);
            return userBDC.SearchCustomer(name,email,contact);
        }


        public OperationResult<ICustomerDTO> AddMoneyCustomer(string email, decimal rupees)
        {
            ICustomerBDC userBDC = (ICustomerBDC)BDCFactory.Instance.Create(BDCType.CustomerBDC);
            return userBDC.AddMoneyCustomer(email,rupees);
            //throw new NotImplementedException();
        }


        public OperationResult<ICustomerDTO> GetCustomerByContact(string contact)
        {
            throw new NotImplementedException();
        }

        public OperationResult<ICustomerDTO> GetCustomerByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public OperationResult<ICustomerDTO> WinningAmount(string email, decimal deposited, int multipliedBy)
        {
            throw new NotImplementedException();
        }

        public OperationResult<ICustomerDTO> BlockMoneyCustomer(string email, decimal rupees)
        {
            throw new NotImplementedException();
        }
    }
}
