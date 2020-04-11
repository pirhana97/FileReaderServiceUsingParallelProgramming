using FileReaderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FileReaderServiceProxy
{
    public class FileReaderServiceProxy : ClientBase<IFileReaderService>, IFileReaderService
    {
        public FileReaderServiceProxy(string endpointName)
            : base(endpointName)
        { }
        public string GetAttributes(string filePath)
        {
            return base.Channel.GetAttributes(filePath);
        }
    }
}
