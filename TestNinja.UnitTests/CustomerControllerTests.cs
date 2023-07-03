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
    public class CustomerControllerTests
    {

        private CustomerController _customerController;

        [SetUp]
        public void SetUp()
        {
            _customerController = new CustomerController();
        }


        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var actionResult = _customerController.GetCustomer(0);

            Assert.That(actionResult, Is.TypeOf<NotFound>());
        }
        
        [Test]
        public void GetCustomer_IdIsNotZero_ReturOk()
        {
            var actionResult = _customerController.GetCustomer(10);

            // Expects a Ok Object
            Assert.That(actionResult, Is.TypeOf<Ok>());

            // Expects a NotFound Object and its derivatives classes
            //Assert.That(actionResult, Is.InstanceOf<Ok>());
        }

        [Test]
        [TestCase(0)]
        [TestCase(10)]
        [Ignore("TODO: Still don't know how to handle different results in which type is an instance of a non-primitive object class")]
        public void GetCustomer_WhenCalled_ReturnAnActionResult(int id)
        {
        }

    }
}
