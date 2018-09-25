using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace TrueMarbleData
{
    class Program
    {

        public static void Main(string[] args)
        {
            //practical 05
         

            var implObject = Activator.CreateInstance(typeof(TMDataControllerImpl), true);
           
            
     

            ServiceHost host;

            NetTcpBinding tcpBinding = new NetTcpBinding();

            tcpBinding.MaxReceivedMessageSize = System.Int32.MaxValue;

            tcpBinding.ReaderQuotas.MaxArrayLength = System.Int32.MaxValue;
            
           host = new ServiceHost(implObject);

           host.AddServiceEndpoint(typeof(ITMDataController), tcpBinding, "net.tcp://localhost:50001/TMData");

            host.Open();

            System.Console.WriteLine("Server Connected !!!");

            System.Console.ReadLine();

            host.Close();
        }
    }
}

