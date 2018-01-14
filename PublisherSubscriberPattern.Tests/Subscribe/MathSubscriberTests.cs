using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublisherSubscriberPattern.Extension;
using PublisherSubscriberPattern.Publish;

namespace PublisherSubscriberPattern.Subscribe.Tests
{
    [TestClass()]
    public class MathSubscriberTests
    {
        /// <summary>
        /// Test MathPublisher with a subscription
        /// </summary>
        [TestMethod()]
        public void MathSubscriberTest()
        {
            //arrange
            IPublisher<double> mathPublisher = new MathPublisher(new Calculator());
            MathSubscriber mathSub = new MathSubscriber(mathPublisher);

            double expected = 155.23;
            double actual = 0;

            //act
            mathPublisher.PublishData(55.23);
            actual = mathSub.Value;

            //assert
            Assert.AreEqual(expected, actual);

        }
        /// <summary>
        /// Test MathPublisher with multiple subscriptions
        /// </summary>
        [TestMethod()]
        public void MultipleMathSubscriberTest()
        {
            //arrange
            IPublisher<double> mathPublisher = new MathPublisher(new Calculator());
            MathSubscriber mathSub1 = new MathSubscriber(mathPublisher);
            MathSubscriber mathSub2 = new MathSubscriber(mathPublisher);
            MathSubscriber mathSub3 = new MathSubscriber(mathPublisher);

            double expected = 155.23;
            double actual1 = 0;
            double actual2 = 0;
            double actual3 = 0;

            //act
            mathPublisher.PublishData(55.23);
            actual1 = mathSub1.Value;
            actual2 = mathSub2.Value;
            actual3 = mathSub3.Value;

            //assert
            Assert.IsTrue((expected == actual1) &&
                          (expected == actual2) &&
                          (expected == actual3), "Multiple MathSubscription failed");

        }
    }
}