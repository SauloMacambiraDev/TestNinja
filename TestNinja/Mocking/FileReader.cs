﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking.Interfaces;

namespace TestNinja.Mocking
{
    public class FileReader: IFileReader
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
