using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FileReaderService
{
    [ServiceContract()]
    public interface IFileReaderService
    {
        [OperationContract()]
        string GetAttributes(string filePath);
    }
}
