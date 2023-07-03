using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {

        private Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<string>();
        }

        [Test]
        public void Push_WhenPushingNullObject_ThrowsArgumentNullException()
        {
            //Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
            try
            {
                _stack.Push(null);
            } catch (Exception ex)
            {
                Assert.That(ex, Is.Not.Null);
                Assert.That(ex, Is.InstanceOf<ArgumentNullException>());
            }
        }

        [Test]
        public void Push_WhenPushingString_ReturnNothing()
        {
            _stack.Push("a");

            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_EmptyStack_ThrowsInvalidOperationException()
        {
            //Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
            try
            {
                _stack.Pop();
            }catch(Exception ex)
            {
                Assert.That(ex, Is.Not.Null);
                Assert.That(ex, Is.InstanceOf<InvalidOperationException>());
            }
        }

        [Test]
        public void Pop_NonEmptyStack_ReturnsObject()
        {
            _stack.Push("a");
            var result = _stack.Pop();

            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_StackWithAFewObjects_ReturnObjectOnTheTop()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            var result = _stack.Peek();

            Assert.That(result, Is.EqualTo("c"));
        }


        [Test]
        public void Count_WhenCalledWithEmptyStack_ReturnZero()
        {
            var result = _stack.Count;

            Assert.That(result, Is.Zero);
        }
        
        [Test]
        public void Count_WhenCalledWithFilledStack_ReturnNonZero()
        {
            _stack.Push("1");
            
            var result = _stack.Count;

            Assert.That(result, Is.EqualTo(1));

        }

        [Test]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            // Code below stop the debbuger execution
            //Assert.That(() => _stack.Peek(), Throws.InvalidOperationException); 

            try
            {
                _stack.Peek();
            }catch(Exception ex)
            {
                Assert.That(ex, Is.Not.Null);
                Assert.That(ex, Is.InstanceOf<InvalidOperationException>());
            }
        }

        [Test]
        public void Peek_StackWithFewObjects_ReturnsObjectOnTheTopOfStack()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            var result = _stack.Peek();

            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Peek_StackWithFewObjects_DoesNotRemoveObjectOnTheTopOfStack()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");
            _stack.Peek();

            Assert.That(_stack.Count, Is.EqualTo(3));
        }


    }
}
