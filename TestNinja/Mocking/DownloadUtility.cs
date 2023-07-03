using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking.Interfaces;

namespace TestNinja.Mocking
{
    public class DownloadUtility : IDownloadUtility
    {
        public void DownloadFileFromTo(string fromUrl, string toDestinationFile)
        {
            var client = new WebClient();
            client.DownloadFile(fromUrl, toDestinationFile);
        }
    }
}
