using System;

namespace PublisherSubscriberPattern.Publish
{
    public interface IPublisher<T>
    {
        event EventHandler<DataPublisherEventArgs<T>> DataPublish;
        void OnDataPublish(DataPublisherEventArgs<T> args);
        void PublishData(T data);
    }
}
