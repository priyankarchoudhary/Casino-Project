using Casino.AdminPortal.Shared;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.AdminPortal.Business.Validation
{
    public class CustomerValidator : AbstractValidator<ICustomerDTO>
    {
        public CustomerValidator()
        {
            
        }
    }
}
