using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PublisherSubscriberPattern.Publish.Tests
{
    [TestClass()]
    public class UpperCasePublisherTests
    {
        /// <summary>
        /// Test UpperCasePublisher evnet and DataPublisherEventArgs works fine.
        /// </summary>
        [TestMethod()]
        public void OnDataPublishTest()
        {
            //arrange
            string actual = string.Empty;
            string expect = "Upper case of Testing is TESTING";
            UpperCasePublisher publisher = new UpperCasePublisher();

            //act
            publisher.DataPublish += delegate (object sender, DataPublisherEventArgs<string> e)
            {
                actual = e.Message;
            };
            publisher.PublishData("Testing");

            //assert
            Assert.AreEqual(expect, actual);
        }
    }
}