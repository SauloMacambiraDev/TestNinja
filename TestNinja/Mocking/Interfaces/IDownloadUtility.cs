﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking.Interfaces
{
    public interface IDownloadUtility
    {
        void DownloadFileFromTo(string fromUrl, string toDestinationFile);
    }
}
