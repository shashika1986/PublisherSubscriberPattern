using System;

namespace PublisherSubscriberPattern.Publish
{
    public class DataPublisherEventArgs<T> : EventArgs
    {
        public T Message { get; set; }
        public DataPublisherEventArgs(T message)
        {
            Message = message;
        }

    }
}
