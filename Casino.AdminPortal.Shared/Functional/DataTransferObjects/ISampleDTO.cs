using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.AdminPortal.Shared
{ 
    public interface ISampleDTO : IDTO
    {
        string SampleProperty { get; set; }
    }
}
