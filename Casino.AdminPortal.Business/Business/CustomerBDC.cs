using Casino.AdminPortal.Business.Validation;
using Casino.AdminPortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.AdminPortal.Business
{
    public class CustomerBDC : BDCBase, ICustomerBDC
    {
        public CustomerBDC()
            : base(BDCType.CustomerBDC)
        {

        }

        public OperationResult<ICustomerDTO> CreateCustomer(ICustomerDTO custDTO)
        {
            OperationResult<ICustomerDTO> createCustomerReturnValue = null;
            try
            {
                EmployeePortalValidationResult validationResult = Validator<CustomerValidator, ICustomerDTO>.Validate(custDTO, "Common,Create,CreateUserEmail");

                if (!validationResult.IsValid)
                {
                    createCustomerReturnValue = OperationResult<ICustomerDTO>.CreateFailureResult(validationResult);
                }
                else
                {
                    ICustomerDAC employeeDAC = (ICustomerDAC)DACFactory.Instance.Create(DACType.CustomerDAC);
                    ICustomerDTO returnedUserDTO = employeeDAC.CreateCustomer(custDTO);
                    if (returnedUserDTO != null)
                    {
                        createCustomerReturnValue = OperationResult<ICustomerDTO>.CreateSuccessResult(returnedUserDTO, "Usercreated successfully");
                    }
                    else
                    {
                        createCustomerReturnValue = OperationResult<ICustomerDTO>.CreateFailureResult("Insertion failed!");
                    }
                }
            }
            catch (DACException dacEx)
            {
                createCustomerReturnValue = OperationResult<ICustomerDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                createCustomerReturnValue = OperationResult<ICustomerDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return createCustomerReturnValue;
        }


        public OperationResult<IList<ICustomerDTO>> GetAllCustomer()
        {
            OperationResult<IList<ICustomerDTO>> retVal = null;
            ICustomerDAC userDAC = (ICustomerDAC)DACFactory.Instance.Create(DACType.CustomerDAC);
            IList<ICustomerDTO> result = userDAC.GetAllCustomer();
            retVal = OperationResult<IList<ICustomerDTO>>.CreateSuccessResult(result);
            return retVal;
        }


        public OperationResult<IList<ICustomerDTO>> SearchCustomer(string name, string email, string contact)
        {
            OperationResult<IList<ICustomerDTO>> getCustomerReturnValue = null;
            try
            {
                     ICustomerDAC custDAC = (ICustomerDAC)DACFactory.Instance.Create(DACType.CustomerDAC);
                    IList<ICustomerDTO> returnedDTO = custDAC.SearchCustomer(name, email, contact);
                    if (returnedDTO != null)
                    {
                        getCustomerReturnValue = OperationResult<IList<ICustomerDTO>>.CreateSuccessResult(returnedDTO, "Customer list  Succesfully found");
                    }
                    else
                    {
                        getCustomerReturnValue = OperationResult<IList<ICustomerDTO>>.CreateFailureResult("No Customer found");
                    }   
               
            }
            catch (DACException dacEx)
            {
                getCustomerReturnValue = OperationResult<IList<ICustomerDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                getCustomerReturnValue = OperationResult<IList<ICustomerDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return getCustomerReturnValue;
        }


        public OperationResult<ICustomerDTO> AddMoneyCustomer(string email, decimal rupees)
        {
            OperationResult<ICustomerDTO> getCustomerReturnValue = null;
            try
            {
                ICustomerDAC custDAC = (ICustomerDAC)DACFactory.Instance.Create(DACType.CustomerDAC);
                ICustomerDTO returnedDTO = custDAC.AddMoneyCustomer(email, rupees);
                if (returnedDTO != null)
                {
                    getCustomerReturnValue = OperationResult<ICustomerDTO>.CreateSuccessResult(returnedDTO, "Customer list  Succesfully found");
                }
                else
                {
                    getCustomerReturnValue = OperationResult<ICustomerDTO>.CreateFailureResult("No Customer found");
                }

            }
            catch (DACException dacEx)
            {
                getCustomerReturnValue = OperationResult<ICustomerDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                getCustomerReturnValue = OperationResult<ICustomerDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return getCustomerReturnValue;

            
        }


        public OperationResult<ICustomerDTO> GetCustomerByContact(string contact)
        {
            throw new NotImplementedException();
        }

        public OperationResult<ICustomerDTO> GetCustomerByEmail(string email)
        {
            OperationResult<ICustomerDTO> ReturnValue = null;
            try
            {
                //EmployeePortalValidationResult validationResult = Validator<EmployeeValidator, IUserDTO>.Validate(userDTO, "Common");

                ICustomerDAC userDAC = (ICustomerDAC)DACFactory.Instance.Create(DACType.CustomerDAC);
                ICustomerDTO returnedUserByEmailIdDTO = userDAC.GetCustomerByEmail(email);
                if (returnedUserByEmailIdDTO != null)
                {
                    ReturnValue = OperationResult<ICustomerDTO>.CreateSuccessResult(returnedUserByEmailIdDTO, "User retreived successfully");
                }
                else
                {
                    ReturnValue = OperationResult<ICustomerDTO>.CreateFailureResult("Insertion failed!");
                }

            }
            catch (DACException dacEx)
            {
                ReturnValue = OperationResult<ICustomerDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                ReturnValue = OperationResult<ICustomerDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return ReturnValue;
            //throw new NotImplementedException();
        }

        public OperationResult<ICustomerDTO> WinningAmount(string email, decimal deposited, int multipliedBy)
        {
            throw new NotImplementedException();
        }

        public OperationResult<ICustomerDTO> BlockMoneyCustomer(string email, decimal rupees)
        {
            //throw new NotImplementedException();
            OperationResult<ICustomerDTO> ReturnValue = null;
            try
            {
                //EmployeePortalValidationResult validationResult = Validator<EmployeeValidator, IUserDTO>.Validate(userDTO, "Common");

                ICustomerDAC userDAC = (ICustomerDAC)DACFactory.Instance.Create(DACType.CustomerDAC);
                ICustomerDTO returnedUserByEmailIdDTO = userDAC.BlockMoneyCustomer(email,rupees);
                if (returnedUserByEmailIdDTO != null)
                {
                    ReturnValue = OperationResult<ICustomerDTO>.CreateSuccessResult(returnedUserByEmailIdDTO, "User retreived successfully");
                }
                else
                {
                    ReturnValue = OperationResult<ICustomerDTO>.CreateFailureResult("Insertion failed!");
                }

            }
            catch (DACException dacEx)
            {
                ReturnValue = OperationResult<ICustomerDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                ReturnValue = OperationResult<ICustomerDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return ReturnValue;
 
        }
    }
}
