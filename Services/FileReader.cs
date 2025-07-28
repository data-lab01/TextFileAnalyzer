using System;
using System.Collections.Generic;
using System.IO;

namespace TextFileAnalyzer.Services
{
    public class FileReader
    {
        public bool FileExists(string path) => File.Exists(path);

        public string[] ReadLines(string path) => File.ReadAllLines(path);
    }
}