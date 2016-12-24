using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contract;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Client";

            ChannelFactory<IContractService> channelFactory = 
                new ChannelFactory<IContractService>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:8000/Service"));

            IContractService service = channelFactory.CreateChannel();
            Console.WriteLine("Enter any key...");
            Console.ReadKey();
            double number = service.Method("double");

            Console.WriteLine($"Number: {number}");

            Console.WriteLine("Enter any key...");
            Console.ReadKey();
        }
    }
}
