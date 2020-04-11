using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FileReaderServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
           

            //Create ServiceHost
            ServiceHost host = new ServiceHost(typeof(FileReaderService.FileReaderService));

            //Start the Service
            host.Open();
            Console.WriteLine("Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press  key to stop");
            Console.ReadLine();
         //   host.Close();
        }
    }
}

///https://docs.microsoft.com/en-us/dotnet/framework/wcf/samples/multiple-endpoints