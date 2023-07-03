using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;
using TestNinja.Mocking.Interfaces;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private InstallerHelper _installerHelper;
        private Mock<IDownloadUtility> _mockDownloadUtility;

        [SetUp]
        public void SetUp()
        {
            _mockDownloadUtility = new Mock<IDownloadUtility>();
            _installerHelper = new InstallerHelper(_mockDownloadUtility.Object);
        }

        [Test]
        public void DownloadInstaller_WhenDownloadedSucessfully_ReturnTrue()
        {
            // In this execution path, we don't expect any value to come from the DownloadFileFromTo() method.
            // So is not necessary to mock its function with parameter e return values
            //_mockDownloadUtility.Setup(mdu => mdu.DownloadFileFromTo("fromUrl", "ToDestinationFile"));

            var result = _installerHelper.DownloadInstaller("Customer Name", "Installer Name");

            Assert.That(result, Is.True);
        }

        
        [Test]
        public void DownloadInstaller_WhenDownloadFails_ReturnFalse()
        {
            // We could also give a generic value to the DownloadFileFromTo method by doing this:
            //_mockDownloadUtility.Setup(mdu => mdu.DownloadFileFromTo(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();
            _mockDownloadUtility.Setup(mdu => mdu.DownloadFileFromTo("http://example.com/customer/installer", null))
                                .Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.False);
        }


    }
}
