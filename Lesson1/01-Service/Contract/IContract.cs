using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    [ServiceContract]
    public interface IContractService
    {
        [OperationContract]
        double Method(string s);
        string Test(string s);
    }
}
