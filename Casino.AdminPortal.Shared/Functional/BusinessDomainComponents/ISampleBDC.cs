using Casino.AdminPortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.AdminPortal.Shared
{
    public interface ISampleBDC : IBusinessDomainComponent
    {
        OperationResult<ISampleDTO> SampleMethod(ISampleDTO sampleDTO);
    }
}
