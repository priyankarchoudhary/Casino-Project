using Casino.AdminPortal.EntityDataModel;
using Casino.AdminPortal.EntityDataModel.EntityModel;
using Casino.AdminPortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.AdminPortal.Data
{
    public class CustomerDAC : DACBase, ICustomerDAC
    {
        public CustomerDAC()
            : base(DACType.CustomerDAC)
        {

        }

        public ICustomerDTO CreateCustomer(ICustomerDTO custDTO)
        {
            ICustomerDTO createCustomerRetval = null;
            try
            {
                using (CustomerPortalEntities context = new CustomerPortalEntities())
                {
                    CustomerTable customer = new CustomerTable();
                    custDTO.BlockBalance = 0;
                    custDTO.AccountBalance = 500;
                    EntityDataModel.EntityConverter.FillEntityFromDTO(custDTO, customer);
                    context.CustomerTables.Add(customer);
                    if (context.SaveChanges() > 0)
                    {
                        custDTO.CustomerId = customer.CustomerId;
                        createCustomerRetval = custDTO;
                    }
                }
                
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return createCustomerRetval;
        }


        public IList<ICustomerDTO> GetAllCustomer()
        {
            IList<ICustomerDTO> userDtoList = new List<ICustomerDTO>();
            using (CustomerPortalEntities context = new CustomerPortalEntities())
            {
                foreach (var customer in context.CustomerTables)
                {
                    ICustomerDTO custDTO = (ICustomerDTO)DTOFactory.Instance.Create(DTOType.CustomerDTO);
                    EntityDataModel.EntityConverter.FillDTOFromEntity(customer, custDTO);
                    userDtoList.Add(custDTO);
                }
                return userDtoList;

            }
        }


        public IList<ICustomerDTO> SearchCustomer(string name, string email, string contact)
        {
            IList<ICustomerDTO> returnedList = null;        
            
            using (CustomerPortalEntities context = new CustomerPortalEntities())
            {
                IList<SearchCustomer_Result> custList = new List<SearchCustomer_Result>();
                custList = (IList<SearchCustomer_Result>)context.SearchCustomer(name, contact, email).ToList();
                if (custList.Count > 0)
                {
                    returnedList = new List<ICustomerDTO>();
                    foreach (var user in custList)
                    {
                        ICustomerDTO userDTO = (ICustomerDTO)DTOFactory.Instance.Create(DTOType.CustomerDTO);
                        EntityDataModel.EntityConverter.FillDTOFromEntity(user, userDTO);
                        returnedList.Add(userDTO);
                    }
                }
            }
            return returnedList;

        }

        public ICustomerDTO AddMoneyCustomer(string email, decimal rupees)
        {

            ICustomerDTO retVal = null;

            try
            {
                using (CustomerPortalEntities context = new CustomerPortalEntities())
                {
                    var customerDetails = context.CustomerTables.FirstOrDefault(item => item.EmailId == email);
                    if (customerDetails != null)
                    {
                        ICustomerDTO custDTO = (ICustomerDTO)DTOFactory.Instance.Create(DTOType.CustomerDTO);
                        retVal = (ICustomerDTO)DTOFactory.Instance.Create(DTOType.CustomerDTO);
                        customerDetails.AccountBalance += rupees;
                        context.SaveChanges();
                        EntityDataModel.EntityConverter.FillDTOFromEntity(customerDetails, custDTO);
                        retVal = custDTO;
                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return retVal;
            
        }


        public ICustomerDTO BlockMoneyCustomer(string email, decimal rupees)
        {
            ICustomerDTO retVal = null;

            try
            {
                using (CustomerPortalEntities context = new CustomerPortalEntities())
                {
                    var customerDetails = context.CustomerTables.FirstOrDefault(item => item.EmailId == email);
                    if (customerDetails != null)
                    {
                        ICustomerDTO custDTO = (ICustomerDTO)DTOFactory.Instance.Create(DTOType.CustomerDTO);
                        retVal = (ICustomerDTO)DTOFactory.Instance.Create(DTOType.CustomerDTO);
                        if (customerDetails.AccountBalance > rupees)
                        {
                            customerDetails.AccountBalance -= rupees;
                            customerDetails.BlockBalance = Convert.ToInt32(rupees);
                            
                        }
                        //customerDetails.AccountBalance += rupees;
                        context.SaveChanges();
                        EntityDataModel.EntityConverter.FillDTOFromEntity(customerDetails, custDTO);
                        retVal = custDTO;
                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return retVal;
            //throw new NotImplementedException();
        }

        public ICustomerDTO GetCustomerByContact(string contact)
        {
            ICustomerDTO retVal = null;

            try
            {
                using (CustomerPortalEntities context = new CustomerPortalEntities())
                {
                    var custDetails = context.CustomerTables.FirstOrDefault(item => item.Contact == contact);
                    if (custDetails != null)
                    {
                        ICustomerDTO custDTO = (ICustomerDTO)DTOFactory.Instance.Create(DTOType.CustomerDTO);
                        retVal = (ICustomerDTO)DTOFactory.Instance.Create(DTOType.CustomerDTO);

                        EntityConverter.FillDTOFromEntity(custDetails, custDTO);
                        retVal = custDTO;
                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return retVal;
 
            //throw new NotImplementedException();
        }

        public ICustomerDTO GetCustomerByEmail(string email)
        {
            ICustomerDTO retVal = null;

            try
            {
                using (CustomerPortalEntities context = new CustomerPortalEntities())
                {
                    var custDetails = context.CustomerTables.FirstOrDefault(item => item.EmailId == email);
                    if (custDetails != null)
                    {
                        ICustomerDTO custDTO = (ICustomerDTO)DTOFactory.Instance.Create(DTOType.CustomerDTO);
                        retVal = (ICustomerDTO)DTOFactory.Instance.Create(DTOType.CustomerDTO);

                        EntityConverter.FillDTOFromEntity(custDetails, custDTO);
                        retVal = custDTO;
                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return retVal;
        }

        public ICustomerDTO WinningAmount(string email, decimal deposited, int multipliedBy)
        {
            throw new NotImplementedException();
        }
    }
}
