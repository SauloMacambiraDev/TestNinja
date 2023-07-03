using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;


namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class OrderServiceTests
    {

        private Mock<IStorage> _mockStorage;
        private OrderService _orderService;

        [SetUp]
        public void SetUp()
        {
            _mockStorage = new Mock<IStorage>();
            _orderService = new OrderService(_mockStorage.Object);
        }

        [Test]
        public void PlaceOrder_WhenCalled_ShouldStoreTheOrder()
        {
            var order = new Order();
            //_mockStorage.Setup(x => x.Store("a")).Returns(1);
            //var result = _orderService.PlaceOrder(order);

            _orderService.PlaceOrder(order);

            _mockStorage.Verify(x => x.Store(order));
            
            //Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void PlaceOrder_AddingAnOrderSucessfully_ReturnTheOrderId()
        {
            var order = new Order();
            _mockStorage.Setup(x => x.Store(order)).Returns(12);

            var result = _orderService.PlaceOrder(order);

            Assert.That(result, Is.EqualTo(12));

        }

        public void PlaceOrder_AddingInvalidOrder_ReturnInvalidOperationException()
        {

            try
            {
                var order = new Order();
                _mockStorage.Setup(x => x.Store(order)).Throws<InvalidOperationException>();
                var result = _orderService.PlaceOrder(order);
                //Assert.That(() => _orderService.PlaceOrder(order), Throws.InvalidOperationException); // Stop the debugger execution
                _orderService.PlaceOrder(order);
            } catch (Exception ex)
            {
                Assert.That(ex, Is.Not.Null);
                Assert.That(ex, Is.InstanceOf<InvalidOperationException>());
            }


        }
    }
}
