using FileReaderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FileReaderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client running at..."+DateTime.Now.ToString());

            Console.WriteLine();

            Console.WriteLine("Enter filepath");
            string filePath = Console.ReadLine();

            #region ParallelTasks
            Parallel.Invoke(


                () =>
                {

                 

                      FileReaderServiceProxy.FileReaderServiceProxy proxy = new FileReaderServiceProxy.FileReaderServiceProxy("httpEP");
                  //  FileReaderServiceProxy.FileReaderServiceProxy proxy = new FileReaderServiceProxy.FileReaderServiceProxy(context);

                    Console.WriteLine("File Attributes :");
                        Console.WriteLine(proxy.GetAttributes(filePath));                        
                                                                            
                }

            );
            #endregion

            Console.WriteLine("Press enter to exit...");
            Console.ReadKey();
        }
    }
}













//() => {
//    Console.WriteLine("Attributes of File :");
//    Console.WriteLine();

//},
//() =>
//{
//    FileReaderServiceProxy.FileReaderServiceProxy proxy = new FileReaderServiceProxy.FileReaderServiceProxy("tcpEP");
//    Console.WriteLine("Basic http :" + proxy.GetAttributes(filePath));


//},

//() =>
//{

//    FileReaderServiceProxy.FileReaderServiceProxy proxy = new FileReaderServiceProxy.FileReaderServiceProxy("httpEP");
//    Console.WriteLine("Secure http :" + proxy.GetAttributes(filePath));


//},