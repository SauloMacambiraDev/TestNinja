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
    public class MathTests
    {
        private Fundamentals.Math _math;

        /*
            NUnit has a feature where is possible to add methods that works like lifecycle events
            that occur before (SetUp) or after (TearDown) each test method with [Test] C# attribbute signature
            1. SetUp - Occurs before each test method within this class.
            2. TearDown - Occurs after each test method within this class.
        */

        [SetUp]
        public void SetUp() // this method could have any name. But we choose SetUp following best practices
        {
            _math = new Fundamentals.Math();
        }

        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguents()
        {
            // Arrange
            //var math = new Fundamentals.Math();

            // Act
            var result = _math.Add(1, 2);

            //Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 3, 3)]
        [TestCase(4, 4, 4)]
        public void Max_WhenCalled_ReturnTheGreaterArg(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));

        }

        // The tests bellow are redundant 
        [Test]
        [Ignore("This test is redundant. Is already covered by 'Max_WhenCalled_ReturnTheGreaterArg' test method")]
        public void Max_SecondArgIsGreater_ReturnsTheSecondArg()
        {
            var result = _math.Max(1, 3);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [Ignore("This test is redundant. Is already covered by 'Max_WhenCalled_ReturnTheGreaterArg' test method")]
        public void Max_ArgsAreEqual_ReturnsTheValueForBothArgs()
        {

            var result = _math.Max(2, 2);

            Assert.That(result, Is.EqualTo(2));
        }


        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            //Assert.That(result, Is.Not.Empty);
            //Assert.That(result.Count(), Is.EqualTo(3));

            //Assert.That(result, Does.Contain(1));
            //Assert.That(result, Does.Contain(3));
            //Assert.That(result, Does.Contain(5));

            // All options above, is the equivalent of the code below:
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

            Assert.That(result, Is.Ordered); // Make sure that the result array is Ordered
            Assert.That(result, Is.Unique); // Not Duplicated items into this particular array

        }
    }
}
