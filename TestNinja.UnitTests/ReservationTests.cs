using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        /*
         * The automated method test follows that specific convetion:
         * 1. Name of the method on the real system that is being tested
         * 2. Scenario of our testing, following an execution Path.
         * 3. The expected behavior
         * public void CanBeCancelledBy_Scenario_ExpectedBehavior(){...}
         */
        //[TestMethod] - MSTest
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            /* Convention called: AAA - Arrange, Act and Assert. */

            // Arrange - Initialize objects
            var reservation = new Reservation();

            // Act - Where we act on this object
            var result = reservation.CanBeCancelledBy(new User() { IsAdmin = true });


            // Assert - Check the expected result to match
            //Assert.AreEqual(true, result);
            //Assert.IsTrue(result); -> MSTest approach
            //Assert.That(result == true);
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_UserIsNotAdmin_ReturnFalse()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User() { });

            // Assert
            //Assert.IsFalse(result); -> MSTest approach
            Assert.That(result, Is.False);
        }

        [Test]
        public void CanBeCancelledBy_MadeByTheUserWhoReserved_ReturnTrue()
        {
            // Arrange
            var user = new User();
            var reservation = new Reservation()
            {
                MadeBy = user
            };

            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            //Assert.IsTrue(result); -> MSTest approach
            Assert.That(result, Is.True);

        }
    }
}
