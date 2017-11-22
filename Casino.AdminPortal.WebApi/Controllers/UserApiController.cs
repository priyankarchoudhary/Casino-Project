
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
    }
}
