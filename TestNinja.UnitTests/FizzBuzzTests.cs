﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {

        [Test]
        public void GetOutput_InputIsDividedBy3And5_ReturnFizzBuzz(){
            var result = FizzBuzz.GetOutput(15);

            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }
        
        [Test]
        public void GetOutput_InputIsDividedBy3_ReturnFizz(){
            var result = FizzBuzz.GetOutput(3);

            Assert.That(result, Is.EqualTo("Fizz"));
        }
        
        [Test]
        public void GetOutput_InputIsDividedBy5_ReturnBuzz(){
            var result = FizzBuzz.GetOutput(5);

            Assert.That(result, Is.EqualTo("Buzz"));
        }
        
        [Test]
        public void GetOutput_InputIsNotDividedBy3And5_ReturnTheSameNumber(){
            var result = FizzBuzz.GetOutput(2);

            Assert.That(result, Is.EqualTo(2.ToString()));
        }

    }
}
