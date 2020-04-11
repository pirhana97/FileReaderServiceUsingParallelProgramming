using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReaderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client running...");

            Console.WriteLine("Enter filepath");
            string filePath = Console.ReadLine();

            Console.WriteLine();

            #region ParallelTasks
            Parallel.Invoke(

                () => {
                    Console.WriteLine("Attributes of File :");
                    Console.WriteLine();

                },
                () =>
                {
                   FileReaderServiceProxy.FileReaderServiceProxy proxy = new FileReaderServiceProxy.FileReaderServiceProxy("tcpEP");
                    Console.WriteLine("Basic http :"+ proxy.GetAttributes(filePath));
                    

                },

                () =>
                {

                   FileReaderServiceProxy.FileReaderServiceProxy proxy = new FileReaderServiceProxy.FileReaderServiceProxy("httpEP");
                    Console.WriteLine("Secure http :" + proxy.GetAttributes(filePath));
                  

                }
            );
            #endregion


            Console.WriteLine("Press any key to exit..");
            Console.ReadKey();
        }
    }
}
