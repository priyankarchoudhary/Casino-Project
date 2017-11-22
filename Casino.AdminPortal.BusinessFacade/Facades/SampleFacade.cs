using Casino.AdminPortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.AdminPortal.BusinessFacades
{
    public class SampleFacade : FacadeBase, ISampleFacade
    {
        public SampleFacade() : base(FacadeType.SampleFacade)
        {

        }

        public OperationResult<ISampleDTO> SampleMethod(ISampleDTO sampleDTO)
        {
            ISampleBDC sampleBDC = (ISampleBDC)BDCFactory.Instance.Create(BDCType.SampleBDC);//because bdcfactory is singleton, as we cant create object with new keyword
            return sampleBDC.SampleMethod(sampleDTO);
        }
    }
}
