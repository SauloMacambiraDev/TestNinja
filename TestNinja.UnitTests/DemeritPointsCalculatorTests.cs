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
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;

        [SetUp]
        public void SetUp()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-10)]
        [TestCase(3000)]
        [Ignore("When Localling testing, trigger Exception at runtime in Visual Studio, disturbing the exercise practice")]
        public void CalculateDemeritPoints_WhenSpeedIsOutOfRange_ThrowArgOutOfRangeException(int speed)
        {
            //try
            //{
            //    _demeritPointsCalculator.CalculateDemeritPoints(speed);
            //}
            //catch(Exception ex)
            //{
            //    var exOutOfRangeException = ex as ArgumentOutOfRangeException;
            //    Assert.That(exOutOfRangeException, Is.Not.Null);
            //}

            
            Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(speed), 
                        Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

        }

        [Test]
        public void CalculateDemeritPoints_WhenSpeedIsLesserThanSpeedLimit_ReturnZero()
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(10);

            Assert.That(result, Is.EqualTo(0));
        }

        
        [Test]
        public void CalculateDemeritPoints_WhenSpeedIsInAcceptableRange_ReturnDemeritPoints()
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(70);

            Assert.That(result, Is.EqualTo(1));
        }


    }
}
