using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublisherSubscriberPattern.Publish;

namespace PublisherSubscriberPattern.Subscribe.Tests
{
    [TestClass()]
    public class UpperCaseSubscriberTests
    {
        /// <summary>
        /// Test UpperCasePublisher with a subscriber.
        /// </summary>
        [TestMethod()]
        public void UpperCaseSubscriberTest()
        {
            //arrange
            IPublisher<string> upperCasePublisher = new UpperCasePublisher();
            UpperCaseSubscriber strSub = new UpperCaseSubscriber(upperCasePublisher);
            
            string expected = "Upper case of Testing is TESTING"; 
            string actual = string.Empty;

            //act
            upperCasePublisher.PublishData("Testing");
            actual = strSub.Message;

            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test UpperCasePublisher with multiple subscribers.
        /// </summary>
        [TestMethod()]
        public void MultipleUpperCaseSubscriberTest()
        {
            //arrange
            IPublisher<string> upperCasePublisher = new UpperCasePublisher();
            UpperCaseSubscriber strSub1 = new UpperCaseSubscriber(upperCasePublisher);
            UpperCaseSubscriber strSub2 = new UpperCaseSubscriber(upperCasePublisher);
            UpperCaseSubscriber strSub3 = new UpperCaseSubscriber(upperCasePublisher);

            string expected = "Upper case of Testing is TESTING";
            string actual1 = string.Empty;
            string actual2 = string.Empty;
            string actual3 = string.Empty;

            //act
            upperCasePublisher.PublishData("Testing");
            actual1 = strSub1.Message;
            actual2 = strSub2.Message;
            actual3 = strSub3.Message;

            //assert
            Assert.IsTrue(actual1.Contains(expected) && 
                          actual2.Contains(expected) && 
                          actual3.Contains(expected), 
                          "Multiple subscription failed.");
        }
    }
}
