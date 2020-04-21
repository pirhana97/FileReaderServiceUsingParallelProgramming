using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace FileReaderUIClient
{
    class WriteFilePath
    {
        public string writeFilePath()
        {
            string filename = null;
            OpenFileDialog browseFile = new OpenFileDialog();

            if (browseFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = browseFile.FileName;

            }
            return filename;
        }
    }
}
