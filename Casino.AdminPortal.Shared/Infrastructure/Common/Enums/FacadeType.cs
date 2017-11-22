using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.AdminPortal.Shared
{
    /// <summary>
    /// The Facade Types
    /// </summary>
    public enum FacadeType
    {
       
        /// <summary>
        /// Notice Facade
        /// </summary>
        [QualifiedTypeName("Casino.AdminPortal.BusinessFacades.dll", "Casino.AdminPortal.BusinessFacades.SampleFacade")]
        SampleFacade = 0,
        [QualifiedTypeName("Casino.AdminPortal.BusinessFacades.dll", "Casino.AdminPortal.BusinessFacades.CustomerFacade")]
        CustomerFacade = 1
    }
}
