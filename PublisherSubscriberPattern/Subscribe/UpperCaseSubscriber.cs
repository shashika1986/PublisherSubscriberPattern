using PublisherSubscriberPattern.Publish;

namespace PublisherSubscriberPattern.Subscribe
{
    public class UpperCaseSubscriber
    {
        private readonly IPublisher<string> _stringPublisher;
        private readonly Subscriber<string> _stringSubscriber;       
        public string Message { get; private set; }

        public UpperCaseSubscriber(IPublisher<string> stringPublisher)
        {             
            _stringPublisher = stringPublisher;
            _stringSubscriber = new Subscriber<string>(_stringPublisher);
            _stringSubscriber.Publisher.DataPublish += Listener;
        }

        private void Listener(object sender, DataPublisherEventArgs<string> e)
        {
            Message = e.Message?.ToString();
        }        
    }
}
