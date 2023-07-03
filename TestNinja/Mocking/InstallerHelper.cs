using System.Net;
using TestNinja.Mocking.Interfaces;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private IDownloadUtility _downloadUtility;
        public InstallerHelper(IDownloadUtility downloadUtility = null)
        {
            _downloadUtility = downloadUtility ?? new DownloadUtility();
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _downloadUtility.DownloadFileFromTo(string.Format("http://example.com/{0}/{1}",
                                                    customerName,
                                                    installerName), _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }
}