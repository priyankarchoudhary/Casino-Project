using Casino.AdminPortal.Shared;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Casino.AdminPortal.Business.Validation
{
    public class CustomerValidator : AbstractValidator<ICustomerDTO>
    {
        public CustomerValidator()
        {
            RuleSet("Common", () =>
            {
                RuleFor(customer => customer.CustomerName).NotEmpty().WithMessage(Constants.TitleMandatory);
                RuleFor(customer => customer.EmailId).NotEmpty().WithMessage(Constants.EmailMandatory);
                RuleFor(customer => customer.EmailId).EmailAddress().WithMessage(Constants.TitleMandatory);
                RuleFor(customer => customer.DOB).NotEmpty().WithMessage(Constants.AgeMandatory).Must(AgeValidation).WithMessage(Constants.AgeValidation);
                RuleFor(customer => customer.Contact).Must(MobileNubmerValidation).WithMessage(Constants.Mobilevalidation);

            });



        }

        private bool MobileNubmerValidation(string arg)
        {
            if (Regex.Match(arg, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$").Success)
                return true;

            else
                return false;

        }

        private bool AgeValidation(DateTime arg)
        {
            DateTime d1 = DateTime.Now;
            DateTime d2 = arg;
            TimeSpan ts = d1 - d2;
            int differenceInYears = ((ts.Days) / 365); // This is in int
            if (differenceInYears > 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool EmailUniqueness(string email)
        {
            ICustomerDAC custDAC = (ICustomerDAC)DACFactory.Instance.Create(DACType.CustomerDAC);
            bool retVal = custDAC.GetCustomerByEmail(email) == null;
            return retVal;
        }



        
    }
}
