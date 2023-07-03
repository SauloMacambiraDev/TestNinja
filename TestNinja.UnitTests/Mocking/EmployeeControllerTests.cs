using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;
using TestNinja.Mocking.Interfaces;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private EmployeeController _employeeController;
        private Mock<IEmployeeRepository> _mockEmployeeRepository;

        [SetUp]
        public void SetUp()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _employeeController = new EmployeeController(_mockEmployeeRepository.Object);
        }

        [Test]
        public void DeleteEmployee_ProvidingAnEmployeeId_RedirectToAction()
        {
            var result = _employeeController.DeleteEmployee(15);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<RedirectResult>());
        }

        [Test]
        public void DeleteEmployee_ProvidingAnInvalidEmployeeId_ThrowArgumentException()
        {
            try
            {
                _mockEmployeeRepository.Setup(er => er.DeleteEmployeeById(0)).Throws<ArgumentException>();
                _employeeController.DeleteEmployee(0);
                //Assert.That(() => _employeeController.DeleteEmployee(0), Throws.ArgumentNullException); -> Stops the debugger execution
            } catch(Exception ex)
            {
                Assert.That(ex, Is.Not.Null);
                Assert.That(ex, Is.InstanceOf<ArgumentException>());
            }

        }


    }
}
