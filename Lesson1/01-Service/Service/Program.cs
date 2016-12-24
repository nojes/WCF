using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contract;

namespace Service
{
    class ContractService : IContractService
    {
        public double Method(string s)
        {
            Console.WriteLine($"Query: {s}");
            Console.WriteLine(OperationContext.Current.RequestContext.RequestMessage + "\n\n");

            return (s == "double") ? 1080.80 : 0;
        }

        public string Test(string s)
        {
            return s;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Server";

            ServiceHost serviceHost = new ServiceHost(typeof(ContractService), new Uri("net.tcp://localhost:8000/Service"));

//            serviceHost.AddServiceEndpoint(typeof(IContractService), new BasicHttpBinding(), "");
            serviceHost.AddServiceEndpoint(typeof(IContractService), new NetTcpBinding(), "");
            serviceHost.Open();

            Console.WriteLine("Enter any key...");
            Console.ReadKey();

            serviceHost.Close();
        }
    }
}
