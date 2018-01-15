using System;

namespace PublisherSubscriberPattern.Publish
{
    public class UpperCasePublisher : IPublisher<string>
    {
        public event EventHandler<DataPublisherEventArgs<string>> DataPublish;         

        public void OnDataPublish(DataPublisherEventArgs<string> args)
        {
            DataPublish?.Invoke(this, args);
        }

        public void PublishData(string data)
        {
            string _data = string.Empty;
            if (!string.IsNullOrEmpty(data))
            {
                _data = "Upper case of " + data + " is " + data.ToUpper();
            }
                        
            DataPublisherEventArgs<string> message = (DataPublisherEventArgs<string>)Activator.CreateInstance(typeof(DataPublisherEventArgs<string>), new object[] { _data });
            OnDataPublish(message);
        }
    }
}
