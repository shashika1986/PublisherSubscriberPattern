using PublisherSubscriberPattern.Publish;

namespace PublisherSubscriberPattern.Subscribe
{
    public class MathSubscriber
    {
        private readonly IPublisher<double> _doublePublisher;
        private readonly Subscriber<double> _doubleSubscriber;
        public double Value { get; private set; }

        public MathSubscriber(IPublisher<double> doublePublisher)
        {
            _doublePublisher = doublePublisher;
            _doubleSubscriber = new Subscriber<double>(_doublePublisher);
            _doubleSubscriber.Publisher.DataPublish += Listener;
        }

        private void Listener(object sender, DataPublisherEventArgs<double> e)
        {
            Value = e.Message;
        }
    }
}
