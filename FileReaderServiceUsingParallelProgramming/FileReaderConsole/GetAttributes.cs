﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReaderConsole
{
    class GetAttributes
    {
        public string Attributes(string filePath)
        {
            FileInfo fi = new System.IO.FileInfo(filePath);

            int charCount = 0;
            int linesCount = 0;
            string FileText = new System.IO.StreamReader(filePath).ReadToEnd().Replace("\r\n", "\r");
            charCount = FileText.Length;
            linesCount = FileText.Split('\r').Length;

            long total_size_in_bytes = fi.Length;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Total Size: " + total_size_in_bytes + "\n");
            stringBuilder.Append("Character Count: " + FileText.Length + "\n");
            stringBuilder.Append("Line Count: " + FileText.Split('\r').Length + "\n");


            string fileDetails = stringBuilder.ToString();

            return fileDetails;
        }
    }
}
