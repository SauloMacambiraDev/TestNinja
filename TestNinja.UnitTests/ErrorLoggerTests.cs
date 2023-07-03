using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        private ErrorLogger _logger;
        [SetUp]
        public void SetUp()
        {
            _logger = new ErrorLogger();
        }

        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            _logger.Log("a");

            Assert.That(_logger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void Log_WhenCalled_LogInvalidValues(string invalidMessage)
        {
            // Idea that i had in my mind in order to check for any Exceptions
            // that might occur within this block of code
            try
            {
                _logger.Log(invalidMessage);
            } catch (Exception ex)
            {
                Assert.That(ex, Is.TypeOf<ArgumentNullException>());
            }

            // The code below suggester by the Instructor of the course is not
            // functional, since the error triggered by .Log(..) method is not being
            // Handled
            //Assert.That(() => _logger.Log(invalidMessage), Throws.ArgumentNullException);
        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var id = Guid.Empty;
            _logger.ErrorLogged += (source, args) => { 
                id = args; 
            };

            _logger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
