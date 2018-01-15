using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublisherSubscriberPattern.Extension;

namespace PublisherSubscriberPattern.Publish.Tests
{
    [TestClass()]
    public class MathPublisherTests
    {
        [TestMethod()]
        public void OnDataPublishTest()
        {
            //arrange
            double actual = 0;
            double expect = 115.56;
            MathPublisher publisher = new MathPublisher(new Calculator());

            //act
            publisher.DataPublish += delegate (object sender, DataPublisherEventArgs<double> e)
            {
                actual = e.Message;
            };
            publisher.PublishData(15.56);

            //assert
            Assert.AreEqual(expect, actual);

        }       
    }
}