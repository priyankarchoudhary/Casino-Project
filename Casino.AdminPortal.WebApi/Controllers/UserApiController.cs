using Casino.AdminPortal.Shared;
using Casino.AdminPortal.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Casino.AdminPortal.WebApi.Controllers
{
    public class UserApiController : ApiController
    {
        public UserApi GetAllUser()
        {
            ICustomerFacade userFacade = (ICustomerFacade)FacadeFactory.Instance.Create(FacadeType.CustomerFacade);
            OperationResult<IList<ICustomerDTO>> resultAllCustomers = userFacade.GetAllCustomer();
            UserApi user = new UserApi();
            user.userList = new List<UserApiModel>();
            if (resultAllCustomers.IsValid())
            {
                foreach (var item in resultAllCustomers.Data)
                {
                    UserApiModel newUser = new UserApiModel();
                    newUser.CustomerName = item.CustomerName;
                    newUser.EmailId = item.EmailId;
                    newUser.AccountBalance = item.AccountBalance;
                    newUser.BlockBalance = item.BlockBalance;
                    user.userList.Add(newUser);
                }
            }
            else
            {
                IList<EmployeePortalValidationFailure> resultFail = resultAllCustomers.ValidationResult.Errors;
                foreach (var item in resultFail)
                {

                }
            }
            return user;
        }


        public UserApiModel GetUserByEmailID(string email)
        {
            ICustomerFacade userFacade = (ICustomerFacade)FacadeFactory.Instance.Create(FacadeType.CustomerFacade);
            OperationResult<ICustomerDTO> resultAllCustomers = userFacade.GetCustomerByEmail(email);
            UserApiModel newUser = new UserApiModel();
            if (resultAllCustomers.IsValid())
            {
                
                newUser.CustomerName = resultAllCustomers.Data.CustomerName;
                newUser.EmailId =      resultAllCustomers.Data.EmailId;
                newUser.AccountBalance = resultAllCustomers.Data.AccountBalance;
                newUser.BlockBalance = resultAllCustomers.Data.BlockBalance;
                
            }
            else
            {
               // IList<EmployeePortalValidationFailure> resultFail = resultAllCustomers.ValidationResult.Errors;
               
            }
            return newUser;

        }
        
        public UserApiModel BlockMoneyOnBet(string email, decimal rupees)
        {
            ICustomerFacade userFacade = (ICustomerFacade)FacadeFactory.Instance.Create(FacadeType.CustomerFacade);
            OperationResult<ICustomerDTO> resultAllCustomers = userFacade.BlockMoneyCustomer(email,rupees);
            UserApiModel newUser = new UserApiModel();
            if (resultAllCustomers.IsValid())
            {

                newUser.CustomerName = resultAllCustomers.Data.CustomerName;
                newUser.EmailId = resultAllCustomers.Data.EmailId;
                newUser.AccountBalance = resultAllCustomers.Data.AccountBalance;
                newUser.BlockBalance = resultAllCustomers.Data.BlockBalance;

            }
            else
            {
                // IList<EmployeePortalValidationFailure> resultFail = resultAllCustomers.ValidationResult.Errors;

            }
            return newUser;

        }
    }
}
