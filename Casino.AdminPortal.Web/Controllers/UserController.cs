using Casino.AdminPortal.Shared;
using Casino.AdminPortal.Web.Models;
using Casino.AdminPortal.Web.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casino.AdminPortal.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        

        public byte[] convertToBytes(HttpPostedFileBase image){
             byte[] imageBytes = null;
             BinaryReader reader = new BinaryReader(image.InputStream);
             imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        public PartialViewResult Index()
        {
            return PartialView();
        }

        public PartialViewResult GetAllUser()
        {
            ICustomerFacade userFacade = (ICustomerFacade)FacadeFactory.Instance.Create(FacadeType.CustomerFacade);
            OperationResult<IList<ICustomerDTO>> resultAllCustomers = userFacade.GetAllCustomer();
            List<UserModel> result = new List<UserModel>();
            if (resultAllCustomers.IsValid())
            {
                foreach (var item in resultAllCustomers.Data)
                {
                    UserModel userData = new UserModel();
                    DTOConverter.FillViewModelFromDTO(userData, item);
                    result.Add(userData);
                }
            }
            else
            {
                IList<EmployeePortalValidationFailure> resultFail = resultAllCustomers.ValidationResult.Errors;
                foreach (var item in resultFail)
                {

                }
            }
            return PartialView(result);
        }

        
        [HttpGet]
        public PartialViewResult CreateUser()
        {
            UserModel result = new UserModel();
            return PartialView(result);
        }

        [HttpPost]
        public ActionResult CreateUser(UserModel customerModel)
        {
            ICustomerFacade userFacade = (ICustomerFacade)FacadeFactory.Instance.Create(FacadeType.CustomerFacade);
            ICustomerDTO userDTOToCreate = (ICustomerDTO)DTOFactory.Instance.Create(DTOType.CustomerDTO);
            HttpPostedFileBase file = Request.Files["ImageData"];
            customerModel.IdProof = convertToBytes(file);
            DTOConverter.FillDTOFromViewModel(userDTOToCreate, customerModel);
            OperationResult<ICustomerDTO> resultCreate = userFacade.CreateCustomer(userDTOToCreate);
            if (ModelState.IsValid)
            {
                if (resultCreate.ValidationResult != null && resultCreate.ValidationResult.Errors != null)
                {
                    IList<EmployeePortalValidationFailure> resultFail = resultCreate.ValidationResult.Errors;
                    foreach (var item in resultFail)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    return View();
                }
                return View("../Home/Index");
            }
            return View("../Home/Index");
           
        }



        public PartialViewResult SearchUser(string nameSearch, string contactSearch, string emailSearch)
        {
            if (nameSearch.Length == 0 && contactSearch.Length == 0 && emailSearch.Length == 0)
            {
                //return PartialView("GetAllUser");
                return PartialView("GetAllUser");

            }
            else
            {
                if (nameSearch.Length == 0)
                {
                    nameSearch = null;
                }

                if (contactSearch.Length == 0)
                {
                    contactSearch = null;
                }

                if (emailSearch.Length == 0)
                {
                    emailSearch = null;
                }

                ICustomerFacade userFacade = (ICustomerFacade)FacadeFactory.Instance.Create(FacadeType.CustomerFacade);
                OperationResult<IList<ICustomerDTO>> resultAllCustomers = userFacade.SearchCustomer(nameSearch, emailSearch, contactSearch);
                List<UserModel> result = new List<UserModel>();
                if (resultAllCustomers.IsValid())
                {
                    foreach (var item in resultAllCustomers.Data)
                    {
                        UserModel userData = new UserModel();
                        DTOConverter.FillViewModelFromDTO(userData, item);
                        result.Add(userData);
                    }
                }
                else
                {
                    return this.GetAllUser();
                    //IList<EmployeePortalValidationFailure> resultFail = resultAllCustomers.ValidationResult.Errors;

                }
                return PartialView("GetAllUser", result);
            }
           
        }


        public PartialViewResult AddMoney(string EmailId , decimal RechargeAmount )
        {
            ICustomerFacade userFacade = (ICustomerFacade)FacadeFactory.Instance.Create(FacadeType.CustomerFacade);
            OperationResult<ICustomerDTO> resultVal = userFacade.AddMoneyCustomer(EmailId, RechargeAmount);
            //List<UserModel> result = new List<UserModel>();
            Console.Write("hello");
            return this.GetAllUser();
        }


    }
}